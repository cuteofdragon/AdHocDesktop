using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AdHocDesktop.Tcp;
using AdHocDesktop.Core;

namespace AdHocDesktop.StreamServer
{
    public partial class StreamServerMainForm : Form
    {        
        AdHocDesktop_TcpServer server;
        SortedDictionary<string, List<AdHocDesktop_TcpClient>> groupTable = new SortedDictionary<string, List<AdHocDesktop_TcpClient>>();
        SortedDictionary<string, string> clientTable = new SortedDictionary<string, string>();
        List<string> winceClients = new List<string>();
        string[] people;
        int bandwidthInput = 0;
        int bandwidthOutput = 0;        

        public StreamServerMainForm()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            server = new AdHocDesktop_TcpServer();
            server.AcceptClient += new AdHocDesktop_TcpServerAcceptClient(server_AcceptClient);
            server.DisconnectClient += new AdHocDesktop_TcpServerAcceptClient(server_DisconnectClient);
            server.Error += new AdHocDesktop_TcpErrorEventHandler(server_Error);
            server.Start();
        }

        void SyncPeople()
        {
            lock (clientTable)
            {
                List<string> result = new List<string>();
                foreach (KeyValuePair<string, string> kvp in clientTable)
                {
                    result.Add(kvp.Key);
                    result.Add(kvp.Value);
                }
                people = result.ToArray();
            }
        }

        void AppendLog(string msg)
        {
            logTextBox.AppendText("[" + DateTime.Now.ToString() + "] " + msg + "\r\n");
        }

        void server_Error(object sender, string message)
        {
            AppendLog(message);
        }

        void ServerAcceptClientCallback(object obj)
        {
            AdHocDesktop_TcpClient client = (AdHocDesktop_TcpClient)obj;
            AppendLog("連線建立在: " + client.Socket.RemoteEndPoint + "（" + server.GetIdentifier(client) + "）");
        }

        void ServerDisconnectClientCallback(object obj)
        {
            AdHocDesktop_TcpClient client = (AdHocDesktop_TcpClient)obj;            
            AppendLog("中斷連線: " + client.Socket.RemoteEndPoint + "（" + server.GetIdentifier(client) + "）");

            if (winceClients.Contains(client.Identifier))
            {
                winceClients.Remove(client.Identifier);
            }
            if (groupTable.ContainsKey(client.Identifier))
            {
                groupTable.Remove(client.Identifier);
            }
            if (clientTable.ContainsKey(client.Identifier))
            {
                clientTable.Remove(client.Identifier);
            }
            SyncPeople();
        }

        void server_DisconnectClient(AdHocDesktop_TcpClient disconnectClient)
        {
            DisconnectClient(disconnectClient);
        }

        void DisconnectClient(AdHocDesktop_TcpClient disconnectClient)
        {
            AdHocDesktop_AsyncCallback ad = new AdHocDesktop_AsyncCallback(ServerDisconnectClientCallback);
            this.BeginInvoke(ad, new object[] { disconnectClient });
        }

        void server_AcceptClient(AdHocDesktop_TcpClient acceptClient)
        {            
            AdHocDesktop_AsyncCallback ad = new AdHocDesktop_AsyncCallback(ServerAcceptClientCallback);
            this.BeginInvoke(ad, new object[] { acceptClient });            

            acceptClient.Received += new AdHocDesktop_TcpReceivedEventHandler(acceptClient_Received);
            acceptClient.Error += new AdHocDesktop_TcpErrorEventHandler(acceptClient_Error);
        }

        void acceptClient_Received(object sender, AdHocDesktop_TcpObject obj)
        {
            try
            {
                AdHocDesktop_TcpClient client = (AdHocDesktop_TcpClient)sender;
                object[] objs = obj.Data;                
                switch (obj.Command)
                {                    
                    case AdHocDesktop_TcpCommand.RequestIdentifier:
                        string id = (string)objs[0];
                        string pw = (string)objs[1];
                        AdHocDesktop_ProfilePlatform platform = (AdHocDesktop_ProfilePlatform)objs[2];
                        bool result = false;
                        if (id != "" && pw != "")
                        {
                            if (clientTable.ContainsValue(client.Identifier))
                            {
                                result = false;
                            }
                            else
                            {
                                result = true;
                                clientTable[client.Identifier] = id;
                                if (platform == AdHocDesktop_ProfilePlatform.WINCE)
                                {
                                    winceClients.Add(client.Identifier);
                                }
                                SyncPeople();
                            }
                        }
                        client.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.ResponseIdentifier, obj.Src, obj.Dest, client.Identifier, result));
                        break;
                    case AdHocDesktop_TcpCommand.RequestPeople:
                        client.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.ResponsePeople, obj.Src, obj.Dest, people));
                        break;
                    case AdHocDesktop_TcpCommand.BeginInvitation:                        
                        if (!groupTable.ContainsKey(obj.Src))
                        {
                            groupTable[obj.Src] = new List<AdHocDesktop_TcpClient>();
                        }
                        server.GetClient(obj.Dest).Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.BeginInvitation, obj.Src, obj.Dest, clientTable[obj.Src]));
                        break;
                    case AdHocDesktop_TcpCommand.EndInvitation:                        
                        bool accept = (bool)objs[0];
                        if (accept)
                        {
                            AdHocDesktop_TcpClient src = server.GetClient(obj.Src);
                            if (!groupTable[obj.Dest].Contains(src))
                            {
                                groupTable[obj.Dest].Add(src);
                            }
                        }
                        server.GetClient(obj.Dest).Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.EndInvitation, obj.Src, obj.Dest, accept));
                        break;
                    case AdHocDesktop_TcpCommand.StreamingScreen:                        
                    case AdHocDesktop_TcpCommand.StreamingCamera:
                    case AdHocDesktop_TcpCommand.StreamingAudio:
                        SendStreaming(client, (byte[])objs[0], obj.Command);
                        break;
                    case AdHocDesktop_TcpCommand.ProfileCamera:
                    case AdHocDesktop_TcpCommand.ProfileScreen:
                        // TODO:
                        break;
                    case AdHocDesktop_TcpCommand.EndSession:
                        SendEndSession(client, obj.Command);
                        break;
                    case AdHocDesktop_TcpCommand.Interrupt:                        
                        DisconnectClient(client);
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void SendEndSession(AdHocDesktop_TcpClient client, AdHocDesktop_TcpCommand command)
        {            
            List<AdHocDesktop_TcpClient> groups = groupTable[client.Identifier];
            for (int i = 0; i < groups.Count; i++)
            {
                if (!groups[i].IsConnected)
                {
                    groups.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < groups.Count; i++)
            {
                AdHocDesktop_TcpClient dest = groups[i];               
                dest.Send(new AdHocDesktop_TcpObject(command, client.Identifier, dest.Identifier, new byte[1]));                
            }
        }

        void SendStreaming(AdHocDesktop_TcpClient client, byte[] buffer, AdHocDesktop_TcpCommand command)
        {            
            bandwidthInput += (buffer == null ? 0 : buffer.Length);
            List<AdHocDesktop_TcpClient> groups = groupTable[client.Identifier];
            for (int i = 0; i < groups.Count; i++)
            {
                if (!groups[i].IsConnected)
                {
                    groups.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < groups.Count; i++)
            {
                AdHocDesktop_TcpClient dest = groups[i];
                if (winceClients.Contains(dest.Identifier))
                {
                    Size size = new Size(240, 180);
                    if (command == AdHocDesktop_TcpCommand.StreamingCamera)
                    {
                        using (Bitmap b = ImageUtil.ByteToBitmap(buffer))
                        {
                            buffer = ImageUtil.ResizeBitmapToJpegByte(b, size);

                        }
                    }
                    else if (command == AdHocDesktop_TcpCommand.StreamingScreen)
                    {
                        using (Bitmap b = ImageUtil.ByteToBitmap(GZipUtil.Decompress(buffer)))
                        {
                            buffer = GZipUtil.Compress(ImageUtil.ResizeBitmapToByte(b, size));
                        }
                    }
                }
                dest.Send(new AdHocDesktop_TcpObject(command, client.Identifier, dest.Identifier, buffer));
                bandwidthOutput += (buffer == null ? 0 : buffer.Length);
            }
        }

        void acceptClient_Error(object sender, string message)
        {
            if (this.IsAccessible)
            {
                AdHocDesktop_AsyncCallback ad = new AdHocDesktop_AsyncCallback(ServerClientErrorCallback);
                this.BeginInvoke(ad, new object[] { message });
            }
        }

        void ServerClientErrorCallback(object obj)
        {
            AppendLog(obj.ToString());
        }

        private void copyLogButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(logTextBox.Text, TextDataFormat.Text);
        }

        private void bandwidthTimer_Tick(object sender, EventArgs e)
        {
            bandwidthInputLabel.Text = (bandwidthInput / 1000.0 / 3.0).ToString("f3");
            bandwidthOutputLabel.Text = (bandwidthOutput / 1000 / 3.0).ToString("f3");
            bandwidthInput = bandwidthOutput = 0;

            onlinePeopleLabel.Text = clientTable.Count.ToString();
            onlineGroupLabel.Text = groupTable.Count.ToString();

            LoggingManager.Add(LogType.OnlinePeopel, clientTable.Count.ToString());
            LoggingManager.Add(LogType.OnlineGroup, groupTable.Count.ToString());
            LoggingManager.Add(LogType.BandwidthInput, bandwidthInputLabel.Text);
            LoggingManager.Add(LogType.BandwidthOutput, bandwidthOutputLabel.Text);
        }
    }
}
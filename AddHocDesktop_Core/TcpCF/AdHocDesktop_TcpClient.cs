using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using AdHocDesktop.Core;

namespace AdHocDesktop.Tcp
{
    public delegate void AdHocDesktop_TcpReceivedEventHandler(object sender, AdHocDesktop_TcpObject obj);    

    public class AdHocDesktop_TcpClient
    {        
        const int DefaultBufferSize = 524288;        

        public event EventHandler Connected;
        public event AdHocDesktop_TcpErrorEventHandler Error;
        public event AdHocDesktop_TcpReceivedEventHandler Received;

        string identifier;
        Thread runThread;
        Thread checkThread;
        Socket client;
        string hostString;
        int port;
        //MemoryStream memoryStream = new MemoryStream();
        NetworkStream iostream;
        bool isConnected = false;

        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        public Socket Socket
        {
            get { return client; }
        }

        public bool IsConnected
        {
            get { return isConnected; }
        }

        internal AdHocDesktop_TcpClient(Socket client)
        {
            this.client = client;
            AdjustBufferSize(DefaultBufferSize);            
        }

        public AdHocDesktop_TcpClient(string hostString, int port)
        {
            this.hostString = hostString;
            this.port = port;
        }

        public void Start()
        {
            if (client == null)
            {
                try
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint hostEndPoint = new IPEndPoint(AdHocDesktop_TcpUtil.ResolveHostStringToIPAddress(hostString), port);
                    client.Connect(hostEndPoint);
                    AdjustBufferSize(DefaultBufferSize);
                    iostream = new NetworkStream(client);
                    isConnected = true;
                    OnConnected();
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                    return;
                }
            }
            else
            {
                isConnected = true;
                iostream = new NetworkStream(client);
            }

            runThread = new Thread(new ThreadStart(ClientThreadHandler));
            runThread.Start();

            checkThread = new Thread(new ThreadStart(PingThreadHandler));
            checkThread.Start();
        }

        void PingThreadHandler()
        {
            AdHocDesktop_TcpObject pingObj = new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.Ping, "", "", new byte[1]); // it just test, so the parameters of src and dest not need.
            while (isConnected)
            {
                this.Send(pingObj);
                Thread.Sleep(5000);
            }
        }

        void AdjustBufferSize(int size)
        {
            //client.ReceiveBufferSize = size;
            //client.SendBufferSize = client.ReceiveBufferSize;
            client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, size);
            client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, size*2);
        }

        public void Stop()
        {
            isConnected = false;
            try
            {
                runThread.Abort();
            }
            catch(Exception)
            {}

            try
            {                
                client.Close();
            }
            catch (Exception)
            { }
        }

        //private ManualResetEvent sendEvent =new ManualResetEvent(false);

        public void Send(AdHocDesktop_TcpObject obj)
        {
            lock (this)
            {
                try
                {
                    /*
                    memoryStream.Position = 0;
                    binary.Serialize(memoryStream, obj);
                    ArraySegment<byte> ab = new ArraySegment<byte>(memoryStream.ToArray());
                    List<ArraySegment<byte>> b = new List<ArraySegment<byte>>();
                    b.Add(ab);
                    client.BeginSend(b, SocketFlags.None, null, null);
                    */
                    //binary.Serialize(iostream, obj);
                    byte[] buffer = obj.Serialize();
                    //iostream.BeginWrite(buffer, 0, buffer.Length, null, null);
                    //iostream.Write(buffer, 0, buffer.Length);
                    //client.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallback), client);
                    //sendEvent.WaitOne();
                    client.Send(buffer);
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                }
            }
        }
        /*
        void SendCallback(IAsyncResult ar)
        {
            try
            {                
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);                

                // Signal that all bytes have been sent.
                sendEvent.Set();
            }
            catch (Exception)
            {                
            }
        }
        */

        void ClientThreadHandler()
        {
            byte[] buffer = null;

            while (true)
            {
                do
                {
                    Thread.Sleep(50);
                } while (client.Available < 6);

                try
                {
                    BinaryReader br = new BinaryReader(iostream);
                    int length = AdHocDesktop_BinaryFormatter.DeserializeInt32(br) - 6; // 1 byte + 1 int + 1 byte

                    buffer = null;

                    if (client.Available < length)
                    {
                        MemoryStream ms = new MemoryStream();
                        while (ms.Length < length)
                        {
                            if (client.Available > 0)
                            {
                                int readLength = ms.Length + client.Available > length ? length - (int)ms.Length : client.Available;
                                buffer = br.ReadBytes(readLength);
                                ms.Write(buffer, 0, buffer.Length);
                            }
                            Thread.Sleep(10);
                        }
                        buffer = ms.ToArray();
                        ms.Close();
                    }
                    else
                    {
                        buffer = br.ReadBytes(length);
                    }
                    AdHocDesktop_TcpObject obj = (AdHocDesktop_TcpObject)AdHocDesktop_BinaryFormatter.DeserializeType(buffer);                    

                    //AdHocDesktop_TcpObject obj = (AdHocDesktop_TcpObject)binary.Deserialize(iostream);
                    OnReceived(obj);
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                }
            }
        }

        void OnConnected()
        {
            if (Connected != null) { Connected(this, EventArgs.Empty); }
        }

        void OnReceived(AdHocDesktop_TcpObject obj)
        {
            if (Received != null)
            {
                Received(this, obj);
            }
        }

        void OnError(string message)
        {
            if (Error != null)
            {
                Error(this, message);
            }
        }


    }
}

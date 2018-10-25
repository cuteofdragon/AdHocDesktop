using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace AdHocDesktop.Tcp
{
    public delegate void AdHocDesktop_TcpReceivedEventHandler(object sender, AdHocDesktop_TcpObject obj);    

    public class AdHocDesktop_TcpClient
    {
        public event EventHandler Connected;
        public event AdHocDesktop_TcpErrorEventHandler Error;
        public event AdHocDesktop_TcpReceivedEventHandler Received;

        Thread runThread;
        Socket client;
        string hostString;
        int port;
        MemoryStream memoryStream = new MemoryStream();
        NetworkStream iostream;
        BinaryFormatter binary = new BinaryFormatter();

        public Socket RawSocket
        {
            get { return client; }
        }

        internal AdHocDesktop_TcpClient(Socket client)
        {
            this.client = client;
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
                    iostream = new NetworkStream(client);
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
                iostream = new NetworkStream(client);
            }
            
            runThread = new Thread(new ThreadStart(ClientThreadHandler));
            runThread.Start();
        }

        public void Stop()
        {
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

        public void Send(AdHocDesktop_TcpObject obj)
        {
            lock(this)
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
                    binary.Serialize(iostream, obj);
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                }
            }
        }

        void ClientThreadHandler()
        {
            while (true)
            {
                do
                {
                    Thread.Sleep(500);
                } while (client.Available == 0);

                try
                {
                    AdHocDesktop_TcpObject obj = (AdHocDesktop_TcpObject)binary.Deserialize(iostream);
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

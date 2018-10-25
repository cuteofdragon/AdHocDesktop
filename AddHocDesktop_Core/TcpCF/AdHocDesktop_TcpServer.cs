using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AdHocDesktop.Tcp
{
    public delegate void AdHocDesktop_TcpServerAcceptClient(AdHocDesktop_TcpClient acceptClient);

    public class AdHocDesktop_TcpServer
    {
        public event AdHocDesktop_TcpErrorEventHandler Error;
        public event AdHocDesktop_TcpServerAcceptClient AcceptClient;
        public event AdHocDesktop_TcpServerAcceptClient DisconnectClient;

        Thread runThread;
        bool isRunning;
        TcpListener server;
        SortedDictionary<string, AdHocDesktop_TcpClient> clientTable = new SortedDictionary<string, AdHocDesktop_TcpClient>();        

        public AdHocDesktop_TcpServer()
        {
            Initialize();
        }

        void Initialize()
        { 
        }

        public SortedDictionary<string, AdHocDesktop_TcpClient> Clients
        {
            get
            {
                return clientTable;
            }
        }

        public AdHocDesktop_TcpClient GetClient(string identifier)
        {
            lock (clientTable)
            {
                return clientTable[identifier];
            }
        }

        public string GetIdentifier(AdHocDesktop_TcpClient client)
        {            
            lock (clientTable)
            {
                foreach (KeyValuePair<string, AdHocDesktop_TcpClient> keyValue in clientTable)
                {
                    if (keyValue.Value.Equals(client))
                    {
                        return keyValue.Key;
                    }
                }
            }
            return null;
        }

        public void Start()
        {
            try
            {
                //server = new TcpListener(AdHocDesktop_TcpUtil.ResolveHostStringToIPAddress(Dns.GetHostName()), AdHocDesktop_TcpUtil.DefaultServerPort);
                server = new TcpListener(IPAddress.Any, AdHocDesktop_TcpUtil.DefaultServerPort);
                server.Start();

                isRunning = true;
                runThread = new Thread(new ThreadStart(ServerThreadHandler));
                runThread.Start();
            }
            catch (Exception e)
            {
                OnError(e.ToString());
            }
        }

        void ServerThreadHandler()
        {

            while (isRunning)
            {
                try
                {
                    Socket connectedClient = server.AcceptSocket();                    
                    AdHocDesktop_TcpClient acceptClient = new AdHocDesktop_TcpClient(connectedClient);
                    //IPEndPoint connectedClientInfo = ((IPEndPoint)connectedClient.RemoteEndPoint);
                    //clientTable[connectedClientInfo.ToString()] = acceptClient;
                    Guid identifier = Guid.NewGuid();
                    acceptClient.Identifier = identifier.ToString();
                    clientTable[identifier.ToString()] = acceptClient;
                    acceptClient.Error += new AdHocDesktop_TcpErrorEventHandler(acceptClient_Error);
                    acceptClient.Start();
                    OnAcceptClient(acceptClient);
                }
                catch (Exception)
                { }
            }
        }

        void acceptClient_Error(object sender, string message)
        {
            AdHocDesktop_TcpClient acceptClient = (AdHocDesktop_TcpClient)sender;
            acceptClient.Error -= new AdHocDesktop_TcpErrorEventHandler(acceptClient_Error);
            OnDisconnectClient(acceptClient);
            acceptClient.Stop();
        } 

        public void Stop()
        {            
            isRunning = false;
            foreach (KeyValuePair<string, AdHocDesktop_TcpClient> kvp in clientTable)
            {
                kvp.Value.Stop();
            }
            server.Stop();
        }

        void OnAcceptClient(AdHocDesktop_TcpClient acceptClient)
        {
            if (AcceptClient != null)
            {
                AcceptClient(acceptClient);
            }
        }

        void OnDisconnectClient(AdHocDesktop_TcpClient disconnectClient)
        {
            if (clientTable.ContainsValue(disconnectClient))
            {
                clientTable.Remove(disconnectClient.Identifier);
            }

            if (DisconnectClient != null)
            {
                DisconnectClient(disconnectClient);
            }
        }

        void OnError(string message)
        {
            if (Error != null) { Error(this, message); }
        }
    }
}

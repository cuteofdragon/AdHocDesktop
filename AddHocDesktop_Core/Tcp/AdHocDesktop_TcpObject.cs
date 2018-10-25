using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Tcp
{
    [Serializable]
    public class AdHocDesktop_TcpObject
    {
        AdHocDesktop_TcpCommand command;
        object data;

        public AdHocDesktop_TcpCommand Command { get { return command; } }
        public object Data { get { return data; } }

        public AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand command, object data)
        {
            this.command = command;
            this.data = data;
        }
    }
}

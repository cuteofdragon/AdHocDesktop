using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Tcp
{
    [Serializable]
    public enum AdHocDesktop_TcpCommand
    {
        RequestConnect,
        ResponseConnect,
        RequestJoin,
        ResponseJoin,
        SyncStreamSample,
    }
}

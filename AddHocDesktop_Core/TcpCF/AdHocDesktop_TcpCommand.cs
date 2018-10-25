using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Tcp
{
    public enum AdHocDesktop_TcpCommand
    {
        Ping,
        EndSession,
        Interrupt,

        RequestIdentifier,
        ResponseIdentifier,
        RequestPeople,
        ResponsePeople,

        BeginInvitation,
        EndInvitation,        

        ProfileScreen,
        ProfileCamera,

        StreamingAdHocDesktop,
        StreamingScreen,
        StreamingAudio,
        StreamingCamera,
        StreamingConference,        
    }
}

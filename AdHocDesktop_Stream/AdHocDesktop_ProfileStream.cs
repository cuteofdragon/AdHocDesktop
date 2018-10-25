using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

using AdHocDesktop.Core;
using AdHocDesktop.Tcp;
using AdHocDesktop.Stream.DirectSound;

namespace AdHocDesktop.Stream
{
    public class AdHocDesktop_ProfileStream
    {
        AdHocDesktop_TcpClient user;
        AdHocDesktop_ProfileJoin join;

        public AdHocDesktop_TcpClient User { get { return user; } }
        public AdHocDesktop_ProfileJoin Join { get { return join; } }

        public AdHocDesktop_ProfileStream(AdHocDesktop_TcpClient user, AdHocDesktop_ProfileJoin join)
        {
            this.user = user;
            this.join = join;
        }
    }
}
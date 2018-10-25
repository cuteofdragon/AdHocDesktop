using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Core
{
    [Serializable]
    public abstract class AdHocDesktop_ProfileBase
    {
        // Serializable object cannot null.
        string src = "";
        string dest = "";

        public string Src { get { return src; } }
        public string Dest { get { return dest; } }

        public AdHocDesktop_ProfileBase()
        {
        }

        public AdHocDesktop_ProfileBase(string src, string dest)
        {
            this.src = src;
            this.dest = dest;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Core
{
    [Serializable]
    public class AdHocDesktop_ProfileJoin : AdHocDesktop_ProfileBase
    {
        string title;
        string message;
        bool accept;        

        public string Title { get { return title; } }
        public string Message { get { return message; } }
        public bool Accept { get { return accept; } set { accept = value; } }

        public AdHocDesktop_ProfileJoin(string src, string dest, string title, string message):
            base(src, dest)
        {
            this.title = title;
            this.message = message;
        }
    }

}

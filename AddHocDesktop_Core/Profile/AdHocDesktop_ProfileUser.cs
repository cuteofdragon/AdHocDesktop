using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Core
{
    [Serializable]
    public class AdHocDesktop_ProfileUser : AdHocDesktop_ProfileBase
    {
        string identifier;
        string id;
        string pw;
        string group;
        AdHocDesktop_ProfileUserState state;

        public string Identifier { get { return identifier; } set { identifier = value; } }
        public string AccountID { get { return id; } }
        public string AccountPW { get { return pw; } }
        public string Group { get { return group; } set { group = value; } }
        public AdHocDesktop_ProfileUserState State { get { return state; } set { state = value; } }

        public AdHocDesktop_ProfileUser(string id, string pw)
        {
            this.id = id;
            this.pw = StringUtil.ComputeMD5(pw);
            group = identifier;
        }
    }

    public enum AdHocDesktop_ProfileUserState
    {
        Undefined,
        Activate,
        Expired,
    }
}

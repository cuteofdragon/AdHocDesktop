using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Core
{
    public class AdHocDesktop_ProfileUser : AdHocDesktop_ProfileBase
    {        
        string id = "";
        string pw = "";
        string group = "";
        AdHocDesktop_ProfileUserState state = AdHocDesktop_ProfileUserState.Undefined;
        
        public string AccountID { get { return id; } }
        public string AccountPW { get { return pw; } }
        public string Group { get { return group; } set { group = value; } }
        public AdHocDesktop_ProfileUserState State { get { return state; } set { state = value; } }        

        public AdHocDesktop_ProfileUser()
        {
        }

        public AdHocDesktop_ProfileUser(string id, string pw)
        {
            this.id = id;
            this.pw = StringUtil.ComputeMD5(pw);            
        }

        public override byte[] Serialize()
        {
            base.Serialize();
            
            AdHocDesktop_BinaryFormatter.SerializeString(bw, id);
            AdHocDesktop_BinaryFormatter.SerializeString(bw, pw);
            AdHocDesktop_BinaryFormatter.SerializeString(bw, group);
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)state);            

            AdHocDesktop_BinaryFormatter.SerializeType(bw, AdHocDesktop_SerializeType.AdHocDesktop_ProfileUser);
            ms.Position = 0;
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)ms.Length);
            byte[] result = ms.ToArray();
            ms.Close();
            return result;
        }

        public override void Deserialize(byte[] data)
        {
            base.Deserialize(data);
            
            id = AdHocDesktop_BinaryFormatter.DeserializeString(br);
            pw = AdHocDesktop_BinaryFormatter.DeserializeString(br);
            group = AdHocDesktop_BinaryFormatter.DeserializeString(br);
            state = (AdHocDesktop_ProfileUserState)AdHocDesktop_BinaryFormatter.DeserializeInt32(br);            
            ms.Close();
        }
    }

    public enum AdHocDesktop_ProfileUserState
    {
        Undefined,
        Activate,
        Expired,
    }
}

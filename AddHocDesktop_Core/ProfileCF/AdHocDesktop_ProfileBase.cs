using System;
using System.Text;
using System.IO;

namespace AdHocDesktop.Core
{
    public abstract class AdHocDesktop_ProfileBase : IAdHocDesktop_Serializable
    {        
        string src = "";
        string dest = "";
        AdHocDesktop_ProfilePlatform platform = AdHocDesktop_ProfilePlatform.WINNT;
        AdHocDesktop_ProfileCommand command = AdHocDesktop_ProfileCommand.None;

        public string Src { get { return src; } set { src = value; } } // because of setter src is to deal with NAT state.
        public string Dest { get { return dest; } set { dest = value; } } // because of setter dest is to deal with two way AdhocDesktop.
        public AdHocDesktop_ProfilePlatform Platform { get { return platform; } }
        public AdHocDesktop_ProfileCommand Command { get { return command; } set { command = value; } }

        public AdHocDesktop_ProfileBase()
        {
        }

        public AdHocDesktop_ProfileBase(string src, string dest)
        {
            this.src = src;
            this.dest = dest;
        }
        
        #region IAdHocDesktop_Serializable Members

        protected MemoryStream ms;
        protected BinaryWriter bw;
        protected BinaryReader br;

        public virtual byte[] Serialize()
        {
            ms = new MemoryStream();
            bw = new BinaryWriter(ms);

            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, 0);            
            AdHocDesktop_BinaryFormatter.SerializeString(bw, src);
            AdHocDesktop_BinaryFormatter.SerializeString(bw, dest);
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)platform);
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)command);
            
            return null;
        }
       

        public virtual void Deserialize(byte[] data)
        {
            ms = new MemoryStream(data);
            br = new BinaryReader(ms);

            int length = AdHocDesktop_BinaryFormatter.DeserializeInt32(br);            
            src = AdHocDesktop_BinaryFormatter.DeserializeString(br);
            dest = AdHocDesktop_BinaryFormatter.DeserializeString(br);
            platform = (AdHocDesktop_ProfilePlatform)AdHocDesktop_BinaryFormatter.DeserializeInt32(br);
            command = (AdHocDesktop_ProfileCommand)AdHocDesktop_BinaryFormatter.DeserializeInt32(br);
        }

        #endregion
        
    }

    public enum AdHocDesktop_ProfilePlatform
    {
        WINNT,
        WINCE,
    }

}

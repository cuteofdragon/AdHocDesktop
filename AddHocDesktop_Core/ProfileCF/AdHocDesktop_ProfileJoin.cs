using System;
using System.Text;
using System.IO;

namespace AdHocDesktop.Core
{    
    public class AdHocDesktop_ProfileJoin : AdHocDesktop_ProfileBase
    {
        string title;
        string message;
        bool accept;        

        public string Title { get { return title; } }
        public string Message { get { return message; } }
        public bool Accept { get { return accept; } set { accept = value; } }

        public AdHocDesktop_ProfileJoin()
        { }

        public AdHocDesktop_ProfileJoin(string src, string dest, string title, string message):
            base(src, dest)
        {
            this.title = title;
            this.message = message;
        }

        public override byte[] Serialize()
        {
            base.Serialize();
            
            AdHocDesktop_BinaryFormatter.SerializeString(bw, title);
            AdHocDesktop_BinaryFormatter.SerializeString(bw, message);
            AdHocDesktop_BinaryFormatter.SerializeBoolean(bw, accept);

            AdHocDesktop_BinaryFormatter.SerializeType(bw, AdHocDesktop_SerializeType.AdHocDesktop_ProfileJoin);
            ms.Position = 0;
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)ms.Length);
            byte[] result = ms.ToArray();            
            ms.Close();
            return result;
        }

        public override void Deserialize(byte[] data)
        {
            base.Deserialize(data);

            title = AdHocDesktop_BinaryFormatter.DeserializeString(br);
            message = AdHocDesktop_BinaryFormatter.DeserializeString(br);
            accept = AdHocDesktop_BinaryFormatter.DeserializeBoolean(br);
            ms.Close();
        }
    }

}

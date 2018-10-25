using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

using AdHocDesktop.Core;

namespace AdHocDesktop.Tcp
{
    public class AdHocDesktop_TcpObject : IAdHocDesktop_Serializable
    {
        AdHocDesktop_TcpCommand command;
        string src = "";
        string dest = "";
        object[] data;

        public AdHocDesktop_TcpCommand Command { get { return command; } }
        public object[] Data { get { return data; } }
        public string Src { get { return src; } }
        public string Dest { get { return dest; } }        

        public AdHocDesktop_TcpObject()
        {
        }

        public AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand command, string src, string dest, params object[] data)
        {
            this.command = command;
            this.data = data;
            this.src = src;
            this.dest = dest;
        }

        #region IAdHocDesktop_Serializable Members

        MemoryStream ms;
        BinaryWriter bw;
        BinaryReader br;

        public virtual byte[] Serialize()
        {
            ms = new MemoryStream();
            bw = new BinaryWriter(ms);

            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)0);
            AdHocDesktop_BinaryFormatter.Serialize(bw, (int)command);
            AdHocDesktop_BinaryFormatter.Serialize(bw, src);
            AdHocDesktop_BinaryFormatter.Serialize(bw, dest);
            foreach (object obj in data)
            {
                AdHocDesktop_BinaryFormatter.Serialize(bw, obj);
            }
            AdHocDesktop_BinaryFormatter.Serialize(bw, AdHocDesktop_SerializeType.AdHocDesktop_TcpObject);

            ms.Position = 0;
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)ms.Length);
            byte[] result = ms.ToArray();
            bw.Close();
            ms.Close();
            return result;
        }       

        public virtual void Deserialize(byte[] data)
        {
            ms = new MemoryStream(data);
            br = new BinaryReader(ms);

            //int length = AdHocDesktop_BinaryFormatter.Deserialize(br);
            object[] objs = AdHocDesktop_BinaryFormatter.Deserialize(br);
            command = (AdHocDesktop_TcpCommand)objs[0];
            src = (string)objs[1];
            dest = (string)objs[2];
            ArrayList al = new ArrayList();
            for (int i = 3; i < objs.Length - 1; i++) // objs[objs.Length-1] = AdHocDesktop_SerializeType.AdHocDesktop_TcpObject
            {
                al.Add(objs[i]);
            }
            this.data = al.ToArray();
            br.Close();
            ms.Close();
        }

        #endregion
    }
}

using System;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Reflection;

using AdHocDesktop.Tcp;

namespace AdHocDesktop.Core
{        
    public class AdHocDesktop_BinaryFormatter
    {
        static ASCIIEncoding ascii = new ASCIIEncoding();

        public static void SerializeType(BinaryWriter bw, AdHocDesktop_SerializeType data)
        {
            bw.Write(((int)data));
            bw.Write(((byte)255));
        }

        public static void SerializeString(BinaryWriter bw, string data)
        {
            byte[] temp;
            temp = ascii.GetBytes(data);
            bw.Write(temp.Length);
            bw.Write(temp);
            bw.Write(((byte)255));
        }

        public static void SerializeInt16(BinaryWriter bw, short data)
        {
            bw.Write(((byte)2));
            bw.Write(data);
            bw.Write(((byte)255));
        }

        public static void SerializeInt32(BinaryWriter bw, int data)
        {
            bw.Write(((byte)4));
            bw.Write(data);
            bw.Write(((byte)255));
        }

        public static void SerializeInt64(BinaryWriter bw, long data)
        {
            bw.Write(((byte)8));
            bw.Write(data);
            bw.Write(((byte)255));
        }

        public static void SerializeBoolean(BinaryWriter bw, bool data)
        {
            bw.Write(((byte)1));
            bw.Write(((byte)(data ? (byte)1 : (byte)0)));
            bw.Write(((byte)255));
        }

        public static void SerializeSize(BinaryWriter bw, Size data)
        {
            SerializeInt32(bw, data.Width);
            SerializeInt32(bw, data.Height);
        }

        public static void SerializeBytes(BinaryWriter bw, byte[] data)
        {
            bw.Write(((int)data.Length));
            bw.Write(data);
            bw.Write(((byte)255));
        }

        public static string DeserializeString(BinaryReader br)
        {
            byte[] temp;
            int length = br.ReadInt32();

            temp = br.ReadBytes(length);
            string result = ascii.GetString(temp);
            br.ReadByte();

            return result;
        }

        public static short DeserializeInt16(BinaryReader br)
        {
            br.ReadByte();
            short result = br.ReadInt16();
            br.ReadByte();

            return result;
        }

        public static int DeserializeInt32(BinaryReader br)
        {            
            br.ReadByte();
            int result = br.ReadInt32();
            br.ReadByte();

            return result;
        }

        public static long DeserializeInt64(BinaryReader br)
        {
            br.ReadByte();
            long result = br.ReadInt64();
            br.ReadByte();

            return result;
        }

        public static Size DeserializeSize(BinaryReader br)
        {
            Size result = Size.Empty;
            result.Width = DeserializeInt32(br);
            result.Height = DeserializeInt32(br);

            return result;
        }

        public static bool DeserializeBoolean(BinaryReader br)
        {
            br.ReadByte();
            bool result = br.ReadByte() == (byte)1 ? true : false;
            br.ReadByte();

            return result;
        }

        public static byte[] DeserializeBytes(BinaryReader br)
        {            
            int length = br.ReadInt32();

            byte[] result = br.ReadBytes(length);                        
            br.ReadByte();

            return result;
        }

        public static object DeserializeType(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            BinaryReader br = new BinaryReader(ms);
            br.BaseStream.Position = br.BaseStream.Length - 5; // 1 byte + 1 int
            AdHocDesktop_SerializeType type = (AdHocDesktop_SerializeType)br.ReadInt32();

            object result = null;
            switch (type)
            {
                case AdHocDesktop_SerializeType.AdHocDesktop_TcpObject:
                    result = new AdHocDesktop_TcpObject();
                    ((IAdHocDesktop_Serializable)result).Deserialize(data);
                    break;
            }            
            
            return result;
        }

        internal enum AdHocDesktop_SerializeBaseType : short
        {
            String,
            Int32,
            Int64,
            Boolean,
            Size,
            Bytes,            
        }

        public static void Serialize(BinaryWriter bw, params object[] objs)
        { 
            Type type = Type.Missing.GetType();
            foreach (object obj in objs)
            {
                type = obj.GetType();
                if (type.BaseType == typeof(Enum))  { SerializeInt16(bw, (short)AdHocDesktop_SerializeBaseType.Int32);    SerializeInt32(bw, (Int32)obj); }
                else if (type == typeof(string))    { SerializeInt16(bw, (short)AdHocDesktop_SerializeBaseType.String);   SerializeString(bw, obj.ToString()); }
                else if (type == typeof(Int32))     { SerializeInt16(bw, (short)AdHocDesktop_SerializeBaseType.Int32);    SerializeInt32(bw, (Int32)obj); }
                else if (type == typeof(Int64))     { SerializeInt16(bw, (short)AdHocDesktop_SerializeBaseType.Int64);    SerializeInt64(bw, (Int64)obj); }
                else if (type == typeof(bool))      { SerializeInt16(bw, (short)AdHocDesktop_SerializeBaseType.Boolean);  SerializeBoolean(bw, (bool)obj); }
                else if (type == typeof(Size))      { SerializeInt16(bw, (short)AdHocDesktop_SerializeBaseType.Size);     SerializeSize(bw, (Size)obj); }
                else if (type == typeof(byte[]))    { SerializeInt16(bw, (short)AdHocDesktop_SerializeBaseType.Bytes);    SerializeBytes(bw, (byte[])obj); }                    
                else
                {
                    throw new ArgumentException("AdHocDesktop_BinaryFormatter Serialize() invalid type.");
                }
            }
        }

        public static object[] Deserialize(BinaryReader br)
        {
            short type = 0;
            ArrayList result = new ArrayList();            
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                type = DeserializeInt16(br);
                if(type == (short)AdHocDesktop_SerializeBaseType.String)        { result.Add(DeserializeString(br)); }
                else if (type == (short)AdHocDesktop_SerializeBaseType.Int32)   { result.Add(DeserializeInt32(br)); }
                else if (type == (short)AdHocDesktop_SerializeBaseType.Int64)   { result.Add(DeserializeInt64(br)); }
                else if (type == (short)AdHocDesktop_SerializeBaseType.Boolean) { result.Add(DeserializeBoolean(br)); }
                else if (type == (short)AdHocDesktop_SerializeBaseType.Size)    { result.Add(DeserializeSize(br)); }
                else if (type == (short)AdHocDesktop_SerializeBaseType.Bytes)   { result.Add(DeserializeBytes(br)); }
                else
                {
                    throw new ArgumentException("AdHocDesktop_BinaryFormatter Deserialize() invalid TypeInfo.");
                }
            }
            return result.ToArray();
        }

        /*
        ASCIIEncoding ascii = new ASCIIEncoding();

        public void Serialize(Stream stream, object obj)
        {
            BinaryWriter bw = new BinaryWriter(stream);
            FieldInfo[] fields = obj.GetType().GetFields();
            SerializeFields(bw, obj, fields);            
        }        

        void SerializeFields(BinaryWriter bw, object obj, FieldInfo[] fields)
        {
            SerializeField(bw, obj);
            
            foreach (FieldInfo field in fields)
            {
                if (field.IsPrivate)
                {
                    SerializeField(bw, field.GetValue(obj));
                }                    
            }
        }

        void SerializeField(BinaryWriter bw, object fieldObj)
        {
            byte[] temp;
            
            Type type = fieldObj.GetType();
            if (type == typeof(string))
            {
                temp = ascii.GetBytes(fieldObj.ToString());
                bw.Write(temp.Length);
                bw.Write(temp);
            }
            else if (type == typeof(Int32))
            {
                bw.Write(((int)4));
                bw.Write((int)fieldObj);
            }
            else if (type == typeof(Enum))
            {
                bw.Write((int)4);
                bw.Write((int)fieldObj);
            }
            else if(type == 
            else
            {                
                FieldInfo[] fields = fieldObj.GetType().GetFields();
                SerializeFields(bw, fieldObj, fields);
            }

            bw.Write(((byte)255));
        }   


        public object Deserialize(BinaryReader br)
        {
            return null;
        }
         */
    }

}

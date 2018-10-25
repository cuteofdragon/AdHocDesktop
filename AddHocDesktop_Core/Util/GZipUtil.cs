using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using AdHocDesktop.SharpZipLib.GZip;

namespace AdHocDesktop.Core
{
    public class GZipUtil
    {       

        public static byte[] Compress(byte[] buffer)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                GZipOutputStream outStream = new GZipOutputStream(ms);

                outStream.Write(buffer, 0, buffer.Length);
                outStream.Flush();
                outStream.Finish();

                return ms.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static byte[] Decompress(byte[] buffer)
        {
            try
            {
                MemoryStream inms = new MemoryStream(buffer);
                GZipInputStream inStream = new GZipInputStream(inms);
                MemoryStream outms = new MemoryStream();
                byte[] b = new byte[4096];
                int pos = 0;
                while (true)
                {
                    int numRead = inStream.Read(b, 0, 4096);                    
                    if (numRead <= 0)
                    {
                        break;
                    }
                    else
                    {
                        outms.Write(b, 0, numRead);
                    }
                    pos += numRead;
                }
                inStream.Close();
                return outms.ToArray();                
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

}

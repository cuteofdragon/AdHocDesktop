using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace AdHocDesktop.Core
{
    public class ImageUtil
    {
        public static byte[] CreateBitmapHeader(int width, int height, PixelFormat pixelFormat)
        {
            Bitmap b = new Bitmap(width, height, pixelFormat);
            MemoryStream ms = new MemoryStream();
            b.Save(ms, ImageFormat.Bmp);
            b.Dispose();
            byte[] result = new byte[54];
            Array.Copy(ms.ToArray(), result, 54);
            ms.Close();

            string bitmapHeaderBase64String = Convert.ToBase64String(result);

            return result;
        }

        public static byte[] ByteBitmapToJpeg(byte[] buffer, int width, int height, int stride, PixelFormat pixelFormat)
        {            
            Bitmap b = ByteToBitmap(buffer, width, height, stride, pixelFormat);         
            MemoryStream ms = new MemoryStream();
            b.Save(ms, ImageFormat.Jpeg);            
            b.Dispose();
            return ms.ToArray();
        }

        public static byte[] BitmapToJpegByte(Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, ImageFormat.Jpeg);
            b.Dispose();
            return ms.ToArray();
        }

        public static byte[] ResizeBitmapToJpegByte(Bitmap b, Size size)
        {
            using (Bitmap rb = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics g = Graphics.FromImage(rb))
                {
                    g.DrawImage(b, new Rectangle(new Point(0, 0), size), new Rectangle(new Point(0, 0), b.Size), GraphicsUnit.Pixel);
                }
                return BitmapToJpegByte(rb);
            }
        }

        public static byte[] ResizeBitmapToByte(Bitmap b, Size size)
        {
            using (Bitmap rb = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics g = Graphics.FromImage(rb))
                {
                    g.DrawImage(b, new Rectangle(new Point(0, 0), size), new Rectangle(new Point(0, 0), b.Size), GraphicsUnit.Pixel);
                }
                return BitmapToByte(rb);
            }
        }

        public static Bitmap ResizeBitmap(Bitmap b, Size size)
        {
            using (Bitmap rb = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics g = Graphics.FromImage(rb))
                {
                    g.DrawImage(b, new Rectangle(new Point(0, 0), size), new Rectangle(new Point(0, 0), b.Size), GraphicsUnit.Pixel);
                }
                return rb;
            }
        }

        public static Bitmap ByteToBitmap(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Bitmap b = new Bitmap(ms);
            ms.Close();
            return b;
        }

        public static Bitmap ByteToBitmap(byte[] buffer, int width, int height, int stride, PixelFormat pixelFormat)
        {
            GCHandle gHan = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            IntPtr ptr = gHan.AddrOfPinnedObject();
            Marshal.Copy(buffer, 0, ptr, buffer.Length);
            Bitmap b = new Bitmap(width, height, stride, pixelFormat, ptr);
            gHan.Free();
            return b;
        }

        public static byte[] BitmapToByte(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            //bitmap.Save(ms, ImageFormat.Png);

            return ms.ToArray();

            /*
            int skip = 54; // BMP Header
            //int skip = 108; // PNG Header
            byte[] buffer = new byte[ms.Length - skip];
            ms.Seek(skip, SeekOrigin.Begin);
            ms.Read(buffer, 0, buffer.Length);
            ms.Close();
            return buffer;
             */
        }

        public static byte[] BitmapToByteEx(Bitmap bitmap)
        {
            Rectangle r = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmd = null;

            byte[] buffer = null;
            int index = 0;

            try
            {
                // Lock the bitmap, which gets us a pointer to the bitmap data
                bmd = bitmap.LockBits(r, ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int size = bmd.Stride * bmd.Height;
                buffer = new byte[size];

                if (bmd.Stride < 0)
                {
                    //CopyMemory(ip, bmd.Scan0, size);
                    Marshal.Copy(bmd.Scan0, buffer, 0, buffer.Length);
                }
                else
                {
                    // Copy it line by line from bottom to top
                    index = size - bmd.Stride;
                    for (int x = 0; x < bmd.Height; x++)
                    {
                        Marshal.Copy((IntPtr)(bmd.Scan0.ToInt32() + (bmd.Stride * x)), buffer, index, bmd.Stride);
                        index -= bmd.Stride;
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                bitmap.UnlockBits(bmd);
            }
            return buffer;
        }

        public static Bitmap Reverse(Bitmap bitmap)
        {
            Rectangle r = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmd = null;

            Bitmap result = null;
            IntPtr ip = IntPtr.Zero;
            GCHandle gan = GCHandle.Alloc(IntPtr.Zero, GCHandleType.Weak);
            byte[] buffer = null;
            int index = 0;

            try
            {
                bmd = bitmap.LockBits(r, ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int size = bmd.Stride * bmd.Height;
                buffer = new byte[size];

                if (bmd.Stride < 0)
                {
                    Marshal.Copy(bmd.Scan0, buffer, 0, buffer.Length);
                }
                else
                {
                    index = size - bmd.Stride;
                    for (int x = 0; x < bmd.Height; x++)
                    {
                        Marshal.Copy((IntPtr)(bmd.Scan0.ToInt32() + (bmd.Stride * x)), buffer, index, bmd.Stride);
                        index -= bmd.Stride;
                    }

                }
                gan = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                ip = gan.AddrOfPinnedObject();
                //Marshal.Copy(buffer, 0, ip, buffer.Length);
                result = new Bitmap(r.Width, r.Height, bmd.Stride, bitmap.PixelFormat, ip);
            }
            catch (Exception)
            {
            }
            finally
            {

                if (gan.IsAllocated)
                {
                    gan.Free();
                }

                ip = IntPtr.Zero;
                buffer = null;
                bitmap.UnlockBits(bmd); ;
                /*
                bitmap.Dispose();
                bitmap = null;
                */
            }
            return result;
        }

        public static Bitmap AnyBitmapToBitmap24(Bitmap bitmap)
        {
            Bitmap b = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(b);
            g.DrawImage(bitmap, new Rectangle(new Point(0, 0), bitmap.Size));
            g.Dispose();

            return b;
        }

        public static byte[] RecompareImage(byte[] previous, byte[] current)
        {
            if (previous.Length == current.Length)
            {
                byte[] newBuffer = new byte[previous.Length];

                for (int i = 0; i < previous.Length; i++)
                {
                    newBuffer[i] = previous[i];
                    if (current[i] != 0)
                    {
                        newBuffer[i] = current[i];
                    }
                }
                return newBuffer;
            }
            else
            {
                throw new ArgumentException("previous 和 current 陣列長度必需相同才可以進行比對。");
            }
        }

        public static byte[] CompareImage(byte[] previous, byte[] current)
        {
            if (previous.Length == current.Length)
            {                
                byte[] newBuffer = new byte[previous.Length];

                Array.Copy(previous, newBuffer, 54);

                for (int i = 54; i < previous.Length; i++)
                {
                    previous[i] = previous[i] == 0 ? (byte)1 : previous[i];
                    current[i] = current[i] == 0 ? (byte)1 : current[i];

                    if (previous[i] == current[i])
                    {
                        newBuffer[i] = 0;                                                
                    }
                    else
                    {
                        newBuffer[i] = current[i];                        
                    }
                }
                return newBuffer;
            }
            else
            {
                throw new ArgumentException("previous 和 current 陣列長度必需相同才可以進行比對。");
            }
        }

        struct RGBType
        {
            public float R; //0~255
            public float G; //0~255
            public float B; //0~255
        }

        struct HSVType
        {
            public float H; //0~6
            public float S; //0,1
            public float V; //0,1
        }

        public static byte[] TransformHSV(byte[] rgbBuffer)
        {
            byte[] hsvBuffer = new byte[rgbBuffer.Length];
            // BMP header length = 54
            for (int i = 54; i < rgbBuffer.Length; i+=3)
            {
                RGBType rgb;
                rgb.B = rgbBuffer[i];
                rgb.G = rgbBuffer[i + 1];
                rgb.R = rgbBuffer[i + 2];

                HSVType hsv = RGB_To_HSV(rgb);
                HSV_Quantize(ref hsv);

                rgb = HSV_To_RGB(hsv);
                hsvBuffer[i] = (byte)Math.Round(rgb.B);
                hsvBuffer[i + 1] = (byte)Math.Round(rgb.G);
                hsvBuffer[i + 2] = (byte)Math.Round(rgb.R);
            }
            return hsvBuffer;
        }

        static HSVType RGB_To_HSV(RGBType rgb)
        {
            float r = (float)rgb.R / 255;
            float g = (float)rgb.G / 255;
            float b = (float)rgb.B / 255;
            float v, x, f;

            HSVType hsv;
            int i;

            x = Math.Min(r, Math.Min(g, b));
            v = Math.Max(r, Math.Max(g, b));

            if (v == x)
            {
                hsv.H = -1;
                hsv.S = 0;
                hsv.V = v;
                return hsv;
            }

            f = (r == x) ? g - b : ((g == x) ? b - r : r - g);
            i = (r == x) ? 3 : ((g == x) ? 5 : 1);

            hsv.H = i - f / (v - x);
            hsv.S = (v - x) / v;
            hsv.V = v;
            return hsv;
        }

        static RGBType HSV_To_RGB(HSVType hsv)
        {
            float h = (float)hsv.H;
            float s = (float)hsv.S;
            float v = (float)hsv.V;
            float m, n, f;

            RGBType rgb;
            rgb.R = rgb.G = rgb.B = 0; // initial
            int i;

            if (h == -1)
            {
                rgb.R = rgb.G = rgb.B = v;
            }

            i = (int)Math.Floor(h);
            f = h - i;

            //if (!(i & 1))
            if(i % 2 == 0)
            {// if i is even
                f = 1 - f;
            }

            m = v * (1 - s);
            n = v * (1 - s * f);

            switch (i)
            {
                case 6:
                case 0:
                    rgb.R = v;
                    rgb.G = n;
                    rgb.B = m;
                    break;
                case 1:
                    rgb.R = n;
                    rgb.G = v;
                    rgb.B = m;
                    break;
                case 2:
                    rgb.R = m;
                    rgb.G = v;
                    rgb.B = n;
                    break;
                case 3:
                    rgb.R = m;
                    rgb.G = n;
                    rgb.B = v;
                    break;
                case 4:
                    rgb.R = n;
                    rgb.G = m;
                    rgb.B = v;
                    break;
                case 5:
                    rgb.R = v;
                    rgb.G = m;
                    rgb.B = n;
                    break;
            }
            rgb.R *= 255;
            rgb.G *= 255;
            rgb.B *= 255;
            return rgb;
        }

        static void HSV_Quantize(ref HSVType hsv)
        {
            //hsv.H = (float)((int)((hsv.H * 60.0) / 10.0) / 6.0);
            hsv.H = (float)((int)((hsv.H * 60.0) / 20.0) / 3.0);
        }
    }
}

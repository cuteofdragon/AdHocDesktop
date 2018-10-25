using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AdHocDesktop.Core
{
    public class ScreenUtil
    {
        public static byte[] CaptureRectangle(Rectangle r)
        {
            IntPtr wndHWND, wndHDC, capHDC, capBMP, prvHDC;
            wndHWND = wndHDC = capHDC = capBMP = prvHDC = IntPtr.Zero;
            byte[] buffer = null;
            Point cursorPos = Point.Empty;
            try
            {
                wndHWND = NativeMethod.GetDesktopWindow();	// window handle for desktop

                int x, y, width, height;
                x = r.X;
                y = r.Y;
                width = r.Width;
                height = r.Height;

                wndHDC = NativeMethod.GetDC(wndHWND);		// get context for window 

                //	create compatibile capture context and bitmap
                capHDC = NativeMethod.CreateCompatibleDC(wndHDC);
                capBMP = NativeMethod.CreateCompatibleBitmap(wndHDC, width, height);

                //	make sure bitmap non-zero
                if (capBMP == IntPtr.Zero)				// if no compatible bitmap
                {
                    NativeMethod.ReleaseDC(wndHWND, wndHDC);			//   release window context
                    NativeMethod.DeleteDC(capHDC);					//   delete capture context
                    throw new Exception("Not create compatible bitmap.");
                }

                //	select compatible bitmap in compatible context
                //	copy window context to compatible context
                //  select previous bitmap back into compatible context
                prvHDC = (IntPtr)NativeMethod.SelectObject(capHDC, capBMP);
                //NativeMethod.BitBlt(capHDC, 0, 0, width, height, wndHDC, x, y, RasterOp.SRCCOPY | RasterOp.CAPTUREBLT);
                NativeMethod.BitBlt(capHDC, 0, 0, width, height, wndHDC, x, y, RasterOp.SRCCOPY);

                NativeMethod.GetCursorPos(out cursorPos);
                cursorPos.X -= r.Left;
                cursorPos.Y -= r.Top;                                                  

                // Draw the cursor			
                // Always wait cursor, why? So use arrow cursor forever.
                //IntPtr hcur = GetCursor();
                IntPtr hcur = NativeMethod.GetCurrentCursorHandle();                

                IconInfo iconInfo = new IconInfo();
                int hr = NativeMethod.GetIconInfo(hcur, out iconInfo);
                if (hr != 0)
                {
                    cursorPos.X -= iconInfo.xHotspot;
                    cursorPos.Y -= iconInfo.yHotspot;
                    if (iconInfo.hbmMask != IntPtr.Zero) NativeMethod.DeleteObject(iconInfo.hbmMask);
                    if (iconInfo.hbmColor != IntPtr.Zero) NativeMethod.DeleteObject(iconInfo.hbmColor);
                }
                NativeMethod.DrawIcon(capHDC, cursorPos.X, cursorPos.Y, hcur);                

                NativeMethod.SelectObject(capHDC, prvHDC);

                //	create GDI+ bitmap for window
                Bitmap bitmap = Image.FromHbitmap(capBMP);
                               
                Bitmap b = ImageUtil.AnyBitmapToBitmap24(bitmap);
                bitmap.Dispose();
                bitmap = b;                

                buffer = ImageUtil.BitmapToByte(bitmap);
                //buffer = ImageUtil.BitmapToByteEx(bitmap);
                bitmap.Dispose();
            }
            catch (Exception)
            {

            }
            finally
            {
                //	release window and capture resources
                NativeMethod.DeleteObject(capBMP);					// delete capture bitmap
                NativeMethod.DeleteDC(capHDC);						// delete capture context
                NativeMethod.ReleaseDC(wndHWND, wndHDC);			// release window context
            }
            return buffer;
        }

       
    }

}

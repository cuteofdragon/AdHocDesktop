/* <file>
 * <copyright see="prj:///doc/copyright.rtf"/>
 * <license see="prj:///doc/license.rtf"/>
 * <owner name="¥i·RÀs" email="cute.ofdragon@gmail.com"/>
 * <version value="$version"/>
 * <comment>  
 * </comment>
 * </file>
 */
using System;
using System.Drawing;

namespace Microsoft.DirectX.VideoGrabber
{
	public delegate void VideoGrabberBufferDataEventHandler(object sender, VideoGrabberBufferDataEventArgs e);

	public class VideoGrabberBufferDataEventArgs : EventArgs
	{
		byte[] buffer;
		Size size = Size.Empty;        
        Bitmap bitmap;
		
		public byte[] Buffer
		{
			get
			{
				return buffer;
			}
		}

		public Size Size
		{
			get
			{
				return size;
			}
		}
		
		public Bitmap Bitmap
		{
			get
			{
				return bitmap;
			}
		}

        public VideoGrabberBufferDataEventArgs(Bitmap bitmap)
		{
			this.bitmap = bitmap;
		}

		public VideoGrabberBufferDataEventArgs(byte[] buffer, int w, int h)
		{
			this.buffer = buffer;
			this.size = new Size(w, h);
		}
	}
}

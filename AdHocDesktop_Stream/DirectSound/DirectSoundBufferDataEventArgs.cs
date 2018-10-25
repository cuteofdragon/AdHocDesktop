using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AdHocDesktop.Stream.DirectSound
{
	public delegate void DirectSoundBufferDataEventHandler(object sender, DirectSoundBufferDataEventArgs e);

	public class DirectSoundBufferDataEventArgs : EventArgs
	{
		byte[] data;

		public byte[] Data
		{
			get
			{
				return data;
			}
		}

		public DirectSoundBufferDataEventArgs(byte[] data)
		{
			this.data = data;
		}
	}
}

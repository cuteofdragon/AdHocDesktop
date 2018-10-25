//----------------------------------------------------------------------------
// File: Formats.cs
//
// Copyright (c) Microsoft Corp. All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

using Microsoft.DirectX.DirectSound;

namespace AdHocDesktop.Stream.DirectSound
{
	public class WaveFormatSelector : Form
	{
		private struct WaveFormatInfo
		{
			public WaveFormat format;
			public override string ToString()
			{
				return ConvertWaveFormatToString(format);
			}
		}

		private Button buttonOk;
		private Button buttonCancel;
		private ListBox lbFormatsInputListbox;
		private Label labelStatic;

		private ArrayList	formats = new ArrayList();
		private bool[]		InputFormatSupported = new bool[20];

		WaveFormat selectedFormat;
		Capture device;

		public WaveFormat SelectedFormat
		{
			get
			{
				return selectedFormat;
			}
		}

		/// <summary>
		/// Get the default format (44100 hz, 16 bits, 2 channels), if 
		/// default format is not capable of selected device, than throw exception.
		/// </summary>
		public WaveFormat DefaultFormat
		{
			get
			{
                return DirectSoundManager.DefaultFormat;
            }
        }

        WaveFormat TryNewFormat(int hz, short bits, short channels)
        {
            WaveFormat format = new WaveFormat();
            format.FormatTag = WaveFormatTag.Pcm;
            format.SamplesPerSecond = hz;
            format.BitsPerSample = bits;
            format.Channels = channels;
            format.BlockAlign = (short)(format.Channels * (format.BitsPerSample / 8));
            format.AverageBytesPerSecond = format.BlockAlign * format.SamplesPerSecond;

            CaptureBufferDescription dscheckboxd = new CaptureBufferDescription();
            CaptureBuffer pDSCaptureBuffer = null;
            dscheckboxd.BufferBytes = format.AverageBytesPerSecond;
            dscheckboxd.Format = format;
            try
            {
                pDSCaptureBuffer = new CaptureBuffer(dscheckboxd, device);
                pDSCaptureBuffer.Dispose();
                return format;
            }
            catch
            {
                // Can't return null, because WaveFormat is a value type.
                throw;
            }
        }

		public WaveFormatSelector(Capture device)
		{
			InitializeComponent();

			this.device = device;

			ScanAvailableInputFormats();
			FillFormatListBox();
		}

		#region InitializeComponent code
		private void InitializeComponent()
		{
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.lbFormatsInputListbox = new System.Windows.Forms.ListBox();
			this.labelStatic = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Enabled = false;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOk.Location = new System.Drawing.Point(23, 136);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(64, 24);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "確定";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(95, 136);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 24);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// lbFormatsInputListbox
			// 
			this.lbFormatsInputListbox.ItemHeight = 12;
			this.lbFormatsInputListbox.Location = new System.Drawing.Point(10, 28);
			this.lbFormatsInputListbox.Name = "lbFormatsInputListbox";
			this.lbFormatsInputListbox.Size = new System.Drawing.Size(162, 100);
			this.lbFormatsInputListbox.TabIndex = 2;
			this.lbFormatsInputListbox.SelectedIndexChanged += new System.EventHandler(this.lbFormatsInputListbox_SelectedIndexChanged);
			// 
			// labelStatic
			// 
			this.labelStatic.Location = new System.Drawing.Point(10, 13);
			this.labelStatic.Name = "labelStatic";
			this.labelStatic.Size = new System.Drawing.Size(75, 15);
			this.labelStatic.TabIndex = 3;
			this.labelStatic.Text = "輸入格式：";
			// 
			// WaveFormatSelector
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(183, 176);
			this.ControlBox = false;
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.lbFormatsInputListbox);
			this.Controls.Add(this.labelStatic);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "WaveFormatSelector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "選擇輸入格式";
			this.ResumeLayout(false);

		}
		#endregion

		private void ScanAvailableInputFormats()
		{
			//-----------------------------------------------------------------------------
			// Name: ScanAvailableInputFormats()
			// Desc: Tests to see if 20 different standard wave formats are supported by
			//       the capture device 
			//-----------------------------------------------------------------------------
			WaveFormat format = new WaveFormat();
			CaptureBufferDescription dscheckboxd = new CaptureBufferDescription();
			CaptureBuffer pDSCaptureBuffer = null;
    
			// This might take a second or two, so throw up the hourglass
			Cursor = Cursors.WaitCursor;
    
			format.FormatTag = WaveFormatTag.Pcm;

			// Try 20 different standard formats to see if they are supported
			for (int iIndex = 0; iIndex < 20; iIndex++)
			{
				GetWaveFormatFromIndex(iIndex, ref format);

				// To test if a capture format is supported, try to create a 
				// new capture buffer using a specific format.  If it works
				// then the format is supported, otherwise not.
				dscheckboxd.BufferBytes = format.AverageBytesPerSecond;
				dscheckboxd.Format = format;
        
				try
				{
					pDSCaptureBuffer = new CaptureBuffer(dscheckboxd, device);
					InputFormatSupported[ iIndex ] = true;
				}
				catch(Exception)
				{
					InputFormatSupported[ iIndex ] = false;
				}

				pDSCaptureBuffer.Dispose();
			}
			Cursor = Cursors.Default;
		}
		private void GetWaveFormatFromIndex(int Index, ref WaveFormat format)
		{
			//-----------------------------------------------------------------------------
			// Name: GetWaveFormatFromIndex()
			// Desc: Returns 20 different wave formats based on Index
			//-----------------------------------------------------------------------------
			int SampleRate = Index / 4;
			int iType = Index % 4;

			switch (SampleRate)
			{
				case 0: format.SamplesPerSecond = 48000; break;
				case 1: format.SamplesPerSecond = 44100; break;
				case 2: format.SamplesPerSecond = 22050; break;
				case 3: format.SamplesPerSecond = 11025; break;
				case 4: format.SamplesPerSecond =  8000; break;
			}

			switch (iType)
			{
				case 0: format.BitsPerSample =  8; format.Channels = 1; break;
				case 1: format.BitsPerSample = 16; format.Channels = 1; break;
				case 2: format.BitsPerSample =  8; format.Channels = 2; break;
				case 3: format.BitsPerSample = 16; format.Channels = 2; break;
			}

			format.BlockAlign = (short)(format.Channels * (format.BitsPerSample / 8));
			format.AverageBytesPerSecond = format.BlockAlign * format.SamplesPerSecond;
		}
		void FillFormatListBox()
		{
			//-----------------------------------------------------------------------------
			// Name: FillFormatListBox()
			// Desc: Fills the format list box based on the availible formats
			//-----------------------------------------------------------------------------
			WaveFormatInfo	info			= new WaveFormatInfo();		
			string			strFormatName	= string.Empty;
			WaveFormat		format			= new WaveFormat();

			for (int iIndex = 0; iIndex < InputFormatSupported.Length; iIndex++)
			{
				if (true == InputFormatSupported[iIndex])
				{
					// Turn the index into a WaveFormat then turn that into a
					// string and put the string in the listbox
					GetWaveFormatFromIndex(iIndex, ref format);
					info.format = format;
					formats.Add(info);
				}
			}
			lbFormatsInputListbox.DataSource = formats;
		}
		private static string ConvertWaveFormatToString(WaveFormat format)
		{
			//-----------------------------------------------------------------------------
			// Name: ConvertWaveFormatToString()
			// Desc: Converts a wave format to a text string
			//-----------------------------------------------------------------------------
			return format.SamplesPerSecond + " Hz, " + 
				format.BitsPerSample + "-bit " + 
				((format.Channels == 1) ? "Mono" : "Stereo");
		}
		private void FormatsOK()
		{
			//-----------------------------------------------------------------------------
			// Name: FormatsOK()
			// Desc: Stores the capture buffer format based on what was selected
			//-----------------------------------------------------------------------------
		
			selectedFormat = ((WaveFormatInfo)formats[lbFormatsInputListbox.SelectedIndex]).format;
			
			DialogResult = DialogResult.OK;
		}
		private void buttonOk_Click(object sender, System.EventArgs e)
		{
			FormatsOK();
		}

		private void lbFormatsInputListbox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			buttonOk.Enabled = true;
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
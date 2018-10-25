using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace AdHocDesktop.Stream.DirectSound
{
	public class CaptureSound
	{
		public event DirectSoundBufferDataEventHandler BufferData;

        const int NumberRecordNotifications = DirectSoundManager.NumberdNotifications;

		Capture selectedDevice;
		WaveFormat selectedFormat;
		bool isRecording = false;
		//bool isPaused = false;

		BufferPositionNotify[] positionNotify = new BufferPositionNotify[NumberRecordNotifications + 1]; 		
		AutoResetEvent notificationEvent = null;
		CaptureBuffer buffer = null;
		string fileName = string.Empty;
		Notify notify = null;
		Thread notifyThread = null;
		FileStream waveFile = null;
		BinaryWriter writer = null;
		int captureBufferSize = 0;
		int nextCaptureOffset = 0;
		long sampleCount = 0;
		int notifySize = 0;

		public long SampleCount
		{
			get
			{
				return sampleCount;
			}
		}

		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				fileName = value;
				CreateRIFF();
			}
		}

        public int BufferBytes
        {
            get { return captureBufferSize; }
        }

		public WaveFormat SelectedFormat
		{
			get
			{
				return selectedFormat;
			}
		}

		public CaptureSound()
		{			
			InitializeDeviceSelector();
			InitializeWaveFormatSelector();
            Initialize();
		}

		public CaptureSound(Capture device) 
		{
			this.selectedDevice = device;			
			InitializeWaveFormatSelector();
            Initialize();
		}

		public CaptureSound(WaveFormat waveFormat)
		{
			this.selectedFormat = waveFormat;			
			InitializeDeviceSelector();
            Initialize();
		}

		public CaptureSound(Capture device, WaveFormat waveFormat)
		{
			this.selectedDevice = device;
			this.selectedFormat = waveFormat;
			Initialize();
		}

		void Initialize()
		{
			CreateCaptureBuffer();
		}		

		void InitializeDeviceSelector()
		{
			DeviceSelector deviceSelector = new DeviceSelector();
			
			try
			{
				selectedDevice = new Capture(deviceSelector.SelectedDevice.DriverGuid);
			}
			catch
			{
                if (deviceSelector.Devices.Count > 1)
                {
                    deviceSelector.ShowDialog(null);
                    selectedDevice = new Capture(deviceSelector.SelectedDevice.DriverGuid);
                }
                else
                {
                    selectedDevice = null;
                }
			}

			if(selectedDevice == null)
			{
				throw new ArgumentException("無法初始化音訊裝置 " + deviceSelector.SelectedDevice.Description + ".");
			}
		}

		void InitializeWaveFormatSelector()
		{
			if(selectedDevice == null)
			{
                throw new ArgumentException("尚未設定音訊裝置，無法選擇輸出格式。");
			}
			else
			{
				WaveFormatSelector formatSelector = new WaveFormatSelector(selectedDevice);
				try
				{
					selectedFormat = formatSelector.DefaultFormat;
				}
				catch
				{
					formatSelector.ShowDialog(null);
					selectedFormat = formatSelector.SelectedFormat;
				}
			}
		}

		void CreateCaptureBuffer()
		{
			//-----------------------------------------------------------------------------
			// Name: CreateCaptureBuffer()
			// Desc: Creates a capture buffer and sets the format 
			//-----------------------------------------------------------------------------
			CaptureBufferDescription dscheckboxd = new CaptureBufferDescription(); 

			if (null != notify)
			{
				notify.Dispose();
				notify = null;
			}
			if (null != buffer)
			{
				buffer.Dispose();
				buffer = null;
			}

			if (0 == selectedFormat.Channels)
				return;

			// Set the notification size
			notifySize = (1024 > selectedFormat.AverageBytesPerSecond / 8) ? 1024 : (selectedFormat.AverageBytesPerSecond / 8);
			notifySize -= notifySize % selectedFormat.BlockAlign;   

			// Set the buffer sizes
			captureBufferSize = notifySize * NumberRecordNotifications;

			// Create the capture buffer
			dscheckboxd.BufferBytes = captureBufferSize;
			selectedFormat.FormatTag = WaveFormatTag.Pcm;
			dscheckboxd.Format = selectedFormat; // Set the format during creatation
		
			buffer = new CaptureBuffer(dscheckboxd, selectedDevice);
			nextCaptureOffset = 0;

			InitNotifications();
		}

		void InitNotifications()
		{
			//-----------------------------------------------------------------------------
			// Name: InitNotifications()
			// Desc: Inits the notifications on the capture buffer which are handled
			//       in the notify thread.
			//-----------------------------------------------------------------------------

			if (null == buffer)
				throw new NullReferenceException();
		
			// Create a thread to monitor the notify events
			if (null == notifyThread)
			{
				isRecording = true;
				notifyThread = new Thread(new ThreadStart(WaitThread));
				notifyThread.Start();	

				// Create a notification event, for when the sound stops playing
				notificationEvent = new AutoResetEvent(false);
			}

			// Setup the notification positions
			for (int i = 0; i < NumberRecordNotifications; i++)
			{
				positionNotify[i].Offset = (notifySize * i) + notifySize - 1;
				positionNotify[i].EventNotifyHandle = notificationEvent.SafeWaitHandle.DangerousGetHandle();
			}
		
			notify = new Notify(buffer);

			// Tell DirectSound when to notify the app. The notification will come in the from 
			// of signaled events that are handled in the notify thread.
			notify.SetNotificationPositions(positionNotify, NumberRecordNotifications);
		}

		public void Start()
		{
			StartOrStopRecord(true);
		}

		public void Stop()
		{
			StartOrStopRecord(false);
			notifyThread = null;
			nextCaptureOffset = 0;
			sampleCount = 0;			
		}

		public void Pause()
		{
			//isPaused = true;
			buffer.Stop();
		}

		public void Resume()
		{
			//isPaused = false;
			buffer.Start(true);
		}

		void WaitThread()
		{
			while(isRecording)
			{
				// don't worry about the isPaused flag, 
				// because notificationEvent will wait the data of captured.
				//if(!isPaused)
				//{
					try
					{
						//Sit here and wait for a message to arrive
						notificationEvent.WaitOne(Timeout.Infinite, true);
						RecordCapturedData();
					}
					catch(Exception)
					{
					}
				//}
			}
		}

		void StartOrStopRecord(bool StartRecording)
		{
			//-----------------------------------------------------------------------------
			// Name: StartOrStopRecord()
			// Desc: Starts or stops the capture buffer from recording
			//-----------------------------------------------------------------------------

			if (StartRecording)
			{
				// Create a capture buffer, and tell the capture 
				// buffer to start recording   
				isRecording = true;
				CreateCaptureBuffer();
				buffer.Start(true);
			}
			else
			{
				// Stop the buffer, and read any data that was not 
				// caught by a notification
				isRecording = false;
				buffer.Stop();

				RecordCapturedData();

				if(writer != null)
				{
					writer.Seek(4, SeekOrigin.Begin); // Seek to the length descriptor of the RIFF file.
					writer.Write((int)(sampleCount + 36));	// Write the file length, minus first 8 bytes of RIFF description.
					writer.Seek(40, SeekOrigin.Begin); // Seek to the data length descriptor of the RIFF file.
					writer.Write(sampleCount); // Write the length of the sample data in bytes.
			
					writer.Close();	// Close the file now.
					writer = null;	// Set the writer to null.
					waveFile = null; // Set the FileStream to null.
				}
			}
		}

		void CreateRIFF()
		{
			/**************************************************************************
			 
				Here is where the file will be created. A
				wave file is a RIFF file, which has chunks
				of data that describe what the file contains.
				A wave RIFF file is put together like this:
			 
				The 12 byte RIFF chunk is constructed like this:
				Bytes 0 - 3 :	'R' 'I' 'F' 'F'
				Bytes 4 - 7 :	Length of file, minus the first 8 bytes of the RIFF description.
								(4 bytes for "WAVE" + 24 bytes for format chunk length +
								8 bytes for data chunk description + actual sample data size.)
				Bytes 8 - 11:	'W' 'A' 'V' 'E'
			
				The 24 byte FORMAT chunk is constructed like this:
				Bytes 0 - 3 :	'f' 'm' 't' ' '
				Bytes 4 - 7 :	The format chunk length. This is always 16.
				Bytes 8 - 9 :	File padding. Always 1.
				Bytes 10- 11:	Number of channels. Either 1 for mono,  or 2 for stereo.
				Bytes 12- 15:	Sample rate.
				Bytes 16- 19:	Number of bytes per second.
				Bytes 20- 21:	Bytes per sample. 1 for 8 bit mono, 2 for 8 bit stereo or
								16 bit mono, 4 for 16 bit stereo.
				Bytes 22- 23:	Number of bits per sample.
			
				The DATA chunk is constructed like this:
				Bytes 0 - 3 :	'd' 'a' 't' 'a'
				Bytes 4 - 7 :	Length of data, in bytes.
				Bytes 8 -...:	Actual sample data.
			
			***************************************************************************/

			// Open up the wave file for writing.
			waveFile = new FileStream(FileName, FileMode.Create);
			writer = new BinaryWriter(waveFile);

			// Set up file with RIFF chunk info.
			char[] chunkRiff = {'R','I','F','F'};
			char[] chunkType = {'W','A','V','E'};
			char[] chunkFmt	= {'f','m','t',' '};
			char[] chunkData = {'d','a','t','a'};
			
			short shPad = 1; // File padding
			int nFormatChunkLength = 0x10; // Format chunk length.
			int nLength = 0; // File length, minus first 8 bytes of RIFF description. This will be filled in later.
			short shBytesPerSample = 0; // Bytes per sample.

			// Figure out how many bytes there will be per sample.
			if (8 == selectedFormat.BitsPerSample && 1 == selectedFormat.Channels)
				shBytesPerSample = 1;
			else if ((8 == selectedFormat.BitsPerSample && 2 == selectedFormat.Channels) || (16 == selectedFormat.BitsPerSample && 1 == selectedFormat.Channels))
				shBytesPerSample = 2;
			else if (16 == selectedFormat.BitsPerSample && 2 == selectedFormat.Channels)
				shBytesPerSample = 4;

			// Fill in the riff info for the wave file.
			writer.Write(chunkRiff);
			writer.Write(nLength);
			writer.Write(chunkType);

			// Fill in the format info for the wave file.
			writer.Write(chunkFmt);
			writer.Write(nFormatChunkLength);
			writer.Write(shPad);
			writer.Write(selectedFormat.Channels);
			writer.Write(selectedFormat.SamplesPerSecond);
			writer.Write(selectedFormat.AverageBytesPerSecond);
			writer.Write(shBytesPerSample);
			writer.Write(selectedFormat.BitsPerSample);
			
			// Now fill in the data chunk.
			writer.Write(chunkData);
			writer.Write((int)0);	// The sample length will be written in later.
		}

		void RecordCapturedData() 
		{
			//-----------------------------------------------------------------------------
			// Name: RecordCapturedData()
			// Desc: Copies data from the capture buffer to the output buffer 
			//-----------------------------------------------------------------------------
			byte[] captureData = null;
			int readPos;
			int capturePos;
			int lockSize;

			try
			{
				buffer.GetCurrentPosition(out capturePos, out readPos);
				lockSize = readPos - nextCaptureOffset;
				if (lockSize < 0)
					lockSize += captureBufferSize;

				// Block align lock size so that we are always write on a boundary
				lockSize -= (lockSize % notifySize);

				if (0 == lockSize)
					return;

				// Read the capture buffer.
				captureData = (byte[])buffer.Read(nextCaptureOffset, typeof(byte), LockFlag.None, lockSize);

				OnBufferData(this, new DirectSoundBufferDataEventArgs(captureData));

				if(writer != null)
				{
					// Write the data into the wav file
					writer.Write(captureData, 0, captureData.Length);
				}
		
				// Update the number of samples, in bytes, of the file so far.
				sampleCount += captureData.Length;

				// Move the capture offset along
				nextCaptureOffset += captureData.Length; 
				nextCaptureOffset %= captureBufferSize; // Circular buffer
			}
			catch (Exception)
			{
			}
			finally
			{
				captureData = null;
			}
		}

		void OnBufferData(object sender, DirectSoundBufferDataEventArgs e)
		{
			if(BufferData != null)
			{
				BufferData(sender, e);
			}
		}
	}
}

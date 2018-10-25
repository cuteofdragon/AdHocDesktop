/* <file>
 * <copyright see="prj:///doc/copyright.rtf"/>
 * <license see="prj:///doc/license.rtf"/>
 * <owner name="可愛龍" email="cute.ofdragon@gmail.com"/>
 * <version value="$version"/>
 * <comment>  
 * </comment>
 * </file>
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

using Microsoft.DirectX.DirectShow;

namespace Microsoft.DirectX.VideoGrabber
{
	public class VideoGrabberPanel : Panel, ISampleGrabberCB
	{
		int frame = 5; //每秒幾個Frame。

		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 每秒幾個框頁。
		/// </summary>
		[Description("每秒幾個框頁。")]
		public int Frame
		{
			get
			{
				return frame;
			}
			set
			{
				frame = value;
				timer1.Interval = (1000 / frame);
			}
		}

		public VideoGrabberPanel()
		{
			InitializeComponent();
		}

		public VideoGrabberPanel(DsDevice device)
		{
			this.capDevice = device;
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if( disposing )
			{				
				EndGrabber();
			
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);

			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// VideoGrabberPanel
			// 
			this.BackColor = System.Drawing.Color.Black;
			this.Size = new System.Drawing.Size(320, 240);
			this.Resize += new System.EventHandler(this.VideoGrabber_Resize);
		}

		void Initialize()
		{
			if( firstActive )
			{
				throw new VideoGrabberException("已經呼叫過 BeginGrabber() 方法了！");
			}
			firstActive = true;

			if( ! DsUtils.IsCorrectDirectXVersion() )
			{
				EndGrabber();
				throw new VideoGrabberException("系統未安裝 DirectX 8.1 以後的版本！");
			}

			/*
			//if( ! DsDevice.GetDevicesOfCat( FilterCategory.VideoInputDevice, out capDevices ) )
			if( (capDevices = DsDevice.GetDevicesOfCat( FilterCategory.VideoInputDevice )) == null )
			{
				EndGrabber();
				throw new VideoGrabberException("未偵測到視訊裝置！");
			}

			DsDevice dev = null;
			if( capDevices.Length == 1 )
				dev = capDevices[0] as DsDevice;
			else
			{
				DeviceSelector selector = new DeviceSelector( capDevices );
				selector.ShowDialog( this );
				dev = selector.SelectedDevice;
			}
			*/

			if(capDevice == null)
			{

				DeviceSelector selector = new DeviceSelector( );
				if(selector.Devices.Length > 1)
				{
					selector.ShowDialog( this );			
				}
			
				capDevice = selector.SelectedDevice;
			
				if( capDevice == null )
				{
					EndGrabber();
					throw new VideoGrabberException("無法取得視訊裝置！");
				}
			}

			if( ! StartupVideo( capDevice.Mon ) )				
			{
				EndPreview();
				EndGrabber();
				throw new VideoGrabberException("無法初始化設定視訊裝置！");
			}
		}

		private void VideoGrabber_Resize(object sender, System.EventArgs e)
		{
			ResizeVideoWindow();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			Processing();		
		}

		/// <summary> handler for toolbar button clicks. </summary>
		private void Processing()
		{		
			int hr;
			if( sampGrabber == null )
				return;


			if( savedArray == null )
			{
				int size = videoInfoHeader.BmiHeader.ImageSize;
				if( (size < 1000) || (size > 16000000) )
					return;
				savedArray = new byte[ size + 64000 ];
			}

			captured = false;
			hr = sampGrabber.SetCallback( this, 1 );
		}

		public void EndGrabber()
		{
			timer1.Stop();
			CloseInterfaces();
		}		

		/// <summary> detect first form appearance, start grabber. </summary>
		public void BeginGrabber()
		{
			if(!isInit)
			{
				Initialize();
				isInit = true;
			}
			timer1.Start();
		}

		public void BeginPreview()
		{
			if(!isInit)
			{
				Initialize();
				isInit = true;
			}
			int hr = videoWin.put_Visible(OABool.True );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
		}

		public void EndPreview()
		{
			int hr = videoWin.put_Visible(OABool.False );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
		}

		void OnBufferData(object sender, VideoGrabberBufferDataEventArgs e)
		{
			if(BufferData != null)
			{
				BufferData(sender, e);
			}
		}
		

		/// <summary> capture event, triggered by buffer callback. </summary>
		void OnCaptureDone()
		{
			Trace.WriteLine( "!!DLG: OnCaptureDone" );
			try 
			{
				int hr;
				if( sampGrabber == null )
				{
					return;
				}
				hr = sampGrabber.SetCallback( null, 0 );

				int w = videoInfoHeader.BmiHeader.Width;
				int h = videoInfoHeader.BmiHeader.Height;
				if( ((w & 0x03) != 0) || (w < 32) || (w > 4096) || (h < 32) || (h > 4096) )
				{
					return;
				}
				//get Image
				int stride = w * 3;
				GCHandle handle = GCHandle.Alloc( savedArray, GCHandleType.Pinned );
				int scan0 = (int) handle.AddrOfPinnedObject();
				scan0 += (h - 1) * stride;
				Bitmap b = new Bitmap( w, h, -stride, PixelFormat.Format24bppRgb, (IntPtr) scan0 );
				handle.Free();
				
				OnBufferData(this, new VideoGrabberBufferDataEventArgs(b));
			
				savedArray = null;			
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}


		/// <summary> start all the interfaces, graphs and preview window. </summary>
		bool StartupVideo( UCOMIMoniker mon )
		{
			int hr;
			try 
			{
				if( ! CreateCaptureDevice( mon ) )
					return false;

				if( ! GetInterfaces() )
					return false;

				if( ! SetupGraph() )
					return false;

				if( ! SetupVideoWindow() )
					return false;

#if DEBUG
				//DsROT.AddGraphToRot( graphBuilder, out rotCookie );		// graphBuilder capGraph
				rot = new DsROTEntry( graphBuilder );
#endif
			
				hr = mediaCtrl.Run();
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				bool hasTuner = DsUtils.ShowTunerPinDialog( capGraph, capFilter, this.Handle );
				//tuneBtn.Enabled = hasTuner;

				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary> make the video preview window to show in videoPanel. </summary>
		bool SetupVideoWindow()
		{
			int hr;
			try 
			{
				// Set the video window to be a child of the main window
				hr = videoWin.put_Owner( this.Handle );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				// Set video window style
				hr = videoWin.put_WindowStyle( WindowStyle.Child | WindowStyle.ClipChildren );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				// Use helper function to position video window in client rect of owner window
				ResizeVideoWindow();

				// Make the video window visible, now that it is properly positioned
				hr = videoWin.put_Visible( OABool.True );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				hr = mediaEvt.SetNotifyWindow( this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );
				return true;
			}
			catch
			{
				return false;
			}
		}


		/// <summary> build the capture graph for grabber. </summary>
		bool SetupGraph()
		{
			int hr;
			try 
			{
				hr = capGraph.SetFiltergraph( graphBuilder );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				hr = graphBuilder.AddFilter( capFilter, "Ds.NET Video Capture Device" );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				//DsUtils.ShowCapPinDialog( capGraph, capFilter, this.Handle );

				AMMediaType media = new AMMediaType();
				media.majorType	= MediaType.Video;
				media.subType	= MediaSubType.RGB24;
				media.formatType = FormatType.VideoInfo;		// ???
				hr = sampGrabber.SetMediaType( media );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				hr = graphBuilder.AddFilter( baseGrabFlt, "Ds.NET Grabber" );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				Guid cat = PinCategory.Preview;
				Guid med = MediaType.Video;
				hr = capGraph.RenderStream( cat, med, capFilter, null, null ); // baseGrabFlt 
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				cat = PinCategory.Capture;
				med = MediaType.Video;
				hr = capGraph.RenderStream( cat, med, capFilter, null, baseGrabFlt ); // baseGrabFlt 
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				media = new AMMediaType();
				hr = sampGrabber.GetConnectedMediaType( media );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );
				if( (media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero) )
					throw new NotSupportedException( "Unknown Grabber Media Format" );

				videoInfoHeader = (VideoInfoHeader) Marshal.PtrToStructure( media.formatPtr, typeof(VideoInfoHeader) );
				Marshal.FreeCoTaskMem( media.formatPtr ); media.formatPtr = IntPtr.Zero;

				hr = sampGrabber.SetBufferSamples( false );
				if( hr == 0 )
					hr = sampGrabber.SetOneShot( false );
				if( hr == 0 )
					hr = sampGrabber.SetCallback( null, 0 );
				if( hr < 0 )
					Marshal.ThrowExceptionForHR( hr );

				return true;
			}
			catch
			{
				return false;
			}
		}


		/// <summary> create the used COM components and get the interfaces. </summary>
		bool GetInterfaces()
		{			
			try 
			{
				graphBuilder = (IGraphBuilder) new FilterGraph();
				if(graphBuilder == null)
				{
					throw new COMException("Can't initialize FilterGraph instance.");
				}

				capGraph = (ICaptureGraphBuilder2) new CaptureGraphBuilder2();
				if(capGraph == null)
				{
					throw new COMException("Can't initialize CaptureGraphBuilder2 instance.");
				}

				sampGrabber = (ISampleGrabber) new SampleGrabber();
				if(sampGrabber == null)
				{
					throw new COMException("Can't initialize SampleGrabber instance.");
				}

				mediaCtrl	= (IMediaControl)	graphBuilder;
				videoWin	= (IVideoWindow)	graphBuilder;
				mediaEvt	= (IMediaEventEx)	graphBuilder;
				baseGrabFlt	= (IBaseFilter)		sampGrabber;
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
			}
		}

		/// <summary> create the user selected capture device. </summary>
		bool CreateCaptureDevice( UCOMIMoniker mon )
		{
			object capObj = null;
			try 
			{
				Guid gbf = typeof( IBaseFilter ).GUID;
				mon.BindToObject( null, null, ref gbf, out capObj );
				capFilter = (IBaseFilter) capObj; capObj = null;
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if( capObj != null )
					Marshal.ReleaseComObject( capObj ); capObj = null;
			}
		}

		/// <summary> do cleanup and release DirectShow. </summary>
		void CloseInterfaces()
		{
			int hr;
			try 
			{
#if DEBUG
				//if( rotCookie != 0 )
				//	DsROT.RemoveGraphFromRot( ref rotCookie );
				rot.Dispose();
#endif

				if( mediaCtrl != null )
				{
					hr = mediaCtrl.Stop();
					mediaCtrl = null;
				}

				if( mediaEvt != null )
				{
					hr = mediaEvt.SetNotifyWindow( IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero );
					mediaEvt = null;
				}

				if( videoWin != null )
				{
					hr = videoWin.put_Visible( OABool.False );
					hr = videoWin.put_Owner( IntPtr.Zero );
					videoWin = null;
				}

				baseGrabFlt = null;
				if( sampGrabber != null )
					Marshal.ReleaseComObject( sampGrabber ); sampGrabber = null;

				if( capGraph != null )
					Marshal.ReleaseComObject( capGraph ); capGraph = null;

				if( graphBuilder != null )
					Marshal.ReleaseComObject( graphBuilder ); graphBuilder = null;

				if( capFilter != null )
					Marshal.ReleaseComObject( capFilter ); capFilter = null;
			
				if( capDevices != null )
				{
					foreach( DsDevice d in capDevices )
						d.Dispose();
					capDevices = null;
				}
			}
			catch
			{}
		}

		/// <summary> resize preview video window to fill client area. </summary>
		public void ResizeVideoWindow()
		{
			if( videoWin != null )
			{
				Rectangle rc = this.ClientRectangle;
				videoWin.SetWindowPosition( 0, 0, rc.Right, rc.Bottom );
			}
		}

		
		/// <summary> override window fn to handle graph events. </summary>
		protected override void WndProc( ref Message m )
		{
			if( m.Msg == WM_GRAPHNOTIFY )
			{
				if( mediaEvt != null )
					OnGraphNotify();
				return;
			}
			base.WndProc( ref m );
		}

		/// <summary> graph event (WM_GRAPHNOTIFY) handler. </summary>
		void OnGraphNotify()
		{
			EventCode	code;
			int p1, p2, hr = 0;
			do
			{
				hr = mediaEvt.GetEvent( out code, out p1, out p2, 0 );
				if( hr < 0 )
					break;
				hr = mediaEvt.FreeEventParams( code, p1, p2 );
			}
			while( hr == 0 );
		}

		/// <summary> sample callback, NOT USED. </summary>
		int ISampleGrabberCB.SampleCB( double SampleTime, IMediaSample pSample )
		{
			Trace.WriteLine( "!!CB: ISampleGrabberCB.SampleCB" );
			return 0;
		}

		/// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
		int ISampleGrabberCB.BufferCB( double SampleTime, IntPtr pBuffer, int BufferLen )
		{
			if( captured || (savedArray == null) )
			{
				Trace.WriteLine( "!!CB: ISampleGrabberCB.BufferCB" );
				return 0;
			}

			captured = true;
			bufferedSize = BufferLen;
			Trace.WriteLine( "!!CB: ISampleGrabberCB.BufferCB  !GRAB! size = " + BufferLen.ToString() );
			if( (pBuffer != IntPtr.Zero) && (BufferLen > 1000) && (BufferLen <= savedArray.Length) )
				Marshal.Copy( pBuffer, savedArray, 0, BufferLen );
			else
				Trace.WriteLine( "    !!!GRAB! failed " );
			this.BeginInvoke( new CaptureDone( this.OnCaptureDone ) );
			return 0;
		}


		/// <summary> flag to detect first Form appearance </summary>
		private bool					firstActive;
		
		private bool					isInit;

		/// <summary> base filter of the actually used video devices. </summary>
		private IBaseFilter				capFilter;

		/// <summary> graph builder interface. </summary>
		private IGraphBuilder			graphBuilder;

		/// <summary> capture graph builder interface. </summary>
		private ICaptureGraphBuilder2	capGraph;
		private ISampleGrabber			sampGrabber;

		/// <summary> control interface. </summary>
		private IMediaControl			mediaCtrl;

		/// <summary> event interface. </summary>
		private IMediaEventEx			mediaEvt;

		/// <summary> video window interface. </summary>
		private IVideoWindow			videoWin;

		/// <summary> grabber filter interface. </summary>
		private IBaseFilter				baseGrabFlt;

		/// <summary> structure describing the bitmap to grab. </summary>
		private	VideoInfoHeader			videoInfoHeader;
		private	bool					captured = true;
		private	int						bufferedSize;

		/// <summary> buffer for bitmap data. </summary>
		private	byte[]					savedArray;

		/// <summary> list of installed video devices. </summary>
		private DsDevice[]				capDevices;		

		private DsDevice				capDevice;

		private const int WM_GRAPHNOTIFY	= 0x00008001;	// message from graph

		private const int WS_CHILD			= 0x40000000;	// attributes for video window
		private const int WS_CLIPCHILDREN	= 0x02000000;
		private const int WS_CLIPSIBLINGS	= 0x04000000;		

		/// <summary> event when callback has finished (ISampleGrabberCB.BufferCB). </summary>
		private delegate void CaptureDone();

        public event VideoGrabberBufferDataEventHandler BufferData;

#if DEBUG
		//private int		rotCookie = 0;
		private DsROTEntry				rot;
#endif		
	}
}

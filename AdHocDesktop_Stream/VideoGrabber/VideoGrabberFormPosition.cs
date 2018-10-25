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
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Microsoft.DirectX.VideoGrabber
{
	public class VideoGrabberFormPosition : System.Windows.Forms.Form
	{
		public event EventHandler PositionChanged;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.Panel panel16;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Timer visibleTimer;		
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panelHCenter3;
		private System.Windows.Forms.Panel panelHCenter2;
		private System.Windows.Forms.Panel panelHCenter1;
		private System.Windows.Forms.Panel panelHCenter4;
		private System.Windows.Forms.Panel panelHCenter5;
		private System.Windows.Forms.Panel panelVCenter2;
		private System.Windows.Forms.Panel panelVCenter1;
		private System.Windows.Forms.Panel panelVCenter3;
		private System.Windows.Forms.Panel panelVCenter4;
		
		Point selectedLocation = Point.Empty;
		private System.Windows.Forms.Panel panelDefault;
		Size videoGrabberFormSize;

		public Point SelectedPosition
		{
			get
			{
				return selectedLocation;
			}
		}

		public Size VideoGrabberFormSize
		{
			get
			{
				return videoGrabberFormSize;
			}
			set
			{
				videoGrabberFormSize = value;
			}
		}

		public VideoGrabberFormPosition( )
		{
			InitializeComponent();
		}

		/// <summary> Clean up any resources being used. </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}		

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel13 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel12 = new System.Windows.Forms.Panel();
			this.panel14 = new System.Windows.Forms.Panel();
			this.panel15 = new System.Windows.Forms.Panel();
			this.panel16 = new System.Windows.Forms.Panel();
			this.visibleTimer = new System.Windows.Forms.Timer(this.components);
			this.panelHCenter3 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panelDefault = new System.Windows.Forms.Panel();
			this.panelVCenter4 = new System.Windows.Forms.Panel();
			this.panelVCenter3 = new System.Windows.Forms.Panel();
			this.panelVCenter1 = new System.Windows.Forms.Panel();
			this.panelVCenter2 = new System.Windows.Forms.Panel();
			this.panelHCenter5 = new System.Windows.Forms.Panel();
			this.panelHCenter4 = new System.Windows.Forms.Panel();
			this.panelHCenter1 = new System.Windows.Forms.Panel();
			this.panelHCenter2 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(16, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(16, 16);
			this.panel1.TabIndex = 0;
			this.panel1.Click += new System.EventHandler(this.panel1_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(48, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(16, 16);
			this.panel2.TabIndex = 1;
			this.panel2.Click += new System.EventHandler(this.panel2_Click);
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(80, 24);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(16, 16);
			this.panel3.TabIndex = 2;
			this.panel3.Click += new System.EventHandler(this.panel3_Click);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Location = new System.Drawing.Point(112, 24);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(16, 16);
			this.panel4.TabIndex = 3;
			this.panel4.Click += new System.EventHandler(this.panel4_Click);
			// 
			// panel13
			// 
			this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel13.Location = new System.Drawing.Point(16, 96);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(16, 16);
			this.panel13.TabIndex = 4;
			this.panel13.Click += new System.EventHandler(this.panel13_Click);
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Location = new System.Drawing.Point(16, 48);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(16, 16);
			this.panel5.TabIndex = 5;
			this.panel5.Click += new System.EventHandler(this.panel5_Click);
			// 
			// panel9
			// 
			this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel9.Location = new System.Drawing.Point(16, 72);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(16, 16);
			this.panel9.TabIndex = 6;
			this.panel9.Click += new System.EventHandler(this.panel9_Click);
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Location = new System.Drawing.Point(48, 48);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(16, 16);
			this.panel6.TabIndex = 7;
			this.panel6.Click += new System.EventHandler(this.panel6_Click);
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Location = new System.Drawing.Point(80, 48);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(16, 16);
			this.panel7.TabIndex = 8;
			this.panel7.Click += new System.EventHandler(this.panel7_Click);
			// 
			// panel8
			// 
			this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Location = new System.Drawing.Point(112, 48);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(16, 16);
			this.panel8.TabIndex = 9;
			this.panel8.Click += new System.EventHandler(this.panel8_Click);
			// 
			// panel10
			// 
			this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel10.Location = new System.Drawing.Point(48, 72);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(16, 16);
			this.panel10.TabIndex = 10;
			this.panel10.Click += new System.EventHandler(this.panel10_Click);
			// 
			// panel11
			// 
			this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel11.Location = new System.Drawing.Point(80, 72);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(16, 16);
			this.panel11.TabIndex = 11;
			this.panel11.Click += new System.EventHandler(this.panel11_Click);
			// 
			// panel12
			// 
			this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel12.Location = new System.Drawing.Point(112, 72);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(16, 16);
			this.panel12.TabIndex = 12;
			this.panel12.Click += new System.EventHandler(this.panel12_Click);
			// 
			// panel14
			// 
			this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel14.Location = new System.Drawing.Point(48, 96);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(16, 16);
			this.panel14.TabIndex = 13;
			this.panel14.Click += new System.EventHandler(this.panel14_Click);
			// 
			// panel15
			// 
			this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel15.Location = new System.Drawing.Point(80, 96);
			this.panel15.Name = "panel15";
			this.panel15.Size = new System.Drawing.Size(16, 16);
			this.panel15.TabIndex = 14;
			this.panel15.Click += new System.EventHandler(this.panel15_Click);
			// 
			// panel16
			// 
			this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel16.Location = new System.Drawing.Point(112, 96);
			this.panel16.Name = "panel16";
			this.panel16.Size = new System.Drawing.Size(16, 16);
			this.panel16.TabIndex = 15;
			this.panel16.Click += new System.EventHandler(this.panel16_Click);
			// 
			// visibleTimer
			// 
			this.visibleTimer.Interval = 2000;
			this.visibleTimer.Tick += new System.EventHandler(this.visibleTimer_Tick);
			// 
			// panelHCenter3
			// 
			this.panelHCenter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHCenter3.Location = new System.Drawing.Point(64, 60);
			this.panelHCenter3.Name = "panelHCenter3";
			this.panelHCenter3.Size = new System.Drawing.Size(16, 16);
			this.panelHCenter3.TabIndex = 16;
			this.panelHCenter3.Click += new System.EventHandler(this.panelHCenter3_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.panel13);
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Controls.Add(this.panel6);
			this.groupBox1.Controls.Add(this.panel7);
			this.groupBox1.Controls.Add(this.panel8);
			this.groupBox1.Controls.Add(this.panel10);
			this.groupBox1.Controls.Add(this.panel11);
			this.groupBox1.Controls.Add(this.panel12);
			this.groupBox1.Controls.Add(this.panel14);
			this.groupBox1.Controls.Add(this.panel15);
			this.groupBox1.Controls.Add(this.panel16);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 128);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "定位1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panelDefault);
			this.groupBox2.Controls.Add(this.panelVCenter4);
			this.groupBox2.Controls.Add(this.panelVCenter3);
			this.groupBox2.Controls.Add(this.panelVCenter1);
			this.groupBox2.Controls.Add(this.panelVCenter2);
			this.groupBox2.Controls.Add(this.panelHCenter5);
			this.groupBox2.Controls.Add(this.panelHCenter4);
			this.groupBox2.Controls.Add(this.panelHCenter1);
			this.groupBox2.Controls.Add(this.panelHCenter2);
			this.groupBox2.Controls.Add(this.panelHCenter3);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(144, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 128);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "定位2";
			// 
			// panelDefault
			// 
			this.panelDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDefault.Location = new System.Drawing.Point(112, 88);
			this.panelDefault.Name = "panelDefault";
			this.panelDefault.Size = new System.Drawing.Size(16, 16);
			this.panelDefault.TabIndex = 25;
			this.panelDefault.Click += new System.EventHandler(this.panelDefault_Click);
			// 
			// panelVCenter4
			// 
			this.panelVCenter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelVCenter4.Location = new System.Drawing.Point(64, 96);
			this.panelVCenter4.Name = "panelVCenter4";
			this.panelVCenter4.Size = new System.Drawing.Size(16, 16);
			this.panelVCenter4.TabIndex = 24;
			this.panelVCenter4.Click += new System.EventHandler(this.panelVCenter4_Click);
			// 
			// panelVCenter3
			// 
			this.panelVCenter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelVCenter3.Location = new System.Drawing.Point(64, 78);
			this.panelVCenter3.Name = "panelVCenter3";
			this.panelVCenter3.Size = new System.Drawing.Size(16, 16);
			this.panelVCenter3.TabIndex = 23;
			this.panelVCenter3.Click += new System.EventHandler(this.panelVCenter3_Click);
			// 
			// panelVCenter1
			// 
			this.panelVCenter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelVCenter1.Location = new System.Drawing.Point(64, 24);
			this.panelVCenter1.Name = "panelVCenter1";
			this.panelVCenter1.Size = new System.Drawing.Size(16, 16);
			this.panelVCenter1.TabIndex = 22;
			this.panelVCenter1.Click += new System.EventHandler(this.panelVCenter1_Click);
			// 
			// panelVCenter2
			// 
			this.panelVCenter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelVCenter2.Location = new System.Drawing.Point(64, 42);
			this.panelVCenter2.Name = "panelVCenter2";
			this.panelVCenter2.Size = new System.Drawing.Size(16, 16);
			this.panelVCenter2.TabIndex = 21;
			this.panelVCenter2.Click += new System.EventHandler(this.panelVCenter2_Click);
			// 
			// panelHCenter5
			// 
			this.panelHCenter5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHCenter5.Location = new System.Drawing.Point(112, 60);
			this.panelHCenter5.Name = "panelHCenter5";
			this.panelHCenter5.Size = new System.Drawing.Size(16, 16);
			this.panelHCenter5.TabIndex = 20;
			this.panelHCenter5.Click += new System.EventHandler(this.panelHCenter5_Click);
			// 
			// panelHCenter4
			// 
			this.panelHCenter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHCenter4.Location = new System.Drawing.Point(88, 60);
			this.panelHCenter4.Name = "panelHCenter4";
			this.panelHCenter4.Size = new System.Drawing.Size(16, 16);
			this.panelHCenter4.TabIndex = 19;
			this.panelHCenter4.Click += new System.EventHandler(this.panelHCenter4_Click);
			// 
			// panelHCenter1
			// 
			this.panelHCenter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHCenter1.Location = new System.Drawing.Point(16, 60);
			this.panelHCenter1.Name = "panelHCenter1";
			this.panelHCenter1.Size = new System.Drawing.Size(16, 16);
			this.panelHCenter1.TabIndex = 18;
			this.panelHCenter1.Click += new System.EventHandler(this.panelHCenter1_Click);
			// 
			// panelHCenter2
			// 
			this.panelHCenter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHCenter2.Location = new System.Drawing.Point(40, 60);
			this.panelHCenter2.Name = "panelHCenter2";
			this.panelHCenter2.Size = new System.Drawing.Size(16, 16);
			this.panelHCenter2.TabIndex = 17;
			this.panelHCenter2.Click += new System.EventHandler(this.panelHCenter2_Click);
			// 
			// VideoGrabberFormPosition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(288, 136);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VideoGrabberFormPosition";
			this.Opacity = 0.8;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.MouseEnter += new System.EventHandler(this.VideoGrabberFormPosition_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.VideoGrabberFormPosition_MouseLeave);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void SetVisibleCore(bool value)
		{
			if(value == true)
			{
				Rectangle max = Screen.PrimaryScreen.Bounds;
				Point p = Form.MousePosition;
				p.X = p.X - this.Width / 2;
				p.Y = p.Y - this.Height / 2;
				if(p.X < 0)							p.X = 0;
				if(p.X + this.Width > max.Width)	p.X = max.Width - this.Width;
				if(p.Y < 0)							p.Y = 0;
				if(p.Y + this.Height > max.Height)	p.Y = max.Height - this.Height;
				this.Location = p;
				visibleTimer.Start();
			}
			else
			{
				visibleTimer.Stop();
			}
			base.SetVisibleCore (value);
		}

		public new void Show()
		{
			ResetPanels();
			base.Show();
		}		

		void ResetPanels()
		{
			foreach(Control control in groupBox1.Controls)
			{
				if(control is Panel)
				{
					((Panel)control).BorderStyle = BorderStyle.FixedSingle;
				}
			}
			foreach(Control control in groupBox2.Controls)
			{
				if(control is Panel)
				{
					((Panel)control).BorderStyle = BorderStyle.FixedSingle;
				}
			}
		}

		public void ClientToScreen(VideoGrabberFormPositionType type)
		{
			ResetPanels();

			Rectangle r = Screen.PrimaryScreen.Bounds;
			int x = 0;
			int y = 0;
			switch(type)
			{
				// 預設
				case VideoGrabberFormPositionType.Default:					x = r.Width - videoGrabberFormSize.Width;			y = Screen.PrimaryScreen.WorkingArea.Height - videoGrabberFormSize.Height; break;

				// 邊角
				case VideoGrabberFormPositionType.CornerUpperLeft:			x = 0;												y = 0;												break;
				case VideoGrabberFormPositionType.CornerUpperRight:			x = r.Width - videoGrabberFormSize.Width;			y = 0;												break;
				case VideoGrabberFormPositionType.CornerLowerLeft:			x = 0;												y = r.Height - videoGrabberFormSize.Height;			break;
				case VideoGrabberFormPositionType.CornerLowerRight:			x = r.Width - videoGrabberFormSize.Width;			y = r.Height - videoGrabberFormSize.Height;			break;
				
				case VideoGrabberFormPositionType.CornerMiddleLeft1:		x = 0;												y = r.Height / 2 - videoGrabberFormSize.Height;		break;
				case VideoGrabberFormPositionType.CornerMiddleLeft2:		x = 0;												y = r.Height / 2;									break;
				case VideoGrabberFormPositionType.CornerMiddleRight1:		x = r.Width - videoGrabberFormSize.Width;			y = r.Height / 2 - videoGrabberFormSize.Height;		break;
				case VideoGrabberFormPositionType.CornerMiddleRight2:		x = r.Width - videoGrabberFormSize.Width;			y = r.Height / 2;									break;
				
				// 垂直左
				case VideoGrabberFormPositionType.CornerMiddleLeftUpper:	x = r.Width / 2 - videoGrabberFormSize.Width;		y = 0;												break;
				case VideoGrabberFormPositionType.CornerMiddleLeftMiddle1:	x = r.Width / 2 - videoGrabberFormSize.Width;		y = r.Height / 2 - videoGrabberFormSize.Height;		break;
				case VideoGrabberFormPositionType.CornerMiddleLeftMiddle2:	x = r.Width / 2 - videoGrabberFormSize.Width;		y = r.Height / 2;									break;
				case VideoGrabberFormPositionType.CornerMiddleLeftLower:	x = r.Width / 2 - videoGrabberFormSize.Width;		y = r.Height - videoGrabberFormSize.Height;			break;

				// 垂直右
				case VideoGrabberFormPositionType.CornerMiddleRightMiddle1:	x = r.Width / 2;									y = 0;												break;
				case VideoGrabberFormPositionType.CornerMiddleRightMiddle2:	x = r.Width / 2;									y = r.Height / 2 - videoGrabberFormSize.Height;		break;
				case VideoGrabberFormPositionType.CornerMiddleRightUpper:	x = r.Width / 2;									y = r.Height / 2;									break;
				case VideoGrabberFormPositionType.CornerMiddleRightLower:	x = r.Width / 2;									y = r.Height - videoGrabberFormSize.Height;			break;

				// 中心線
				case VideoGrabberFormPositionType.CenterHLeft:				x = 0;												y = r.Height / 2 - videoGrabberFormSize.Height / 2;	break;
				case VideoGrabberFormPositionType.CenterHLeftMiddle:		x = r.Width / 2 - videoGrabberFormSize.Width;		y = r.Height / 2 - videoGrabberFormSize.Height / 2;	break;
				case VideoGrabberFormPositionType.CenterH:					x = r.Width / 2 - videoGrabberFormSize.Width / 2;	y = r.Height / 2 - videoGrabberFormSize.Height / 2;	break;
				case VideoGrabberFormPositionType.CenterHRightMiddle:		x = r.Width / 2;									y = r.Height / 2 - videoGrabberFormSize.Height / 2;	break;
				case VideoGrabberFormPositionType.CenterHRight:				x = r.Width - videoGrabberFormSize.Width;			y = r.Height / 2 - videoGrabberFormSize.Height / 2;	break;

				// 垂直線
				case VideoGrabberFormPositionType.CenterVUpper:				x = r.Width / 2 - videoGrabberFormSize.Width / 2;	y = 0;												break;
				case VideoGrabberFormPositionType.CenterVMiddleUpper:		x = r.Width / 2 - videoGrabberFormSize.Width / 2;	y = r.Height / 2 - videoGrabberFormSize.Height;		break;
				case VideoGrabberFormPositionType.CenterV:					x = r.Width / 2 - videoGrabberFormSize.Width / 2;	y = r.Height / 2 - videoGrabberFormSize.Height / 2;	break;
				case VideoGrabberFormPositionType.CenterVMiddleLower:		x = r.Width / 2 - videoGrabberFormSize.Width / 2;	y = r.Height / 2;									break;
				case VideoGrabberFormPositionType.CenterVLower:				x = r.Width / 2 - videoGrabberFormSize.Width / 2;	y = r.Height - videoGrabberFormSize.Height;			break;
			}
			selectedLocation.X = x;
			selectedLocation.Y = y;
			
			Hide();
			OnPositionChanged();
		}

		void Panel_Click(Panel panel)
		{
			panel.BorderStyle = BorderStyle.Fixed3D;
			Update();
			Thread.Sleep(100);
		}

		private void panel1_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerUpperLeft);				Panel_Click(panel1); }
		private void panel4_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerUpperRight);			Panel_Click(panel4); }
		private void panel13_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerLowerLeft);				Panel_Click(panel13); }
		private void panel16_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerLowerRight);			Panel_Click(panel16); }

		private void panel5_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleLeft1);			Panel_Click(panel5); }
		private void panel9_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleLeft2);			Panel_Click(panel9); }
		private void panel8_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleRight1);			Panel_Click(panel8); }
		private void panel12_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleRight2);			Panel_Click(panel12); }
		
		private void panel2_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleLeftUpper);		Panel_Click(panel2); }
		private void panel6_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleLeftMiddle1);		Panel_Click(panel6); }	
		private void panel10_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleLeftMiddle2);		Panel_Click(panel10); }
		private void panel14_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleLeftLower);		Panel_Click(panel14); }

		private void panel3_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleRightMiddle1);	Panel_Click(panel3); }		
		private void panel7_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleRightMiddle2);	Panel_Click(panel7); }
		private void panel11_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleRightUpper);		Panel_Click(panel11); }
		private void panel15_Click(object sender, EventArgs e)				{ ClientToScreen(VideoGrabberFormPositionType.CornerMiddleRightLower);		Panel_Click(panel15); }
		
		private void panelHCenter1_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterHLeft);					Panel_Click(panelHCenter1); }
		private void panelHCenter2_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterHLeftMiddle);			Panel_Click(panelHCenter2); }
		private void panelHCenter3_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterH);						Panel_Click(panelHCenter3); }
		private void panelHCenter4_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterHRightMiddle);			Panel_Click(panelHCenter4); }
		private void panelHCenter5_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterHRight);				Panel_Click(panelHCenter5); }
		private void panelVCenter1_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterVUpper);				Panel_Click(panelVCenter1); }
		private void panelVCenter2_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterVMiddleUpper);			Panel_Click(panelVCenter2); }
		private void panelVCenter3_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterVMiddleLower);			Panel_Click(panelVCenter3); }
		private void panelVCenter4_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.CenterVLower);				Panel_Click(panelVCenter4); }

		private void panelDefault_Click(object sender, System.EventArgs e)	{ ClientToScreen(VideoGrabberFormPositionType.Default);						Panel_Click(panelDefault); }


		private void visibleTimer_Tick(object sender, System.EventArgs e)
		{
			Hide();
		}

		private void VideoGrabberFormPosition_MouseEnter(object sender, System.EventArgs e)
		{
			visibleTimer.Stop();
		}

		private void VideoGrabberFormPosition_MouseLeave(object sender, System.EventArgs e)
		{
			visibleTimer.Start();		
		}	

		void OnPositionChanged()
		{
			if(PositionChanged != null)
			{
				PositionChanged(this, EventArgs.Empty);
			}
		}			
		
	}

	public enum VideoGrabberFormPositionType
	{
		Default,

		CornerUpperLeft,
		CornerUpperRight,
		CornerLowerLeft,
		CornerLowerRight,

		CornerMiddleLeft1,
		CornerMiddleLeft2,
		CornerMiddleLeftMiddle1,
		CornerMiddleLeftMiddle2,

		CornerMiddleRight1,
		CornerMiddleRight2,
		CornerMiddleRightMiddle1,
		CornerMiddleRightMiddle2,

		CornerMiddleLeftUpper,
		CornerMiddleLeftLower,
		CornerMiddleRightUpper,
		CornerMiddleRightLower,

		CenterHLeft,
		CenterHLeftMiddle,
		CenterH,
		CenterHRightMiddle,
		CenterHRight,

		CenterVUpper,
		CenterVMiddleUpper,
		CenterV,
		CenterVMiddleLower,
		CenterVLower
	}

}

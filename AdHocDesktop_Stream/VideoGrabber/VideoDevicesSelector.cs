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
using System.Windows.Forms;

using Microsoft.DirectX.DirectShow;

namespace Microsoft.DirectX.VideoGrabber
{
	public class VideoDevicesSelector : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labelStatic;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox videoDevice1TextBox;
		private System.Windows.Forms.TextBox videoDevice2TextBox;
		private System.Windows.Forms.TextBox videoDevice3TextBox;
		private System.Windows.Forms.TextBox videoDevice4TextBox;
		private System.Windows.Forms.TextBox videoDevice5TextBox;
		private System.Windows.Forms.TextBox videoDevice6TextBox;
		private System.Windows.Forms.TextBox videoDevice7TextBox;
		private System.Windows.Forms.TextBox videoDevice8TextBox;
		/// <summary> Required designer variable. </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.CheckBox videoDevice1CheckBox;
		private System.Windows.Forms.CheckBox videoDevice2CheckBox;
		private System.Windows.Forms.CheckBox videoDevice4CheckBox;
		private System.Windows.Forms.CheckBox videoDevice3CheckBox;
		private System.Windows.Forms.CheckBox videoDevice6CheckBox;
		private System.Windows.Forms.CheckBox videoDevice5CheckBox;
		private System.Windows.Forms.CheckBox videoDevice8CheckBox;
		private System.Windows.Forms.CheckBox videoDevice7CheckBox;

        VideoGrabberForm[] videoGrabberForms = new VideoGrabberForm[8];
		DsDevice[] devices;

		public int Count
		{
			get
			{
				return DsDevice.GetDevicesOfCat( FilterCategory.VideoInputDevice ).Length;
			}
		}

		public VideoDevicesSelector( )
		{
			InitializeComponent();
			Initialize();
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
			this.labelStatic = new System.Windows.Forms.Label();
			this.videoDevice1CheckBox = new System.Windows.Forms.CheckBox();
			this.okButton = new System.Windows.Forms.Button();
			this.videoDevice2CheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.videoDevice4CheckBox = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.videoDevice3CheckBox = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.videoDevice6CheckBox = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.videoDevice5CheckBox = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.videoDevice8CheckBox = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.videoDevice7CheckBox = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.videoDevice1TextBox = new System.Windows.Forms.TextBox();
			this.videoDevice2TextBox = new System.Windows.Forms.TextBox();
			this.videoDevice3TextBox = new System.Windows.Forms.TextBox();
			this.videoDevice4TextBox = new System.Windows.Forms.TextBox();
			this.videoDevice5TextBox = new System.Windows.Forms.TextBox();
			this.videoDevice6TextBox = new System.Windows.Forms.TextBox();
			this.videoDevice7TextBox = new System.Windows.Forms.TextBox();
			this.videoDevice8TextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelStatic
			// 
			this.labelStatic.Location = new System.Drawing.Point(8, 24);
			this.labelStatic.Name = "labelStatic";
			this.labelStatic.Size = new System.Drawing.Size(78, 15);
			this.labelStatic.TabIndex = 8;
			this.labelStatic.Text = "視訊裝置 #1: ";
			// 
			// videoDevice1CheckBox
			// 
			this.videoDevice1CheckBox.Enabled = false;
			this.videoDevice1CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice1CheckBox.Location = new System.Drawing.Point(320, 24);
			this.videoDevice1CheckBox.Name = "videoDevice1CheckBox";
			this.videoDevice1CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice1CheckBox.TabIndex = 29;
			this.videoDevice1CheckBox.Text = "啟動";
			this.videoDevice1CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice1CheckBox_CheckedChanged);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(161, 288);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(64, 24);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "確定";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// videoDevice2CheckBox
			// 
			this.videoDevice2CheckBox.Enabled = false;
			this.videoDevice2CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice2CheckBox.Location = new System.Drawing.Point(320, 56);
			this.videoDevice2CheckBox.Name = "videoDevice2CheckBox";
			this.videoDevice2CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice2CheckBox.TabIndex = 32;
			this.videoDevice2CheckBox.Text = "啟動";
			this.videoDevice2CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice2CheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 15);
			this.label1.TabIndex = 30;
			this.label1.Text = "視訊裝置 #2: ";
			// 
			// videoDevice4CheckBox
			// 
			this.videoDevice4CheckBox.Enabled = false;
			this.videoDevice4CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice4CheckBox.Location = new System.Drawing.Point(320, 120);
			this.videoDevice4CheckBox.Name = "videoDevice4CheckBox";
			this.videoDevice4CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice4CheckBox.TabIndex = 38;
			this.videoDevice4CheckBox.Text = "啟動";
			this.videoDevice4CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice4CheckBox_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 15);
			this.label2.TabIndex = 36;
			this.label2.Text = "視訊裝置 #4: ";
			// 
			// videoDevice3CheckBox
			// 
			this.videoDevice3CheckBox.Enabled = false;
			this.videoDevice3CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice3CheckBox.Location = new System.Drawing.Point(320, 88);
			this.videoDevice3CheckBox.Name = "videoDevice3CheckBox";
			this.videoDevice3CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice3CheckBox.TabIndex = 35;
			this.videoDevice3CheckBox.Text = "啟動";
			this.videoDevice3CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice3CheckBox_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 15);
			this.label3.TabIndex = 33;
			this.label3.Text = "視訊裝置 #3: ";
			// 
			// videoDevice6CheckBox
			// 
			this.videoDevice6CheckBox.Enabled = false;
			this.videoDevice6CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice6CheckBox.Location = new System.Drawing.Point(320, 184);
			this.videoDevice6CheckBox.Name = "videoDevice6CheckBox";
			this.videoDevice6CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice6CheckBox.TabIndex = 44;
			this.videoDevice6CheckBox.Text = "啟動";
			this.videoDevice6CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice6CheckBox_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 15);
			this.label4.TabIndex = 42;
			this.label4.Text = "視訊裝置 #6: ";
			// 
			// videoDevice5CheckBox
			// 
			this.videoDevice5CheckBox.Enabled = false;
			this.videoDevice5CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice5CheckBox.Location = new System.Drawing.Point(320, 152);
			this.videoDevice5CheckBox.Name = "videoDevice5CheckBox";
			this.videoDevice5CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice5CheckBox.TabIndex = 41;
			this.videoDevice5CheckBox.Text = "啟動";
			this.videoDevice5CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice5CheckBox_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 15);
			this.label5.TabIndex = 39;
			this.label5.Text = "視訊裝置 #5: ";
			// 
			// videoDevice8CheckBox
			// 
			this.videoDevice8CheckBox.Enabled = false;
			this.videoDevice8CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice8CheckBox.Location = new System.Drawing.Point(320, 248);
			this.videoDevice8CheckBox.Name = "videoDevice8CheckBox";
			this.videoDevice8CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice8CheckBox.TabIndex = 50;
			this.videoDevice8CheckBox.Text = "啟動";
			this.videoDevice8CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice8CheckBox_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 248);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 15);
			this.label6.TabIndex = 48;
			this.label6.Text = "視訊裝置 #8: ";
			// 
			// videoDevice7CheckBox
			// 
			this.videoDevice7CheckBox.Enabled = false;
			this.videoDevice7CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.videoDevice7CheckBox.Location = new System.Drawing.Point(320, 216);
			this.videoDevice7CheckBox.Name = "videoDevice7CheckBox";
			this.videoDevice7CheckBox.Size = new System.Drawing.Size(48, 24);
			this.videoDevice7CheckBox.TabIndex = 47;
			this.videoDevice7CheckBox.Text = "啟動";
			this.videoDevice7CheckBox.CheckedChanged += new System.EventHandler(this.videoDevice7CheckBox_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 216);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 15);
			this.label7.TabIndex = 45;
			this.label7.Text = "視訊裝置 #7: ";
			// 
			// videoDevice1TextBox
			// 
			this.videoDevice1TextBox.Location = new System.Drawing.Point(88, 24);
			this.videoDevice1TextBox.Name = "videoDevice1TextBox";
			this.videoDevice1TextBox.ReadOnly = true;
			this.videoDevice1TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice1TextBox.TabIndex = 51;
			this.videoDevice1TextBox.Text = "";
			// 
			// videoDevice2TextBox
			// 
			this.videoDevice2TextBox.Location = new System.Drawing.Point(88, 56);
			this.videoDevice2TextBox.Name = "videoDevice2TextBox";
			this.videoDevice2TextBox.ReadOnly = true;
			this.videoDevice2TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice2TextBox.TabIndex = 52;
			this.videoDevice2TextBox.Text = "";
			// 
			// videoDevice3TextBox
			// 
			this.videoDevice3TextBox.Location = new System.Drawing.Point(88, 88);
			this.videoDevice3TextBox.Name = "videoDevice3TextBox";
			this.videoDevice3TextBox.ReadOnly = true;
			this.videoDevice3TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice3TextBox.TabIndex = 53;
			this.videoDevice3TextBox.Text = "";
			// 
			// videoDevice4TextBox
			// 
			this.videoDevice4TextBox.Location = new System.Drawing.Point(88, 120);
			this.videoDevice4TextBox.Name = "videoDevice4TextBox";
			this.videoDevice4TextBox.ReadOnly = true;
			this.videoDevice4TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice4TextBox.TabIndex = 54;
			this.videoDevice4TextBox.Text = "";
			// 
			// videoDevice5TextBox
			// 
			this.videoDevice5TextBox.Location = new System.Drawing.Point(89, 152);
			this.videoDevice5TextBox.Name = "videoDevice5TextBox";
			this.videoDevice5TextBox.ReadOnly = true;
			this.videoDevice5TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice5TextBox.TabIndex = 55;
			this.videoDevice5TextBox.Text = "";
			// 
			// videoDevice6TextBox
			// 
			this.videoDevice6TextBox.Location = new System.Drawing.Point(88, 184);
			this.videoDevice6TextBox.Name = "videoDevice6TextBox";
			this.videoDevice6TextBox.ReadOnly = true;
			this.videoDevice6TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice6TextBox.TabIndex = 56;
			this.videoDevice6TextBox.Text = "";
			// 
			// videoDevice7TextBox
			// 
			this.videoDevice7TextBox.Location = new System.Drawing.Point(89, 216);
			this.videoDevice7TextBox.Name = "videoDevice7TextBox";
			this.videoDevice7TextBox.ReadOnly = true;
			this.videoDevice7TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice7TextBox.TabIndex = 57;
			this.videoDevice7TextBox.Text = "";
			// 
			// videoDevice8TextBox
			// 
			this.videoDevice8TextBox.Location = new System.Drawing.Point(89, 248);
			this.videoDevice8TextBox.Name = "videoDevice8TextBox";
			this.videoDevice8TextBox.ReadOnly = true;
			this.videoDevice8TextBox.Size = new System.Drawing.Size(208, 22);
			this.videoDevice8TextBox.TabIndex = 58;
			this.videoDevice8TextBox.Text = "";
			// 
			// VideoDevicesSelector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(386, 336);
			this.ControlBox = false;
			this.Controls.Add(this.videoDevice8TextBox);
			this.Controls.Add(this.videoDevice7TextBox);
			this.Controls.Add(this.videoDevice6TextBox);
			this.Controls.Add(this.videoDevice5TextBox);
			this.Controls.Add(this.videoDevice4TextBox);
			this.Controls.Add(this.videoDevice3TextBox);
			this.Controls.Add(this.videoDevice2TextBox);
			this.Controls.Add(this.videoDevice1TextBox);
			this.Controls.Add(this.videoDevice8CheckBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.videoDevice7CheckBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.videoDevice6CheckBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.videoDevice5CheckBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.videoDevice4CheckBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.videoDevice3CheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.videoDevice2CheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.videoDevice1CheckBox);
			this.Controls.Add(this.labelStatic);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VideoDevicesSelector";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "進階視訊裝置設定";
			this.ResumeLayout(false);

		}
		#endregion

		void Initialize()
		{
			if( (devices = DsDevice.GetDevicesOfCat( FilterCategory.VideoInputDevice )) == null )
			{
				throw new VideoGrabberException("未偵測到任何視訊裝置！");
			}

			if(devices.Length >= 1)	SetVideoDeviceUI(videoDevice1TextBox, videoDevice1CheckBox, 0);			
			if(devices.Length >= 2)	SetVideoDeviceUI(videoDevice2TextBox, videoDevice2CheckBox, 1);
			if(devices.Length >= 3)	SetVideoDeviceUI(videoDevice3TextBox, videoDevice3CheckBox, 2);
			if(devices.Length >= 4)	SetVideoDeviceUI(videoDevice4TextBox, videoDevice4CheckBox, 3);
			if(devices.Length >= 5)	SetVideoDeviceUI(videoDevice5TextBox, videoDevice5CheckBox, 4);
			if(devices.Length >= 6)	SetVideoDeviceUI(videoDevice6TextBox, videoDevice6CheckBox, 5);
			if(devices.Length >= 7)	SetVideoDeviceUI(videoDevice7TextBox, videoDevice7CheckBox, 6);
			if(devices.Length >= 8)	SetVideoDeviceUI(videoDevice8TextBox, videoDevice8CheckBox, 7);			
		}

		protected override void SetVisibleCore(bool value)
		{
			if(value)
			{
				Initialize();
			}
			base.SetVisibleCore (value);
		}

		void SetVideoDeviceUI(TextBox textBox, CheckBox checkBox, int deviceNum)
		{
			textBox.Text = devices[deviceNum].Name;
			checkBox.Enabled = true;
		}
		
		public bool IsShownVideoGrabberForm()
		{
			foreach(VideoGrabberForm form in videoGrabberForms)
			{
				if(form != null)
				{
					if(form.Visible == true)
					{
						return true;
					}
				}
			}
			return false;
		}

        public void HideAllVideoGrabberForm()
        {
            for (int i = 0; i < videoGrabberForms.Length; i++)
            {
                if (videoGrabberForms[i] != null)
                {
                    videoGrabberForms[i].Dispose();
                    videoGrabberForms[i] = null;
                }
            }
        }

		public void ShowVideoGrabberForm(int deviceNum, bool enable)
		{
			// Fixed when a device inputs later.
			devices = DsDevice.GetDevicesOfCat( FilterCategory.VideoInputDevice );
			if(devices.Length > deviceNum)
			{
				if(enable)
				{
					if(videoGrabberForms[deviceNum] != null)
					{
                        videoGrabberForms[deviceNum].Dispose();
                        videoGrabberForms[deviceNum] = null;
					}
					try
					{
                        videoGrabberForms[deviceNum] = new VideoGrabberForm(devices[deviceNum]);
                        videoGrabberForms[deviceNum].Show();
						Point location = Point.Empty;
						switch(deviceNum)
						{
                            case 0: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.Default); break;
                            case 1: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.CornerMiddleRightLower); break;
                            case 2: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.CornerMiddleRight2); break;
                            case 3: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.CornerMiddleRightUpper); break;
                            case 4: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.CenterVLower); break;
                            case 5: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.CenterHRight); break;
                            case 6: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.CenterVMiddleLower); break;
                            case 7: videoGrabberForms[deviceNum].SetPosition(VideoGrabberFormPositionType.CenterHRightMiddle); break;				
						}
					}
					catch 
					{
						// 無法初始化指定的裝置號碼
                        videoGrabberForms[deviceNum].Dispose();
					}
				}
				else
				{
                    if (videoGrabberForms[deviceNum] != null)
					{
                        videoGrabberForms[deviceNum].Dispose();
                        videoGrabberForms[deviceNum] = null;
					}
				}
			}
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{			
			DialogResult = DialogResult.Cancel;		
		}

		private void videoDevice1CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(0, videoDevice1CheckBox.Checked);	}
		private void videoDevice2CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(1, videoDevice2CheckBox.Checked);	}
		private void videoDevice3CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(2, videoDevice3CheckBox.Checked);	}
		private void videoDevice4CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(3, videoDevice4CheckBox.Checked);	}
		private void videoDevice5CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(4, videoDevice5CheckBox.Checked);	}
		private void videoDevice6CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(5, videoDevice6CheckBox.Checked);	}
		private void videoDevice7CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(6, videoDevice7CheckBox.Checked);	}
		private void videoDevice8CheckBox_CheckedChanged(object sender, System.EventArgs e)	{ ShowVideoGrabberForm(7, videoDevice8CheckBox.Checked);	}
	}

}

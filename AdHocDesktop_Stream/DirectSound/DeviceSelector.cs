using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

/*
Error Message:

LoaderLock was detected
Message: DLL '.......\Microsoft.DirectX.DirectSound.dll' is attempting 
managed execution inside OS Loader lock. Do not attempt to run 
managed code inside a DllMain or image initialization function since
doing so can cause the application to hang.A Loader lock is one of the Managed Debugging Assistants (MDAs) that were added to VS2005 to help find hard to debug runtime issues. There is code in all Managed DirectX 1.1 assemblies that causes this MDA to fire. Microsoft have confirmed they are aware of the problem. However I do not expect to see a fix for MDX 1.1 since current efforts are focused on MDX2.0/XNA Framework, it ONLY affects code run under the debugger (i.e. it won't happen when users run your EXE) and there is a trivial workaround. I'm not sure of exact reproduction steps - it appears to fire on some projects and not on others.

To work around the problem you have several choices:

Go back to using VS2003 and .Net 1.1 
Use MDX 2.0. Note that MDX 2.0 will never actually ship as it is being transformed into the XNA framework. 
Disable the loader lock MDA. Debug/Exceptions (ctrl-D, E), Open the Managed Debugging Assistants tree node and uncheck Loader Lock. This setting is per solution so it will only affect this solution. 
Versions affected:All .Net 1.1 Managed DirectX assemblies when used with Visual Studio 2005 and .Net 2.0.
*/

namespace AdHocDesktop.Stream.DirectSound
{
	public class DeviceSelector : Form
	{
		private Button buttonOk;
		private Button buttonCancel;
		private Label labelStatic;
		private ComboBox comboboxCaptureDeviceCombo;

		CaptureDevicesCollection devices;
		DeviceInformation selectedDevice;
        
		public DeviceInformation SelectedDevice
		{
			get
			{
				return selectedDevice;
			}
		}

		public int SelectedDeviceIndex
		{
			get
			{
				return comboboxCaptureDeviceCombo.SelectedIndex;
			}
		}

		public CaptureDevicesCollection Devices
		{
			get
			{
				return devices;
			}
		}

		public DeviceSelector()
		{		
			InitializeComponent();

            // 
			devices = new CaptureDevicesCollection();
            /*
			if(devices == null || devices.Count == 0)
			{
				throw new ArgumentException("未偵測到任何音訊裝置！");
			}
            */

			if(devices.Count >= 1)
			{
				// devices[0] = "主要音效驅動程式"
				selectedDevice = devices[0];

				DeviceInformation info;
				for( int i=0; i < devices.Count; i++)
				{
					info = devices[i];
					comboboxCaptureDeviceCombo.Items.Add(info.Description);
				}	
				comboboxCaptureDeviceCombo.SelectedIndex = 0;
                selectedDevice = devices[comboboxCaptureDeviceCombo.SelectedIndex];
			}			
		}

		#region InitializeComponent code
		private void InitializeComponent()
		{
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelStatic = new System.Windows.Forms.Label();
			this.comboboxCaptureDeviceCombo = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOk.Location = new System.Drawing.Point(89, 47);
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
			this.buttonCancel.Location = new System.Drawing.Point(164, 47);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 24);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelStatic
			// 
			this.labelStatic.Location = new System.Drawing.Point(10, 16);
			this.labelStatic.Name = "labelStatic";
			this.labelStatic.Size = new System.Drawing.Size(78, 15);
			this.labelStatic.TabIndex = 2;
			this.labelStatic.Text = "裝置名稱：";
			// 
			// comboboxCaptureDeviceCombo
			// 
			this.comboboxCaptureDeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboboxCaptureDeviceCombo.Location = new System.Drawing.Point(93, 13);
			this.comboboxCaptureDeviceCombo.Name = "comboboxCaptureDeviceCombo";
			this.comboboxCaptureDeviceCombo.Size = new System.Drawing.Size(213, 20);
			this.comboboxCaptureDeviceCombo.TabIndex = 3;
			// 
			// DeviceSelector
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(316, 91);
			this.ControlBox = false;
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelStatic);
			this.Controls.Add(this.comboboxCaptureDeviceCombo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DeviceSelector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "選擇音訊來源裝置";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOk_Click(object sender, System.EventArgs e)
		{
			if (comboboxCaptureDeviceCombo.SelectedIndex >= 0)
			{
				selectedDevice = devices[comboboxCaptureDeviceCombo.SelectedIndex];
			}

			DialogResult = DialogResult.OK;
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}		
	}
}

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
using System.Runtime.InteropServices;

using Microsoft.DirectX.DirectShow;

namespace Microsoft.DirectX.VideoGrabber
{


/// <summary> Dialog to let user select a capture device if more then one installed. </summary>
public class DeviceSelector : System.Windows.Forms.Form
{
	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Button cancelButton;
	/// <summary> Required designer variable. </summary>
	private System.ComponentModel.Container components = null;

	DsDevice selectedDevice;
	private System.Windows.Forms.Label labelStatic;
	private System.Windows.Forms.ComboBox comboboxCaptureDeviceCombo;
	DsDevice[] devices;

	public DsDevice SelectedDevice
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

	public DsDevice[] Devices
	{
		get
		{
			return devices;
		}
	}

	public DeviceSelector( )
	{
		// Required for Windows Form Designer support
		InitializeComponent();

		if( (devices = DsDevice.GetDevicesOfCat( FilterCategory.VideoInputDevice )) == null )
		{
			throw new VideoGrabberException("未偵測到任何視訊裝置！");
		}

		if(devices.Length >= 1)
		{
			selectedDevice = devices[0];

			foreach( DsDevice d in devices )
			{
				comboboxCaptureDeviceCombo.Items.Add(d.Name);
			}
			comboboxCaptureDeviceCombo.SelectedIndex = 0;
		}				
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
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.labelStatic = new System.Windows.Forms.Label();
			this.comboboxCaptureDeviceCombo = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(89, 47);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(64, 24);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "確定";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancelButton.Location = new System.Drawing.Point(164, 47);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(64, 24);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "取消";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// labelStatic
			// 
			this.labelStatic.Location = new System.Drawing.Point(10, 16);
			this.labelStatic.Name = "labelStatic";
			this.labelStatic.Size = new System.Drawing.Size(78, 15);
			this.labelStatic.TabIndex = 4;
			this.labelStatic.Text = "裝置名稱：";
			// 
			// comboboxCaptureDeviceCombo
			// 
			this.comboboxCaptureDeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboboxCaptureDeviceCombo.Location = new System.Drawing.Point(93, 13);
			this.comboboxCaptureDeviceCombo.Name = "comboboxCaptureDeviceCombo";
			this.comboboxCaptureDeviceCombo.Size = new System.Drawing.Size(213, 20);
			this.comboboxCaptureDeviceCombo.TabIndex = 5;
			// 
			// DeviceSelector
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(316, 91);
			this.ControlBox = false;
			this.Controls.Add(this.labelStatic);
			this.Controls.Add(this.comboboxCaptureDeviceCombo);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeviceSelector";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "選擇視訊輸入裝置";
			this.ResumeLayout(false);

		}
		#endregion


	private void deviceListVw_DoubleClick(object sender, System.EventArgs e)
	{
		this.okButton_Click( sender, e );
	}

	private void okButton_Click(object sender, System.EventArgs e)
	{
		if (comboboxCaptureDeviceCombo.SelectedIndex >= 0)
		{
			selectedDevice = devices[comboboxCaptureDeviceCombo.SelectedIndex];
		}
		Close();
	}

	private void cancelButton_Click(object sender, System.EventArgs e)
	{
		selectedDevice = null;
		Close();
	}    
}

}

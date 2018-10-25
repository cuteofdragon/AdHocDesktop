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
	public class VideoGrabberForm : MovableForm
	{
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.MenuItem _160x120MenuItem;
		private System.Windows.Forms.MenuItem _320x240MenuItem;
		private System.Windows.Forms.MenuItem _640x480MenuItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem closeMenuItem;
		private System.Windows.Forms.MenuItem moveMenuItem;
		private System.Windows.Forms.MenuItem resetMenuItem_Click;
		private System.Windows.Forms.MenuItem _fullScreenMenuItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem positionMenuItem;	
		
		private System.ComponentModel.Container components = null;

		readonly Size defulatSize = new Size(160, 120);
		VideoGrabberPanel videoGrabberPanel;			
		bool isMoveMode = false;
		private System.Windows.Forms.MenuItem positionShowMenuItem;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem showFormBorderMenuItem;
		VideoGrabberFormPosition positionForm = new VideoGrabberFormPosition();

		public VideoGrabberForm(DsDevice device)
		{
			InitializeComponent();
			positionForm.PositionChanged += new EventHandler(positionForm_PositionChanged);
			try
			{				
				videoGrabberPanel = new VideoGrabberPanel(device);
				
				videoGrabberPanel.Dock = DockStyle.Fill;
				videoGrabberPanel.ContextMenu = contextMenu;
				videoGrabberPanel.MouseDown += new MouseEventHandler(videoGrabberPanel_MouseDown);
				videoGrabberPanel.MouseMove += new MouseEventHandler(videoGrabberPanel_MouseMove);
				videoGrabberPanel.MouseUp += new MouseEventHandler(videoGrabberPanel_MouseUp);
				this.Controls.Add(videoGrabberPanel);
				videoGrabberPanel.BeginPreview();
			}
			catch
			{
				MessageBox.Show("視訊裝置初始化失敗！");
				//this.Dispose(); // don't dispose it, because we should show the black form.
				throw;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch(keyData)
			{
				case Keys.Q:  SetPosition(VideoGrabberFormPositionType.CornerUpperLeft);	break;
				case Keys.Z:  SetPosition(VideoGrabberFormPositionType.CornerLowerLeft);	break;
				case Keys.E:  SetPosition(VideoGrabberFormPositionType.CornerUpperRight);	break;
				case Keys.C:  SetPosition(VideoGrabberFormPositionType.CornerLowerRight);	break;
				case Keys.S:  SetPosition(VideoGrabberFormPositionType.CenterH);			break;
				case Keys.D:  SetPosition(VideoGrabberFormPositionType.Default);			break;
			}
			return base.ProcessDialogKey (keyData);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this._160x120MenuItem = new System.Windows.Forms.MenuItem();
			this._320x240MenuItem = new System.Windows.Forms.MenuItem();
			this._640x480MenuItem = new System.Windows.Forms.MenuItem();
			this._fullScreenMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.moveMenuItem = new System.Windows.Forms.MenuItem();
			this.positionMenuItem = new System.Windows.Forms.MenuItem();
			this.positionShowMenuItem = new System.Windows.Forms.MenuItem();
			this.resetMenuItem_Click = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.showFormBorderMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.closeMenuItem = new System.Windows.Forms.MenuItem();
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this._160x120MenuItem,
																						this._320x240MenuItem,
																						this._640x480MenuItem,
																						this._fullScreenMenuItem,
																						this.menuItem1,
																						this.moveMenuItem,
																						this.positionMenuItem,
																						this.resetMenuItem_Click,
																						this.menuItem3,
																						this.showFormBorderMenuItem,
																						this.menuItem2,
																						this.closeMenuItem});
			// 
			// _160x120MenuItem
			// 
			this._160x120MenuItem.Checked = true;
			this._160x120MenuItem.Index = 0;
			this._160x120MenuItem.Shortcut = System.Windows.Forms.Shortcut.F5;
			this._160x120MenuItem.Text = "160 x 120";
			this._160x120MenuItem.Click += new System.EventHandler(this._160x120MenuItem_Click);
			// 
			// _320x240MenuItem
			// 
			this._320x240MenuItem.Index = 1;
			this._320x240MenuItem.Shortcut = System.Windows.Forms.Shortcut.F6;
			this._320x240MenuItem.Text = "320 x 240";
			this._320x240MenuItem.Click += new System.EventHandler(this._320x240MenuItem_Click);
			// 
			// _640x480MenuItem
			// 
			this._640x480MenuItem.Index = 2;
			this._640x480MenuItem.Shortcut = System.Windows.Forms.Shortcut.F7;
			this._640x480MenuItem.Text = "640 x 480";
			this._640x480MenuItem.Click += new System.EventHandler(this._640x480MenuItem_Click);
			// 
			// _fullScreenMenuItem
			// 
			this._fullScreenMenuItem.Index = 3;
			this._fullScreenMenuItem.Shortcut = System.Windows.Forms.Shortcut.F8;
			this._fullScreenMenuItem.Text = "全螢幕";
			this._fullScreenMenuItem.Click += new System.EventHandler(this._fullScreenMenuItem_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "-";
			// 
			// moveMenuItem
			// 
			this.moveMenuItem.Index = 5;
			this.moveMenuItem.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.moveMenuItem.Text = "移動";
			this.moveMenuItem.Click += new System.EventHandler(this.moveMenuItem_Click);
			// 
			// positionMenuItem
			// 
			this.positionMenuItem.Index = 6;
			this.positionMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.positionShowMenuItem});
			this.positionMenuItem.Text = "定位";
			// 
			// positionShowMenuItem
			// 
			this.positionShowMenuItem.Index = 0;
			this.positionShowMenuItem.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.positionShowMenuItem.Text = "顯示設定面版";
			this.positionShowMenuItem.Click += new System.EventHandler(this.positionShowMenuItem_Click);
			// 
			// resetMenuItem_Click
			// 
			this.resetMenuItem_Click.Index = 7;
			this.resetMenuItem_Click.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.resetMenuItem_Click.Text = "重設";
			this.resetMenuItem_Click.Click += new System.EventHandler(this.resetMenuItem_Click_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 8;
			this.menuItem3.Text = "-";
			// 
			// showFormBorderMenuItem
			// 
			this.showFormBorderMenuItem.Index = 9;
			this.showFormBorderMenuItem.Shortcut = System.Windows.Forms.Shortcut.F9;
			this.showFormBorderMenuItem.Text = "控制列";
			this.showFormBorderMenuItem.Click += new System.EventHandler(this.showFormBorderMenuItem_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 10;
			this.menuItem2.Text = "-";
			// 
			// closeMenuItem
			// 
			this.closeMenuItem.Index = 11;
			this.closeMenuItem.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.closeMenuItem.Text = "關閉";
			this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
			// 
			// VideoGrabberForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(160, 60);
			this.ContextMenu = this.contextMenu;
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "VideoGrabberForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "視訊畫面";
			this.TopMost = true;

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			_160x120MenuItem.PerformClick();
			base.OnLoad (e);
		}

		void SetLocation(int width, int height)
		{
			Rectangle r = Screen.PrimaryScreen.WorkingArea;
			this.Location = new Point(r.Width - width, r.Height - height);
		}

		void ResetContextMenuItem()
		{
			_160x120MenuItem.Checked = false;
			_320x240MenuItem.Checked = false;
			_640x480MenuItem.Checked = false;
			_fullScreenMenuItem.Checked = false;
		}

		public void SetSize(int width, int height)
		{
			SetLocation(width, height);
			this.Size = new Size(width, height);
		}

		private void _160x120MenuItem_Click(object sender, System.EventArgs e)
		{
			SetSize(160, 120);
			ResetContextMenuItem();
			_160x120MenuItem.Checked = true;
		}

		private void _320x240MenuItem_Click(object sender, System.EventArgs e)
		{
			SetSize(320, 240);
			ResetContextMenuItem();
			_320x240MenuItem.Checked = true;		
		}

		private void _640x480MenuItem_Click(object sender, System.EventArgs e)
		{
			SetSize(640, 480);
			ResetContextMenuItem();
			_640x480MenuItem.Checked = true;
		}

		private void _fullScreenMenuItem_Click(object sender, System.EventArgs e)
		{
			Size size = Screen.PrimaryScreen.Bounds.Size;
			Rectangle r = Screen.PrimaryScreen.Bounds;
			this.Location = new Point(0, 1);
			this.Size = new Size(size.Width, size.Height - 1);
			ResetContextMenuItem();
			_fullScreenMenuItem.Checked = true;
		}

		private void closeMenuItem_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void videoGrabberPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.OnMouseDown(e);
		}

		private void videoGrabberPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.OnMouseMove(e);
		}

		private void videoGrabberPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(isMoveMode)
			{
				isMoveMode = false;
				videoGrabberPanel.BeginPreview();
			}		
		}
		
		private void moveMenuItem_Click(object sender, System.EventArgs e)
		{
			videoGrabberPanel.EndPreview();
			Cursor = Cursors.SizeAll;
            isMoveMode = true;
		}

		public void SetCenterScreen()
		{
			Rectangle r = Screen.PrimaryScreen.Bounds;

			int centerX = r.Width / 2;
			int centerY = r.Height / 2;

			this.Location = new Point(centerX - this.Width / 2, centerY - this.Height / 2);			
		}

		public void Reset()
		{
			ResetContextMenuItem();
			this.Size = defulatSize;
			SetLocation(defulatSize.Width, defulatSize.Height);
		}

		private void resetMenuItem_Click_Click(object sender, System.EventArgs e)
		{
			Reset();
		}

		private void positionShowMenuItem_Click(object sender, System.EventArgs e)
		{
			positionForm.VideoGrabberFormSize = this.Size;
			positionForm.Show();
		}

		private void positionForm_PositionChanged(object sender, EventArgs e)
		{
			this.Location = positionForm.SelectedPosition;
		}

		public void SetPosition(VideoGrabberFormPositionType type)
		{
			positionForm.VideoGrabberFormSize = this.Size;
			positionForm.ClientToScreen(type);
		}

		private void showFormBorderMenuItem_Click(object sender, System.EventArgs e)
		{
			if(this.FormBorderStyle == FormBorderStyle.None)
			{
				this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			}
			else
			{
				this.FormBorderStyle = FormBorderStyle.None;
			}
		}
	}
}

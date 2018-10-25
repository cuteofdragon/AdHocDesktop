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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Microsoft.DirectX.VideoGrabber
{
	public class MovableForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

		protected Point mouseOffset;

		public Point MouseOffset
		{
			get
			{
				return mouseOffset;
			}
		}

		public MovableForm()
		{
			InitializeComponent();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MovableForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "MovableForm";
			this.Text = "MovableForm";

		}
		#endregion		

		protected void MoveToMousePosition()
		{
			Point mousePos = Control.MousePosition;
			mousePos.Offset(mouseOffset.X, mouseOffset.Y);
			Location = mousePos;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			mouseOffset = new Point(-e.X, -e.Y);
			base.OnMouseDown (e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			Cursor = Cursors.SizeAll;
			if (e.Button == MouseButtons.Left) 
			{
				MoveToMousePosition();
			}
			base.OnMouseMove (e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
		}

	}
}

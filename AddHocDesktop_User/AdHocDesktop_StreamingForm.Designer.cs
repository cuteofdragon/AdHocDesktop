using AdHocDesktop.Tcp;

namespace AdHocDesktop.User
{
    partial class AdHocDesktop_StreamingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (soundPlayer != null)
                {
                    soundPlayer.Dispose();
                }
                if (user != null)
                {
                    user.Received -= new AdHocDesktop_TcpReceivedEventHandler(user_Received);
                }
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topPanel = new System.Windows.Forms.Panel();
            this.quietAudioLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoPanel
            // 
            this.videoPanel.BackColor = System.Drawing.Color.Black;
            this.videoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.videoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPanel.Location = new System.Drawing.Point(0, 24);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(240, 180);
            this.videoPanel.TabIndex = 0;
            this.videoPanel.DoubleClick += new System.EventHandler(this.videoPanel_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 26);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.fullScreenToolStripMenuItem.Text = "切換全螢幕";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.quietAudioLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(240, 24);
            this.topPanel.TabIndex = 1;
            // 
            // quietAudioLabel
            // 
            this.quietAudioLabel.AutoSize = true;
            this.quietAudioLabel.ForeColor = System.Drawing.Color.Black;
            this.quietAudioLabel.Location = new System.Drawing.Point(3, 6);
            this.quietAudioLabel.Name = "quietAudioLabel";
            this.quietAudioLabel.Size = new System.Drawing.Size(53, 12);
            this.quietAudioLabel.TabIndex = 0;
            this.quietAudioLabel.Text = "靜音模式";
            this.quietAudioLabel.Visible = false;
            // 
            // AdHocDesktop_StreamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 204);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AdHocDesktop_StreamingForm";
            this.Opacity = 0.99;
            this.Text = "隨意桌面傳送視窗";
            this.TopMost = true;
            this.contextMenuStrip1.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.Label quietAudioLabel;
    }
}
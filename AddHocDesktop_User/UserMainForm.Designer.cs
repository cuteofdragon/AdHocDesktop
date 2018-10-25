using AdHocDesktop.Core;
using AdHocDesktop.Tcp;

namespace AdHocDesktop.User
{
    partial class UserMainForm
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
                if (user != null)
                {
                    StopAdHocDesktopStreamWriter();
                        
                    try
                    {
                        user.Send(new AdHocDesktop.Tcp.AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.Interrupt, profile.Src, profile.Dest, new byte[1]));                        
                    }
                    catch { }
                    user.Stop();
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("交誼大廳");
            this.loginPanel = new System.Windows.Forms.Panel();
            this.copyLogButton = new System.Windows.Forms.Button();
            this.pwTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.msgTextBox = new System.Windows.Forms.TextBox();
            this.connectTextBox = new System.Windows.Forms.TextBox();
            this.localConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.userPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.userTreeView = new System.Windows.Forms.TreeView();
            this.userContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adHocDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adHocDesktopConferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adHocDesktopAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adHocDesktopScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adHocDesktopCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userBottomPanel = new System.Windows.Forms.Panel();
            this.userTopPanel = new System.Windows.Forms.Panel();
            this.stopButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.userLeftPanel = new System.Windows.Forms.Panel();
            this.groupContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inviteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userTimer = new System.Windows.Forms.Timer(this.components);
            this.loginPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.userContextMenuStrip.SuspendLayout();
            this.userTopPanel.SuspendLayout();
            this.groupContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.copyLogButton);
            this.loginPanel.Controls.Add(this.pwTextBox);
            this.loginPanel.Controls.Add(this.label4);
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Controls.Add(this.idTextBox);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.msgTextBox);
            this.loginPanel.Controls.Add(this.connectTextBox);
            this.loginPanel.Controls.Add(this.localConnectCheckBox);
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Controls.Add(this.connectButton);
            this.loginPanel.Location = new System.Drawing.Point(12, 21);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(217, 262);
            this.loginPanel.TabIndex = 11;
            // 
            // copyLogButton
            // 
            this.copyLogButton.Enabled = false;
            this.copyLogButton.Location = new System.Drawing.Point(12, 237);
            this.copyLogButton.Name = "copyLogButton";
            this.copyLogButton.Size = new System.Drawing.Size(75, 23);
            this.copyLogButton.TabIndex = 20;
            this.copyLogButton.Text = "複製";
            this.copyLogButton.UseVisualStyleBackColor = true;
            this.copyLogButton.Click += new System.EventHandler(this.copyLogButton_Click);
            // 
            // pwTextBox
            // 
            this.pwTextBox.Location = new System.Drawing.Point(48, 115);
            this.pwTextBox.Name = "pwTextBox";
            this.pwTextBox.Size = new System.Drawing.Size(100, 22);
            this.pwTextBox.TabIndex = 3;
            this.pwTextBox.Text = "guset1";
            this.pwTextBox.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "密碼:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "帳號:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(48, 86);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 22);
            this.idTextBox.TabIndex = 2;
            this.idTextBox.Text = "guest1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "訊息:";
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(12, 173);
            this.msgTextBox.Multiline = true;
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msgTextBox.Size = new System.Drawing.Size(199, 60);
            this.msgTextBox.TabIndex = 5;
            // 
            // connectTextBox
            // 
            this.connectTextBox.Location = new System.Drawing.Point(12, 27);
            this.connectTextBox.Name = "connectTextBox";
            this.connectTextBox.Size = new System.Drawing.Size(100, 22);
            this.connectTextBox.TabIndex = 0;
            // 
            // localConnectCheckBox
            // 
            this.localConnectCheckBox.AutoSize = true;
            this.localConnectCheckBox.Location = new System.Drawing.Point(12, 55);
            this.localConnectCheckBox.Name = "localConnectCheckBox";
            this.localConnectCheckBox.Size = new System.Drawing.Size(72, 16);
            this.localConnectCheckBox.TabIndex = 1;
            this.localConnectCheckBox.Text = "本機測試";
            this.localConnectCheckBox.UseVisualStyleBackColor = true;
            this.localConnectCheckBox.CheckedChanged += new System.EventHandler(this.localConnectCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "連線主機:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(134, 27);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "登入";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.panel4);
            this.userPanel.Controls.Add(this.userBottomPanel);
            this.userPanel.Controls.Add(this.userTopPanel);
            this.userPanel.Controls.Add(this.userLeftPanel);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPanel.Location = new System.Drawing.Point(0, 0);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(232, 286);
            this.userPanel.TabIndex = 24;
            this.userPanel.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.userTreeView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(31, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(201, 217);
            this.panel4.TabIndex = 4;
            // 
            // userTreeView
            // 
            this.userTreeView.ContextMenuStrip = this.userContextMenuStrip;
            this.userTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userTreeView.Location = new System.Drawing.Point(0, 0);
            this.userTreeView.Name = "userTreeView";
            treeNode1.Name = "usersNode";
            treeNode1.Text = "交誼大廳";
            this.userTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.userTreeView.Size = new System.Drawing.Size(201, 217);
            this.userTreeView.TabIndex = 1;
            this.userTreeView.Click += new System.EventHandler(this.userTreeView_Click);
            // 
            // userContextMenuStrip
            // 
            this.userContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adHocDesktopToolStripMenuItem,
            this.adHocDesktopConferenceToolStripMenuItem,
            this.adHocDesktopAudioToolStripMenuItem,
            this.adHocDesktopScreenToolStripMenuItem,
            this.adHocDesktopCameraToolStripMenuItem});
            this.userContextMenuStrip.Name = "userContextMenuStrip";
            this.userContextMenuStrip.Size = new System.Drawing.Size(143, 114);
            // 
            // adHocDesktopToolStripMenuItem
            // 
            this.adHocDesktopToolStripMenuItem.Name = "adHocDesktopToolStripMenuItem";
            this.adHocDesktopToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.adHocDesktopToolStripMenuItem.Text = "啟動隨意桌面";
            this.adHocDesktopToolStripMenuItem.Click += new System.EventHandler(this.adHocDesktopToolStripMenuItem_Click);
            // 
            // adHocDesktopConferenceToolStripMenuItem
            // 
            this.adHocDesktopConferenceToolStripMenuItem.Name = "adHocDesktopConferenceToolStripMenuItem";
            this.adHocDesktopConferenceToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.adHocDesktopConferenceToolStripMenuItem.Text = "啟動視訊會議";
            this.adHocDesktopConferenceToolStripMenuItem.Click += new System.EventHandler(this.adHocDesktopConferenceToolStripMenuItem_Click);
            // 
            // adHocDesktopAudioToolStripMenuItem
            // 
            this.adHocDesktopAudioToolStripMenuItem.Name = "adHocDesktopAudioToolStripMenuItem";
            this.adHocDesktopAudioToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.adHocDesktopAudioToolStripMenuItem.Text = "撥打電話聊天";
            this.adHocDesktopAudioToolStripMenuItem.Click += new System.EventHandler(this.adHocDesktopAudioToolStripMenuItem_Click);
            // 
            // adHocDesktopScreenToolStripMenuItem
            // 
            this.adHocDesktopScreenToolStripMenuItem.Name = "adHocDesktopScreenToolStripMenuItem";
            this.adHocDesktopScreenToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.adHocDesktopScreenToolStripMenuItem.Text = "傳送螢幕畫面";
            this.adHocDesktopScreenToolStripMenuItem.Click += new System.EventHandler(this.adHocDesktopScreenToolStripMenuItem_Click);
            // 
            // adHocDesktopCameraToolStripMenuItem
            // 
            this.adHocDesktopCameraToolStripMenuItem.Name = "adHocDesktopCameraToolStripMenuItem";
            this.adHocDesktopCameraToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.adHocDesktopCameraToolStripMenuItem.Text = "傳送視訊畫面";
            this.adHocDesktopCameraToolStripMenuItem.Click += new System.EventHandler(this.adHocDesktopCameraToolStripMenuItem_Click);
            // 
            // userBottomPanel
            // 
            this.userBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userBottomPanel.Location = new System.Drawing.Point(31, 247);
            this.userBottomPanel.Name = "userBottomPanel";
            this.userBottomPanel.Size = new System.Drawing.Size(201, 39);
            this.userBottomPanel.TabIndex = 2;
            // 
            // userTopPanel
            // 
            this.userTopPanel.Controls.Add(this.stopButton);
            this.userTopPanel.Controls.Add(this.refreshButton);
            this.userTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userTopPanel.Location = new System.Drawing.Point(31, 0);
            this.userTopPanel.Name = "userTopPanel";
            this.userTopPanel.Size = new System.Drawing.Size(201, 30);
            this.userTopPanel.TabIndex = 3;
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(60, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(48, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(6, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(48, 23);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "重整";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // userLeftPanel
            // 
            this.userLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.userLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.userLeftPanel.Name = "userLeftPanel";
            this.userLeftPanel.Size = new System.Drawing.Size(31, 286);
            this.userLeftPanel.TabIndex = 1;
            // 
            // groupContextMenuStrip
            // 
            this.groupContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inviteToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.groupContextMenuStrip.Name = "userContextMenuStrip";
            this.groupContextMenuStrip.Size = new System.Drawing.Size(143, 48);
            // 
            // inviteToolStripMenuItem
            // 
            this.inviteToolStripMenuItem.Name = "inviteToolStripMenuItem";
            this.inviteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.inviteToolStripMenuItem.Text = "邀請加入群組";
            this.inviteToolStripMenuItem.Click += new System.EventHandler(this.inviteToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.stopToolStripMenuItem.Text = "停止";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // userTimer
            // 
            this.userTimer.Enabled = true;
            this.userTimer.Interval = 5000;
            this.userTimer.Tick += new System.EventHandler(this.userTimer_Tick);
            // 
            // UserMainForm
            // 
            this.ClientSize = new System.Drawing.Size(232, 286);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.loginPanel);
            this.Name = "UserMainForm";
            this.Text = "隨意桌面用戶端";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.userPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.userContextMenuStrip.ResumeLayout(false);
            this.userTopPanel.ResumeLayout(false);
            this.groupContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.TextBox pwTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox msgTextBox;
        private System.Windows.Forms.TextBox connectTextBox;
        private System.Windows.Forms.CheckBox localConnectCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView userTreeView;
        private System.Windows.Forms.Panel userBottomPanel;
        private System.Windows.Forms.Panel userTopPanel;
        private System.Windows.Forms.Panel userLeftPanel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip userContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem adHocDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adHocDesktopAudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adHocDesktopScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adHocDesktopCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adHocDesktopConferenceToolStripMenuItem;
        private System.Windows.Forms.Button copyLogButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ContextMenuStrip groupContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem inviteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Timer userTimer;

    }
}


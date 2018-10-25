using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

using AdHocDesktop.Tcp;
using AdHocDesktop.Core;
using AdHocDesktop.Stream;

using Microsoft.DirectX.VideoGrabber;

namespace AdHocDesktop.User
{
    public partial class UserMainForm : Form
    {
        AdHocDesktop_TcpCommand invitationCommand;
        AdHocDesktop_Profile profile;
        AdHocDesktop_TcpClient user;
        AdHocDesktop_StreamWriter streamWriter;

        VideoDevicesSelector videoDeviceSelector;

        public UserMainForm()
        {
            InitializeComponent();
            Initialize();            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (loginPanel.Visible)
                    {
                        Connect();
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        void Initialize()
        {
            profile = new AdHocDesktop_Profile();

            //connectTextBox.Text = Dns.GetHostName();
            loginPanel.BringToFront();
            loginPanel.Dock = DockStyle.Fill;

            try
            {
                videoDeviceSelector = new VideoDevicesSelector();
                if (videoDeviceSelector.Count > 0)
                {
                    videoDeviceSelector.ShowVideoGrabberForm(0, true);
                }
            }
            catch { }            
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }
                     
        private void localConnectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (localConnectCheckBox.Checked)
            {
                connectTextBox.Text = Dns.GetHostName();
            }
        }

        void Connect()
        {
            user = new AdHocDesktop_TcpClient(connectTextBox.Text, AdHocDesktop_TcpUtil.DefaultServerPort);
            user.Connected += new EventHandler(user_Connected);
            user.Received += new AdHocDesktop_TcpReceivedEventHandler(user_Received);
            user.Error += new AdHocDesktop_TcpErrorEventHandler(user_Error);
            user.Start();
        }

        void user_Error(object sender, string message)
        {
            user.Connected -= new EventHandler(user_Connected);
            user.Received -= new AdHocDesktop_TcpReceivedEventHandler(user_Received);
            user.Error -= new AdHocDesktop_TcpErrorEventHandler(user_Error);
            try
            {
                msgTextBox.AppendText(message);

                userPanel.Visible = false;
                loginPanel.Visible = true;
            }
            catch { }
            StopAdHocDesktopStreamWriter();
        }

        void user_Connected(object sender, EventArgs e)
        {            
            try
            {
                string id = idTextBox.Text;
                string pw = StringUtil.ComputeMD5(pwTextBox.Text);
                AdHocDesktop_ProfilePlatform platform = AdHocDesktop_ProfilePlatform.WINNT;
                user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.RequestIdentifier, profile.Src, profile.Dest, id, pw, platform));
            }
            catch (Exception)
            { }
        }

        void UserAcceptInvitationCallback(object obj)
        {
            object[] objs = (object[])obj;
            string src = (string)objs[0];
            string title = (string)objs[1];
            AdHocDesktop_StreamingForm videoForm = new AdHocDesktop_StreamingForm(user, src, title);
            videoForm.FormClosing += new FormClosingEventHandler(videoForm_FormClosing);
            videoForm.Show();
        }

        void videoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: leave group.
        }

        void UserBeginInvitationCallback(object obj)
        {            
            object[] objs = (object[])obj;
            string title = (string)objs[0];
            string src = (string)objs[1];
            bool accept = false;
            accept = (DialogResult.OK == MessageBox.Show(this, "接受 " + title + " 的隨意桌面嗎？", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information));
            //accept = true;
            user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.EndInvitation, profile.Src, src, accept));
            if (accept)
            {
                UserAcceptInvitationCallback(new object[] { src, title });
                /*
                if (join.Src != join.Dest)
                {
                    switch (join.Command)
                    {
                        case AdHocDesktop_ProfileCommand.Audio:
                        case AdHocDesktop_ProfileCommand.Conference:
                            string temp = join.Src;
                            join.Src = join.Dest;
                            join.Dest = temp;
                            ad = new AdHocDesktop_AsyncCallback(UserInvokeJoinCallback);
                            this.BeginInvoke(ad, join);
                            break;
                    }
                }
                */
            }
        }

        void UserEndInvitationCallback(object obj)
        {            
            string dest = (string)obj;
            if (streamWriter == null)
            {
                profile.Dest = (string)dest;
                streamWriter = new AdHocDesktop_StreamWriter(invitationCommand, user, profile);
                streamWriter.BeginWriting();

                stopButton.Enabled = true;
            }
            else
            {
                streamWriter.SetNexNewCapture();
            }
        }

        void UserConnectCallback(object obj)
        {
            object[] objs = (object[])obj;
            profile.Src = objs[0].ToString();
            bool result = (bool)objs[1];
            if(result)
            {
                profile.Account = idTextBox.Text;
                loginPanel.Visible = false;
                userPanel.Visible = true;
                this.Text = profile.Account + " - 隨意桌面";
                SyncUserTreeView();
            }
            else
            {
                profile.Account = "";
                pwTextBox.Text = "";
                msgTextBox.AppendText("登入失敗。");
            }             
        }

        void user_Received(object sender, AdHocDesktop_TcpObject obj)
        {
            try
            {                           
                AdHocDesktop_AsyncCallback ad;
                object[] objs = obj.Data;
                switch (obj.Command)
                {
                    case AdHocDesktop_TcpCommand.ResponseIdentifier:
                        ad = new AdHocDesktop_AsyncCallback(UserConnectCallback);
                        this.BeginInvoke(ad, new object[] { objs });
                        break;
                    case AdHocDesktop_TcpCommand.ResponsePeople:
                        ad = new AdHocDesktop_AsyncCallback(UserPeopleCallback);
                        this.BeginInvoke(ad, new object[] { objs });
                        break;
                    case AdHocDesktop_TcpCommand.BeginInvitation:
                        ad = new AdHocDesktop_AsyncCallback(UserBeginInvitationCallback);
                        this.BeginInvoke(ad, new object[] { new object[] { objs[0], obj.Src } });
                        break;
                    case AdHocDesktop_TcpCommand.EndInvitation:
                        bool accept = (bool)objs[0];
                        if (accept)
                        {
                            ad = new AdHocDesktop_AsyncCallback(UserEndInvitationCallback);
                            this.BeginInvoke(ad, new object[] { obj.Dest });
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void UserPeopleCallback(object obj)
        {               
            object[] objs = (object[])obj;

            TreeNode rootNode = userTreeView.Nodes[0];
            string text, tag;

            int i = 0;
            for (i = 0; i < objs.Length; i+=2)
            {
                text = objs[i + 1].ToString();
                tag = objs[i].ToString();
                if (rootNode.Nodes.Count - 1 >= i/2)
                {
                    if (rootNode.Nodes[i/2].Tag.ToString() != objs[i].ToString())
                    {
                        rootNode.Nodes[i/2].Text = text;
                        rootNode.Nodes[i/2].Tag = tag;
                    }
                }
                else
                {
                    TreeNode node = new TreeNode(objs[i + 1].ToString());
                    node.Tag = objs[i].ToString();
                    userTreeView.Nodes[0].Nodes.Add(node);
                }
            }
            for (int j = i / 2; j < rootNode.Nodes.Count; )
            {
                rootNode.Nodes.RemoveAt(j);
            }

            rootNode.Expand();                       
        }

        void SyncUserTreeView()
        {
            user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.RequestPeople, profile.Src, profile.Dest, new byte[1]));
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            SyncUserTreeView();
        }

        TreeNode selectedTreeNode = null;

        private void userTreeView_Click(object sender, EventArgs e)
        {
            selectedTreeNode = userTreeView.GetNodeAt(userTreeView.PointToClient(Control.MousePosition));
            userTreeView.SelectedNode = selectedTreeNode;
        }

        TreeNode GetSelectedTreeNode()
        {            
            if (selectedTreeNode == null)
            {
                return userTreeView.SelectedNode;
            }
            else
            {
                return selectedTreeNode;
            }
        }

        void Invitation()
        {
            TreeNode treeNode = GetSelectedTreeNode();
            if (treeNode != null)
            {
                try
                {
                    user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.BeginInvitation, profile.Src, treeNode.Tag.ToString(), new byte[1]));
                    userTreeView.ContextMenuStrip = groupContextMenuStrip;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invitation failed.");
                }
            }
        }

        private void adHocDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invitationCommand = AdHocDesktop_TcpCommand.StreamingAdHocDesktop;
            Invitation();
        }

        private void adHocDesktopAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invitationCommand = AdHocDesktop_TcpCommand.StreamingAudio;
            Invitation();
        }

        private void adHocDesktopScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invitationCommand = AdHocDesktop_TcpCommand.StreamingScreen;
            Invitation();
        }

        void HideVideoGrabberForm()
        {
            if (videoDeviceSelector != null && videoDeviceSelector.IsShownVideoGrabberForm())
            {
                videoDeviceSelector.HideAllVideoGrabberForm();
            }
        }

        private void adHocDesktopConferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invitationCommand = AdHocDesktop_TcpCommand.StreamingConference;
            HideVideoGrabberForm();
            Invitation();
        }

        private void adHocDesktopCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invitationCommand = AdHocDesktop_TcpCommand.StreamingCamera;
            HideVideoGrabberForm();
            Invitation();
        }

        private void copyLogButton_Click(object sender, EventArgs e)
        {
            // single thread only
            Clipboard.SetText(msgTextBox.Text, TextDataFormat.Text);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.EndSession, profile.Src, profile.Dest, new byte[1]));
            StopAdHocDesktopStreamWriter();            
        }

        void StopAdHocDesktopStreamWriter()
        {
            stopButton.Enabled = false;
            userTreeView.ContextMenuStrip = userContextMenuStrip;

            if (streamWriter != null)
            {
                try
                {
                    streamWriter.Dispose();
                    streamWriter = null;
                }
                catch { }
            }
        }

        private void inviteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invitation();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAdHocDesktopStreamWriter();
        }

        private void userTimer_Tick(object sender, EventArgs e)
        {
            if (userPanel.Visible)
            {
                SyncUserTreeView();
            }
        }
    }
}
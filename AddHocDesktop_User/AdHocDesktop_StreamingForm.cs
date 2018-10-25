using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

using AdHocDesktop.Tcp;
using AdHocDesktop.Core;
using AdHocDesktop.Stream;
using AdHocDesktop.Stream.DirectSound;

namespace AdHocDesktop.User
{
    public partial class AdHocDesktop_StreamingForm : Form
    {
        Rectangle beforeFullScreenBounds = Rectangle.Empty;
        AdHocDesktop_TcpClient user;
        string src;
        string title;
        Size size = Size.Empty;
        byte[] previousBuffer;
        SoundPlayer soundPlayer;
        bool isFullScreen;

        public AdHocDesktop_StreamingForm()
        {
            InitializeComponent();
        }

        public AdHocDesktop_StreamingForm(AdHocDesktop_TcpClient user, string src, string title)
        {
            this.user = user;
            this.src = src;
            this.title = title;

            InitializeComponent();
            Initialize();

            user.Received += new AdHocDesktop_TcpReceivedEventHandler(user_Received);
            user.Error += new AdHocDesktop_TcpErrorEventHandler(user_Error);
        }

        void Initialize()
        {
            this.Text = title + " - Adhoc Desktop";
            try
            {
                soundPlayer = new SoundPlayer(this, DirectSoundManager.DefaultFormat);
            }
            catch (Exception)
            {
                //MessageBox.Show("無法初始化 DirectSound 音訊裝置！");
                quietAudioLabel.Visible = true;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    if (isFullScreen)
                    {
                        SwitchFullScreenMode();
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        
        void user_Error(object sender, string message)
        {
            user.Received -= new AdHocDesktop_TcpReceivedEventHandler(user_Received);            
        }

        void user_Received(object sender, AdHocDesktop_TcpObject obj)
        {
            if (src == obj.Src)
            {
                try
                {
                    if (obj.Command != AdHocDesktop_TcpCommand.Ping)
                    {
                        object[] objs = obj.Data;
                        byte[] buffer = objs[0].GetType() == typeof(byte[]) ? (byte[])objs[0] : null;
                        switch (obj.Command)
                        {
                            case AdHocDesktop_TcpCommand.StreamingScreen:
                            case AdHocDesktop_TcpCommand.StreamingCamera:
                                ReceivedVideo(obj.Command, buffer);
                                break;
                            case AdHocDesktop_TcpCommand.StreamingAudio:
                                ReceivedAudio(buffer);
                                break;
                            case AdHocDesktop_TcpCommand.ProfileScreen:
                            case AdHocDesktop_TcpCommand.ProfileCamera:
                                ReceivedProfile(objs);
                                break;
                            case AdHocDesktop_TcpCommand.EndSession:
                                ReceivedEndSession();
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        void ReceivedEndSession()
        {
            AdHocDesktop_AsyncCallback ad = new AdHocDesktop_AsyncCallback(ReceivedEndSessionCallback);
            this.BeginInvoke(ad, new object[] { null });
        }

        void ReceivedEndSessionCallback(object obj)
        {
            this.Dispose();
        }

        void ReceivedProfile(object[] objs)
        {            
            size.Width = (int)objs[0];
            size.Height = (int)objs[1];
        }

        void ReceivedAudio(byte[] buffer)
        {
            try
            {
                if (soundPlayer != null)
                {
                    soundPlayer.Write(GZipUtil.Decompress(buffer));
                }
            }
            catch (Exception)
            { } 
        }

        void ReceivedVideo(AdHocDesktop_TcpCommand command, byte[] buffer)
        {
            AdHocDesktop_AsyncCallback ad = new AdHocDesktop_AsyncCallback(ReceivedVideoCallback);
            this.BeginInvoke(ad, new object[] { new object[] { command, buffer } });
        }

        void ReceivedVideoCallback(object obj)
        {
            object[] objs = (object[])obj;
            AdHocDesktop_TcpCommand command = (AdHocDesktop_TcpCommand)objs[0];
            byte[] buffer = (byte[])objs[1];
            lock (this)
            {
                if (command == AdHocDesktop_TcpCommand.StreamingCamera)
                {
                    using (Bitmap drawImage = ImageUtil.ByteToBitmap(buffer))
                    {
                        using (Graphics g = videoPanel.CreateGraphics())
                        {
                            g.DrawImage(drawImage, new Rectangle(new Point(0, 0), videoPanel.Size));
                        }
                    }
                }
                else
                {
                    try
                    {
                        byte[] image = null;

                        if (previousBuffer == null)
                        {
                            previousBuffer = GZipUtil.Decompress(buffer);
                            image = previousBuffer;
                        }
                        else
                        {
                            byte[] currentBuffer = GZipUtil.Decompress(buffer);
                            image = ImageUtil.RecompareImage(previousBuffer, currentBuffer);
                        }
                        using (Bitmap drawImage = ImageUtil.ByteToBitmap(image))//, width, height, width * 3, PixelFormat.Format24bppRgb))
                        {
                            using (Graphics g = videoPanel.CreateGraphics())
                            {
                                g.DrawImage(drawImage, new Rectangle(new Point(0, 0), videoPanel.Size));
                            }
                        }

                        previousBuffer = null;
                        previousBuffer = image;
                        image = null;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void videoPanel_DoubleClick(object sender, EventArgs e)
        {           
            SwitchFullScreenMode();            
        }
        
        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchFullScreenMode();
        }

        void SwitchFullScreenMode()
        {
            if (beforeFullScreenBounds == Rectangle.Empty)
            {
                beforeFullScreenBounds = this.Bounds;
            }
            isFullScreen = !isFullScreen;
            if (isFullScreen)
            {
                topPanel.Height = 0;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.Bounds = beforeFullScreenBounds;
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                topPanel.Height = 24;
            }
        }
        
    }
}
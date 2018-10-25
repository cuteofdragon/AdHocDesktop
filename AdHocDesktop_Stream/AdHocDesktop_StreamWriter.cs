using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

using Microsoft.DirectX.VideoGrabber;
using AdHocDesktop.Core;
using AdHocDesktop.Tcp;
using AdHocDesktop.Stream.DirectSound;

namespace AdHocDesktop.Stream
{
    public class AdHocDesktop_StreamWriter : IDisposable
    {
        byte[] perviousBuffer = null;

        AdHocDesktop_TcpCommand command;
        AdHocDesktop_TcpClient user;
        AdHocDesktop_Profile profile;
        Thread adHocDesktopThread;
        Thread audioThread;
        bool isRunning;

        CaptureSound captureSound;
        List<byte> audioBuffer = new List<byte>();
        VideoGrabber videoGrabber;

        bool isNextNewCapture = false;

        public AdHocDesktop_StreamWriter(AdHocDesktop_TcpCommand command, AdHocDesktop_TcpClient user, AdHocDesktop_Profile profile)
        {
            this.command = command;
            this.user = user;
            this.profile = profile;
        }

        public void SetNexNewCapture()
        {
            isNextNewCapture = true; 
        }

        public void BeginWriting()
        {
            isRunning = true;
            switch (command)
            {
                case AdHocDesktop_TcpCommand.StreamingAdHocDesktop:
                    BeginWritingAdHocDesktop();
                    BeginWritingAudio();
                    break;
                case AdHocDesktop_TcpCommand.StreamingScreen:
                    BeginWritingAdHocDesktop();
                    break;
                case AdHocDesktop_TcpCommand.StreamingAudio:
                    BeginWritingAudio();
                    break;
                case AdHocDesktop_TcpCommand.StreamingCamera:
                    BeginWritingCamera();
                    break;
                case AdHocDesktop_TcpCommand.StreamingConference:
                    BeginWritingCamera();
                    BeginWritingAudio();
                    break;
            }

        }

        void BeginWritingAdHocDesktop()
        {
            InitializeCaptureSound();

            adHocDesktopThread = new Thread(new ThreadStart(AdHocDesktopThreadHandler));
            adHocDesktopThread.Start();
        }

        void BeginWritingAudio()
        {
            InitializeCaptureSound();

            audioThread = new Thread(new ThreadStart(AudioThreadHandler));
            audioThread.Start();
        }

        void BeginWritingCamera()
        {
            try
            {
                videoGrabber = new VideoGrabber();
                videoGrabber.BufferData += new VideoGrabberBufferDataEventHandler(videoGrabber_BufferData);
                videoGrabber.BeginGrabber();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        bool isSendProfileCamera = false;
        void videoGrabber_BufferData(object sender, VideoGrabberBufferDataEventArgs e)
        {
            try
            {
                if (!isSendProfileCamera)
                {
                    isSendProfileCamera = true;
                    user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.ProfileCamera, profile.Src, profile.Dest, e.Size));
                }

                byte[] buffer = ImageUtil.BitmapToJpegByte(e.Bitmap);
                user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.StreamingCamera, profile.Src, profile.Dest, buffer));
                buffer = null;
            }
            catch (Exception)
            {               
            }
        }

        void InitializeCaptureSound()
        {
            try
            {
                captureSound = new CaptureSound();
                captureSound.BufferData += new DirectSoundBufferDataEventHandler(captureSound_BufferData);
                //captureSound.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("無法初始化音訊裝置！");
            }
        }

        void captureSound_BufferData(object sender, DirectSoundBufferDataEventArgs e)
        {
            lock (audioBuffer)
            {
                audioBuffer.AddRange(e.Data);
            }
        }

        byte[] AcquireAudioBufferData()
        {
            byte[] audio = null;
            try
            {
                lock (audioBuffer)
                {
                    if (audioBuffer.Count > 0)
                    {
                        audio = audioBuffer.ToArray();
                        audioBuffer.Clear();
                    }
                }
                if (audio != null)
                {
                    audio = GZipUtil.Compress(audio);
                    return audio;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        void AudioThreadHandler()
        {
            if (captureSound == null)
            {
                return;
            }

            captureSound.Start();

            while (isRunning)
            {
                try
                {
                    byte[] audio = AcquireAudioBufferData();
                    if (audio != null)
                    {
                        user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.StreamingAudio, profile.Src, profile.Dest, audio));
                    }
                    Thread.Sleep(50);
                }
                catch (Exception)
                { 
                }
            }
        }

        void AdHocDesktopThreadHandler()
        {
            Rectangle captureRectangle = Screen.PrimaryScreen.Bounds;
            //Rectangle captureRectangle = new Rectangle(0, 0, 240, 180);
            perviousBuffer = AllocateBuffer(captureRectangle);            
            byte[] compressedBuffer = GZipUtil.Compress(perviousBuffer);
            user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.ProfileScreen, profile.Src, profile.Dest, captureRectangle.Size));
            user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.StreamingScreen, profile.Src, profile.Dest, compressedBuffer));
            
            while (isRunning)
            {
                try
                {
                    if (isNextNewCapture)
                    {
                        isNextNewCapture = false;
                        perviousBuffer = null;
                    }

                    byte[] currentBuffer = AllocateBuffer(captureRectangle);
                    //currentBuffer = ImageUtil.TransformHSV(currentBuffer);

                    if (perviousBuffer != null)
                    {
                        byte[] comparedBuffer = ImageUtil.CompareImage(perviousBuffer, currentBuffer);
                        compressedBuffer = GZipUtil.Compress(comparedBuffer);
                    }
                    else
                    {
                        compressedBuffer = GZipUtil.Compress(currentBuffer);
                    }

                    user.Send(new AdHocDesktop_TcpObject(AdHocDesktop_TcpCommand.StreamingScreen, profile.Src, profile.Dest, compressedBuffer));

                    perviousBuffer = currentBuffer;
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            
        }

        protected virtual byte[] AllocateBuffer(Rectangle bounds)
        {            
            return ScreenUtil.CaptureRectangle(bounds);            
            //return ScreenUtil.CaptureRectangle(new Rectangle(0, 0, 640, 480));
            /*
            byte[] b = new byte[1024];
            new Random().NextBytes(b);
            
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = 255;                
            }            
            return b;
            */
        }

        public void EndWriting()
        {
            isRunning = false;
            if (captureSound != null)
            {
                try
                {
                    captureSound.Stop();
                }
                catch (Exception)
                { }
            }
            if (videoGrabber != null)
            {
                try
                {
                    videoGrabber.EndGrabber();
                    videoGrabber.Dispose();
                }
                catch (Exception)
                { }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            EndWriting();
        }

        #endregion
    }
}

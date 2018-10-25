using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace AdHocDesktop.Core
{
    [Serializable]
    public class AdHocDesktop_ProfileSample : AdHocDesktop_ProfileBase
    {
        byte[] video;
        Size videoSize;
        byte[] audio;

        public byte[] VideoData { get { return video; } }
        public Size VideoSize { get { return videoSize; } }
        public byte[] AudioData { get { return audio; } }

        public AdHocDesktop_ProfileSample(string src, string dest, byte[] audio) :
           this(src, dest, null, Size.Empty, audio)
        {
        }

        public AdHocDesktop_ProfileSample(string src, string dest, byte[] video, Size videoSize) :
            this(src, dest, video, videoSize, null)
        {
        }

        public AdHocDesktop_ProfileSample(string src, string dest, byte[] video, Size videoSize, byte[] audio) :
            base(src, dest)
        {
            this.video = video;
            this.videoSize = videoSize;
            this.audio = audio;
        }
    }

}

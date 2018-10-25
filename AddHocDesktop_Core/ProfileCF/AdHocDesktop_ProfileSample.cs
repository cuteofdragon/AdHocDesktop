using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace AdHocDesktop.Core
{
    public class AdHocDesktop_ProfileSample : AdHocDesktop_ProfileBase
    {
        byte[] video;
        Size videoSize;
        byte[] audio;

        public byte[] VideoData { get { return video; } }
        public Size VideoSize { get { return videoSize; } }
        public byte[] AudioData { get { return audio; } }

        public AdHocDesktop_ProfileSample()
        {
        }

        public AdHocDesktop_ProfileSample(string src, string dest, byte[] audio) :
            this(src, dest, new byte[0], Size.Empty, audio)
        {
        }
        
        public AdHocDesktop_ProfileSample(string src, string dest, byte[] video, Size videoSize)
            :
            this(src, dest, video, videoSize, null)
        {
        }

        public AdHocDesktop_ProfileSample(string src, string dest, byte[] video, Size videoSize, byte[] audio) :
            base(src, dest)
        {
            this.video = video;
            this.videoSize = videoSize;
            this.audio = audio;
            this.video = this.video == null ? new byte[0] : this.video;
            this.audio = this.audio == null ? new byte[0] : this.audio;
        }

        public void ResizeVideoImage(Size size)
        {
            if (video != null && video.Length > 0)
            {

                if (Command == AdHocDesktop_ProfileCommand.Screen)
                {
                    using (Bitmap b = ImageUtil.ByteToBitmap(GZipUtil.Decompress(this.video)))
                    {
                        this.video = GZipUtil.Compress(ImageUtil.ResizeBitmapToByte(b, size));
                    }
                }
                else
                {
                    using (Bitmap b = ImageUtil.ByteToBitmap(this.video))
                    {
                        this.video = ImageUtil.ResizeBitmapToJpegByte(b, size);
                    }
                }
            }
        }

        public void SetAudioDataZero()
        {             
            if (audio != null && audio.Length > 0)
            {
                audio = new byte[0];
            }
        }

        public override byte[] Serialize()
        {
            base.Serialize();

            AdHocDesktop_BinaryFormatter.SerializeBytes(bw, video);
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, videoSize.Width);
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, videoSize.Height);
            AdHocDesktop_BinaryFormatter.SerializeBytes(bw, audio);

            AdHocDesktop_BinaryFormatter.SerializeType(bw, AdHocDesktop_SerializeType.AdHocDesktop_ProfileSample);
            ms.Position = 0;
            AdHocDesktop_BinaryFormatter.SerializeInt32(bw, (int)ms.Length);
            byte[] result = ms.ToArray();
            ms.Close();
            return result;
        }

        public override void Deserialize(byte[] data)
        {
            base.Deserialize(data);

            video = AdHocDesktop_BinaryFormatter.DeserializeBytes(br);
            videoSize.Width = AdHocDesktop_BinaryFormatter.DeserializeInt32(br);
            videoSize.Height = AdHocDesktop_BinaryFormatter.DeserializeInt32(br);
            audio = AdHocDesktop_BinaryFormatter.DeserializeBytes(br);
            ms.Close();
        }
    }

}

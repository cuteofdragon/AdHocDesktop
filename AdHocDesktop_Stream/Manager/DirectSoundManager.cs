using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AdHocDesktop.Stream
{
    public class DirectSoundManager
    {
        public const int NumberdNotifications = 4;

        public static Microsoft.DirectX.DirectSound.WaveFormat DefaultFormat
        {
            get
            {
                return WaveFormat_8000_8_1;
            }
        }

        public static Microsoft.DirectX.DirectSound.WaveFormat WaveFormat_44100_16_2
        {
            get
            {
                return CreateWaveFormat(44100, 16, 2);
            }
        }

        public static Microsoft.DirectX.DirectSound.WaveFormat WaveFormat_8000_8_1
        {
            get
            {
                return CreateWaveFormat(8000, 8, 1);
            }
        }

        public static Microsoft.DirectX.DirectSound.WaveFormat WaveFormat_11025_8_1
        {
            get
            {
                return CreateWaveFormat(11025, 8, 1);
            }
        }

        public static Microsoft.DirectX.DirectSound.WaveFormat WaveFormat_22050_16_2
        {
            get
            {
                return CreateWaveFormat(22050, 16, 2);
            }
        }

        public static Microsoft.DirectX.DirectSound.WaveFormat CreateWaveFormat(int hz, short bits, short channels)
        {
            Microsoft.DirectX.DirectSound.WaveFormat format = new Microsoft.DirectX.DirectSound.WaveFormat();
            format.FormatTag = Microsoft.DirectX.DirectSound.WaveFormatTag.Pcm;
            format.SamplesPerSecond = hz;
            format.BitsPerSample = bits;
            format.Channels = channels;
            format.BlockAlign = (short)(format.Channels * (format.BitsPerSample / 8));
            format.AverageBytesPerSecond = format.BlockAlign * format.SamplesPerSecond;
            
            return format;
        }
    }
}

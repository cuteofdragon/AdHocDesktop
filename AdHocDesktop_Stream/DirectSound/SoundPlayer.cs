using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Microsoft.DirectX.DirectSound;

using AdHocDesktop.Core;

namespace AdHocDesktop.Stream.DirectSound
{
    /// <summary>
    /// An audio streaming player using DirectSound
    /// </summary>
    public class SoundPlayer : IDisposable
    {
        private const int MaxLatencyMs = 300;


        private Device m_Device;
        private bool m_OwnsDevice;
        private SecondaryBuffer m_Buffer;
        private int nextWriteOffset;
        private int m_BufferBytes;

        const int NumberRecordNotifications = DirectSoundManager.NumberdNotifications;
        BufferPositionNotify[] positionNotify = new BufferPositionNotify[NumberRecordNotifications + 1];
        AutoResetEvent notificationEvent = null;
        Notify notify = null;
        Thread notifyThread = null;
        int notifySize = 0;
        bool isRunning;

        public Device Device { get { return m_Device; } }
        public int SamplingRate { get { return m_Buffer.Format.SamplesPerSecond; } }
        public int BitsPerSample { get { return m_Buffer.Format.BitsPerSample; } }
        public int Channels { get { return m_Buffer.Format.Channels; } }

        public SoundPlayer(Control owner, int sr, short bps, short ch)
            :
            this(owner, null, DirectSoundManager.CreateWaveFormat(sr, bps, ch))
        {
        }

        public SoundPlayer(Control owner, WaveFormat format)
            :
            this(owner, null, format)
        {
        }

        public SoundPlayer(Control owner, Device device, int sr, short bps, short ch)
            :
            this(owner, device, DirectSoundManager.CreateWaveFormat(sr, bps, ch))
        {
        }

        public SoundPlayer(Control owner, Device device, WaveFormat format)
        {
            m_Device = device;
            if (m_Device == null)
            {
                m_Device = new Device();
                m_Device.SetCooperativeLevel(owner, CooperativeLevel.Normal);
                m_OwnsDevice = true;
            }


            // Set the notification size
            notifySize = (1024 > format.AverageBytesPerSecond / 8) ? 1024 : (format.AverageBytesPerSecond / 8);
            notifySize -= notifySize % format.BlockAlign;

            // Set the buffer sizes
            m_BufferBytes = notifySize * NumberRecordNotifications;

            BufferDescription desc = new BufferDescription(format);
            desc.BufferBytes = format.AverageBytesPerSecond;
            desc.ControlVolume = true;
            desc.ControlPositionNotify = true;
            desc.CanGetCurrentPosition = true;
            desc.Control3D = false;
            desc.ControlEffects = false;
            desc.ControlFrequency = true;
            desc.ControlPan = true;
            desc.ControlPositionNotify = true;
            desc.ControlVolume = true;
            desc.GlobalFocus = true; // Continues to play if focus is lost 
            desc.BufferBytes = m_BufferBytes;

            m_Buffer = new SecondaryBuffer(desc, m_Device);
            circularBuffer = new AdHocDesktop_CircularBuffer(m_BufferBytes * 10);

            InitNotifications();

            m_Buffer.Play(0, BufferPlayFlags.Looping);
        }

        ~SoundPlayer()
        {
            Dispose();
        }

        public void Dispose()
        {
            Stop();
            if (m_Buffer != null)
            {
                m_Buffer.Dispose();
                m_Buffer = null;
            }
            if (m_OwnsDevice && m_Device != null)
            {
                m_Device.Dispose();
                m_Device = null;
            }
            GC.SuppressFinalize(this);
        }

        void InitNotifications()
        {
            // Start the thread that waits for Notifications 
            notifyThread = new Thread(new ThreadStart(NotifyThreadHandler));
            isRunning = true;
            notifyThread.Start();

            // Create the AutoResetEvent. When each offset is reached in the SecondaryBuffer 
            // the 'BufferPositionNotify.EventNotifyHandle' will cause an AutoResetEvent to 
            // notify the waiting thread that an event has occured. 
            notificationEvent = new AutoResetEvent(false);

            notify = new Notify(m_Buffer);

            // Set the notification positions at which playbackBuffer will be refreshed 
            for (int y = 0; y < NumberRecordNotifications; y++)
            {
                // Set the offset to one byte before the notifySize 
                positionNotify[y].Offset = (notifySize * y) + notifySize - 1;
                // Create an AutoResetEvent for each position 
                positionNotify[y].EventNotifyHandle = notificationEvent.SafeWaitHandle.DangerousGetHandle();
            }

            // Tell DirectSound when to notify the app. The notification will come in the from 
            // of signaled events that are handled in the notify thread.
            notify.SetNotificationPositions(positionNotify, NumberRecordNotifications);

            nextWriteOffset = 0;
        }

        void NotifyThreadHandler()
        {
            while (isRunning)
            {
                try
                {
                    //Sit here and wait for a message to arrive
                    notificationEvent.WaitOne(Timeout.Infinite, true);
                    Play();
                }
                catch (Exception)
                {
                }
            }
        }

        public void Stop()
        {
            isRunning = false;
            if (m_Buffer != null)
                m_Buffer.Stop();
        }

        private int BytesToMs(int bytes)
        {
            return bytes * 1000 / m_Buffer.Format.AverageBytesPerSecond;
        }

        private int MsToBytes(int ms)
        {
            int bytes = ms * m_Buffer.Format.AverageBytesPerSecond / 1000;
            bytes -= bytes % m_Buffer.Format.BlockAlign;
            return bytes;
        }

        void Play()
        {
            int playPos;
            int writePos;
            int lockSize;

            try
            {
                m_Buffer.GetCurrentPosition(out playPos, out writePos);
                lockSize = writePos - nextWriteOffset;
                if (lockSize < 0)
                    lockSize += m_BufferBytes;

                // Block align lock size so that we are always write on a boundary
                lockSize -= (lockSize % notifySize);

                if (0 == lockSize)
                    return;
                if (lockSize == m_BufferBytes)
                {
                }

                byte[] writeBytes = new byte[lockSize];

                if (circularBuffer.Read(writeBytes) > 0)
                {
                    m_Buffer.Write(nextWriteOffset, writeBytes, LockFlag.None);

                    // Move the capture offset along
                    nextWriteOffset += lockSize;
                    nextWriteOffset %= m_BufferBytes; // Circular buffer
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        AdHocDesktop_CircularBuffer circularBuffer;

        public void Write(byte[] data)
        {
            try
            {
                circularBuffer.Write(data);
            }
            catch (Exception)
            { }
        }

    }
}

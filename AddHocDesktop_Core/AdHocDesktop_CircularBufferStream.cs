using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdHocDesktop.Core
{
    public class AdHocDesktop_CircularBuffer
    {
        int readPosition;
        int writePosition;
        byte[] buffer;
        int readLoop;
        int writeLoop;

        public AdHocDesktop_CircularBuffer(int fixedCapacity)
        {
            buffer = new byte[fixedCapacity];
        }

        public int Length
        {
            get { return buffer.Length; }
        }

        public int ReadPosition
        {
            get { return readPosition; }
        }

        public int WritePosition
        {
            get { return writePosition; }
        }

        /*
        public byte[] ReadToWrite()
        {
            int wp = writePosition;
            int rp = readPosition;
            int canReadLength = Math.Abs(wp - rp);
            byte[] data = null;

            if (wp > rp)
            {
                data = new byte[canReadLength];
                Array.Copy(buffer, readPosition, data, 0, data.Length);
                readPosition += data.Length;
            }
            else
            {
                canReadLength = Length - rp + wp;
                data = new byte[canReadLength];

                Array.Copy(buffer, readPosition, data, 0, Length - rp);
                readPosition += Length - rp;

                readPosition %= Length;
                Array.Copy(buffer, readPosition, data, canReadLength, wp);
                readPosition += wp;
                readLoop++;
            }
            return data;               
        }
         */

        public int Read(byte[] data)
        {
            int canReadLength = Length - readPosition;
            canReadLength %= Length;

            if (readLoop * Length + readPosition + data.Length > writeLoop * Length + writePosition)
            {
                return -1;
            }
            else
            {
                if (canReadLength >= data.Length)
                {
                    Array.Copy(buffer, readPosition, data, 0, data.Length);
                    readPosition += data.Length;
                }
                else
                {
                    Array.Copy(buffer, readPosition, data, 0, canReadLength);
                    readPosition += canReadLength;

                    readPosition %= Length;
                    Array.Copy(buffer, readPosition, data, canReadLength, data.Length - canReadLength);
                    readPosition += (data.Length - canReadLength);
                    readLoop++;
                }

                readPosition %= Length;
                return data.Length;
            }
        }

        public void Write(byte[] data)
        {
            int canWriteLength = Length - writePosition;
            canWriteLength %= Length;

            if (canWriteLength >= data.Length)
            {
                Array.Copy(data, 0, buffer, writePosition, data.Length);
                writePosition += data.Length;
            }
            else
            {
                Array.Copy(data, 0, buffer, writePosition, canWriteLength);
                writePosition += canWriteLength;

                writePosition %= Length;
                Array.Copy(data, canWriteLength, buffer, writePosition, data.Length - canWriteLength);
                writePosition += (data.Length - canWriteLength);
                writeLoop++;
            }

            writePosition %= Length;
        }

    }
}

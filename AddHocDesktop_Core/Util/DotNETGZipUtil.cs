using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text;

// ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.NETDEVFX.v20.en/cpref8/html/T_System_IO_Compression_CompressionMode.htm

namespace AdHocDesktop.Core
{
    public class GZipUtil
    {
        public static bool CompareData(byte[] buf1, int len1, byte[] buf2, int len2)
        {
            // Use this method to compare data from two different buffers.
            if (len1 != len2)
            {
                //Console.WriteLine("Number of bytes in two buffer are different {0}:{1}", len1, len2);
                return false;
            }

            for (int i = 0; i < len1; i++)
            {
                if (buf1[i] != buf2[i])
                {
                    //Console.WriteLine("byte {0} is different {1}|{2}", i, buf1[i], buf2[i]);
                    return false;
                }
            }
            //Console.WriteLine("All bytes compare.");
            return true;
        }

        public static byte[] Compress(byte[] buffer)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                // Use the newly created memory stream for the compressed data.
                GZipStream compressedStream = new GZipStream(ms, CompressionMode.Compress, true);
                //Console.WriteLine("Compression");
                compressedStream.Write(buffer, 0, buffer.Length);
                // Close the stream.
                compressedStream.Close();
                return ms.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static byte[] Decompress(byte[] buffer)
        {
            try
            {
                MemoryStream inStream = new MemoryStream(buffer);
                MemoryStream outStream = new MemoryStream();

                GZipStream decompressedStream = new GZipStream(inStream, CompressionMode.Decompress);

                byte[] decompressedBuffer = new byte[4096];
                
                // Use this method is used to read all bytes from a stream.
                int offset = 0;
                int totalCount = 0;
                while (true)
                {
                    int bytesRead = decompressedStream.Read(decompressedBuffer, 0, decompressedBuffer.Length);
                    outStream.Write(decompressedBuffer, 0, bytesRead);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    offset += bytesRead;
                    totalCount += bytesRead;                   
                }

                //Console.WriteLine("Decompressed {0} bytes", totalCount);
                decompressedStream.Close();

                return outStream.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /*
        
        static int ReadAllBytesFromStream(Stream stream, byte[] buffer)
        {
            // Use this method is used to read all bytes from a stream.
            int offset = 0;
            int totalCount = 0;
            while (true)
            {                
                int bytesRead = stream.Read(buffer, offset, 100);
                if (bytesRead == 0)
                {
                    break;
                }
                offset += bytesRead;
                totalCount += bytesRead;
            }
            return totalCount;
        }
        
        public static void GZipCompressDecompress(string filename)
        {
            //Console.WriteLine("Test compression and decompression on file {0}", filename);
            FileStream infile;
            try
            {
                // Open the file as a FileStream object.
                infile = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] buffer = new byte[infile.Length];
                // Read the file to ensure it is readable.
                int count = infile.Read(buffer, 0, buffer.Length);
                if (count != buffer.Length)
                {
                    infile.Close();
                    Console.WriteLine("Test Failed: Unable to read data from file");
                    return;
                }
                infile.Close();
                MemoryStream ms = new MemoryStream();
                // Use the newly created memory stream for the compressed data.
                GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
                Console.WriteLine("Compression");
                compressedzipStream.Write(buffer, 0, buffer.Length);
                // Close the stream.
                compressedzipStream.Close();
                Console.WriteLine("Original size: {0}, Compressed size: {1}", buffer.Length, ms.Length);

                // Reset the memory stream position to begin decompression.
                ms.Position = 0;
                GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress);
                Console.WriteLine("Decompression");
                byte[] decompressedBuffer = new byte[buffer.Length + 100];
                // Use the ReadAllBytesFromStream to read the stream.
                int totalCount = GZipTest.ReadAllBytesFromStream(zipStream, decompressedBuffer);
                //Console.WriteLine("Decompressed {0} bytes", totalCount);

                if (!GZipTest.CompareData(buffer, buffer.Length, decompressedBuffer, totalCount))
                {
                    Console.WriteLine("Error. The two buffers did not compare.");
                }
                zipStream.Close();
            } // end try
            catch (InvalidDataException)
            {
                Console.WriteLine("Error: The file being read contains invalid data.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error:The file specified was not found.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error: path is a zero-length string, contains only white space, or contains one or more invalid characters");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Error: The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error: The specified path is invalid, such as being on an unmapped drive.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: An I/O error occurred while opening the file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: path specified a file that is read-only, the path is a directory, or caller does not have the required permissions.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: You must provide parameters for MyGZIP.");
            }
        }

        public static void Main(string[] args)
        {
            string usageText = "Usage: MYGZIP <inputfilename>";
            //If no file name is specified, write usage text.
            if (args.Length == 0)
            {
                Console.WriteLine(usageText);
            }
            else
            {
                if (File.Exists(args[0]))
                    GZipCompressDecompress(args[0]);
            }
        }
        */
    }

}

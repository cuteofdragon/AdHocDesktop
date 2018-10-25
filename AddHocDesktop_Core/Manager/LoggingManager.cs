using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdHocDesktop.Core
{
    public class LoggingManager
    {
        static List<Log> logs = new List<Log>();

        public static void Add(LogType type, string content)
        {
            logs.Add(new Log(type, content));
        }

        public static void Export(string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.Default);

            sw.WriteLine("\r\n======= " + DateTime.Now.ToString() + " =======\r\n");
            
            foreach (Log log in logs)
            {
                sw.WriteLine(log.Type.ToString() + "\t" + log.Content + "\t" + log.CreateTime);
            }
            sw.Close();
        }
    }

    class Log
    {
        LogType type;
        string content;
        DateTime createTime = DateTime.Now;

        public LogType Type { get { return type; } }
        public string Content { get { return content;} }
        public DateTime CreateTime { get { return createTime; } }

        public Log(LogType type, string content)
        {
            this.type = type;
            this.content = content;
        }
    }

    public enum LogType
    {
        OnlinePeopel,
        OnlineGroup,
        BandwidthInput,
        BandwidthOutput,
        Information,
    }
}

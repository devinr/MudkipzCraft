using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MudkipzCraft
{
    public static class Logger
    {
        public static StreamWriter log;
        public static void Init()
        {
            if (!File.Exists("server.log"))
            {
                log = new StreamWriter("server.log");
            }
            else
            {
                log = File.AppendText("server.log");
            }
        }
        public static void Log(string type, string msg)
        {
            if (type != "Trace")
            {
                Console.Write(DateTime.Now.Hour.ToString("D2"));
                Console.Write(":");
                Console.Write(DateTime.Now.Minute.ToString("D2"));
                Console.Write(":");
                Console.Write(DateTime.Now.Second.ToString("D2"));
                Console.Write(".");
                Console.Write(DateTime.Now.Millisecond.ToString("D3"));
                Console.Write(" [");
                Console.Write(type);
                Console.Write("] ");
                Console.WriteLine(msg);
            }
            log.Write(DateTime.Now.Hour.ToString("D2"));
            log.Write(":");
            log.Write(DateTime.Now.Minute.ToString("D2"));
            log.Write(":");
            log.Write(DateTime.Now.Second.ToString("D2"));
            log.Write(".");
            log.Write(DateTime.Now.Millisecond.ToString("D3"));
            log.Write(" [");
            log.Write(type);
            log.Write("] ");
            log.WriteLine(msg);
            log.Flush();
        }
        public static void Trace(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Log("Trace", msg);
            Console.ResetColor();
        }
        public static void Debug(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log("Debug", msg);
            Console.ResetColor();
        }
        public static void Info(string msg)
        {
            Log("Info", msg);
        }
        public static void Warn(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Log("Warn", msg);
            Console.ResetColor();
        }
        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log("Error", msg);
            Console.ResetColor();
        }
        public static void Fatal(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Log("Fatal", msg);
            Console.ResetColor();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace MudkipzCraft
{
    public class MudkipzCraft
    {
        public const int ProtocolVersion = 11;
        public const string ServerVersion = "1.5_02";
        private static NetHandler nethandler;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static Config cfg;
        public static void Main(string[] args)
        {
            InitLogging();
            // Get the banner and pretty watermark/version info out of the way
            Util.PrintBanner();
            logger.Info("MudkipzCraft {0}", ServerVersion);
            logger.Info("Minecraft protocol version: {0}", ProtocolVersion);
            // .NET/mono version, for debugging purposes
            logger.Info(".NET Framework version {0}.{1}.{2}", Environment.Version.Major, Environment.Version.Minor, Environment.Version.Build);
            logger.Info("");
            logger.Info("Loading configuration...");
            cfg = new Config();
            cfg.Load();
            logger.Info("Loaded configuration.");
            
            // Start NetHandler.ListenServer() and go from there...
            nethandler = new NetHandler();
            new Thread(nethandler.ListenServer).Start();

        }
        private static void InitLogging()
        {
            LoggingConfiguration cfg = new LoggingConfiguration();
            ConsoleTarget ct = new ConsoleTarget();
            FileTarget ft = new FileTarget();
            ft.FileName = "server.log";
            ft.DeleteOldFileOnStartup = false;

            cfg.AddTarget("console", ct);
            cfg.AddTarget("file", ft);

            ct.Layout = "${date:format=HH\\:mm\\:ss} [${level}] ${message}";
            ft.Layout = "${date:format=HH\\:mm\\:ss} [${level}] ${message}";

            LoggingRule r1 = new LoggingRule("*", LogLevel.Debug, ct);
            LoggingRule r2 = new LoggingRule("*", LogLevel.Trace, ft);

            cfg.LoggingRules.Add(r1);
            cfg.LoggingRules.Add(r2);

            LogManager.Configuration = cfg;
        }
    }
}

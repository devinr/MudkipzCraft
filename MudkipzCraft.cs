using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MudkipzCraft
{
    public class MudkipzCraft
    {
        public const int ProtocolVersion = 11;
        public const string ServerVersion = "1.5_02";
        private static NetHandler nethandler;
        public static Config cfg;
        public static void Main(string[] args)
        {
            Logger.Init();
            // Get the banner and pretty watermark/version info out of the way
            Util.PrintBanner();
            Logger.Info("");
            Logger.Info("MudkipzCraft " + ServerVersion);
            Logger.Info("Minecraft protocol version: " + ProtocolVersion);
            // .NET/mono version, for debugging purposes
            Logger.Info(".NET Framework version " + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build);
            Logger.Info("");
            Logger.Info("Loading configuration...");
            cfg = new Config();
            cfg.Load();
            Logger.Info("Loaded configuration.");
            
            // Start NetHandler.ListenServer() and go from there...
            nethandler = new NetHandler();
            new Thread(nethandler.ListenServer).Start();

        }
    }
}

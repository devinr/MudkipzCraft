using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace MudkipzCraft
{
    public class Client
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private NetworkStream st;
        private string ipAddr;
        public Client(NetworkStream stream)
        {
            this.st = stream;
            
        }
    }
}

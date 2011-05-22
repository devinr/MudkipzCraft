using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace MudkipzCraft
{
    class NetHandler
    {
        private TcpListener Listener;
        public void ListenServer()
        {
            Listener = new TcpListener(25565);
            Listener.Start();
            Logger.Debug("TcpListener.ListenServer(): Started listening for connections.");

            byte[] buffer = new byte[1024];

            while (true)
            {
                TcpClient client = Listener.AcceptTcpClient();
                Logger.Debug("A client connected!");

                // Get a stream
                NetworkStream st = client.GetStream();

                new Thread(() => new Client(st)).Start();


            }
        }
    }
}

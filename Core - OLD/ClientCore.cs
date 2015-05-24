using System;
using System.Diagnostics;
using Core.Exceptions;
using Packets.Packets;


namespace Core
{
    public static class ClientCore
    {
        private static readonly ClientSocket Socket = new ClientSocket();
        public static bool Connect(string ipAddress, int port)
        {
            var sw = new Stopwatch();
            try
            {
                sw.Start();
                Socket.Connect(ipAddress, port);
                while (sw.Elapsed.Seconds < 5)
                {
                    if (!Socket.Connected) continue;
                    sw.Stop();
                    return true;
                }
                throw new ConnectionFailedException("Connection failed");
            }
            catch
            {
                Logger.LogError(string.Format("Error connecting to {0}:{1}", ipAddress, port));
                return false;
            }
        }

        public static void List(string path)
        {
            var cmd = new Message("LIST");
            Socket.Send(cmd.Data);
        }
    }
}

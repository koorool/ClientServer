using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Server.Networking;

namespace Core
{
    public static class ServerCore
    {
        /// <summary>
        /// True if server is started.
        /// </summary>
        public static bool IsStarted;
        /// <summary>
        /// Error code. 0 if OK.
        /// </summary>
        public static byte Error;

        /// <summary>
        /// ServerSocket
        /// </summary>
        private static ServerSocket ServerSocket = new ServerSocket();

        public static void Start(int port)
        {
            //if (ServerSocket != null && ServerSocket.Connected)
            //{
            //    ServerSocket.Disconnect(false);
            //}
            try
            {
                ServerSocket.Bind(port);
                ServerSocket.Listen(500);
                ServerSocket.Accept();
                Logger.LogEvent("Start listening on " + port);
            }
            catch (Exception ex)
            {
                Logger.LogError("Error start listening on " + port + " | " + ex.Message);
            }
            IsStarted = true;
        }

        public static IEnumerable<string> GetAddressList()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                return host.AddressList.Where(address => address.AddressFamily == AddressFamily.InterNetwork).Select(address => address.ToString()).ToList();
            }
            catch (Exception exception)
            {
                Logger.LogError("Loading addresses failed: " + exception.Message);
                throw;
            }
        }

        public static void Stop()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                Logger.LogError("Ошибка остановки сервера: " + exception.Message);
                throw;
            }

            IsStarted = false;
        }
    }
}


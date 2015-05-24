using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Server.Networking;

namespace Core
{
    public static class ServerCore
    {
        private static TcpListener _listener;

        public static void Start(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            _listener.BeginAcceptTcpClient(HandleAcceptTcpClient, _listener);
        }

        public static void Stop()
        {
            if (_listener != null)
            {
                _listener.Stop();
            }
        }

        private static void HandleAcceptTcpClient(IAsyncResult result)
        {
            _listener.BeginAcceptTcpClient(HandleAcceptTcpClient, _listener);
            TcpClient client = _listener.EndAcceptTcpClient(result);

            ClientConnection connection = new ClientConnection(client);

            ThreadPool.QueueUserWorkItem(connection.HandleClient, client);
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
    }
}


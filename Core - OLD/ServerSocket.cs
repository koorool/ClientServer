using System;
using System.Net;
using System.Net.Sockets;

namespace Server.Networking
{
    class ServerSocket
    {
        private Socket _socket;
        private byte[] _buffer;

        public ServerSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }

        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }

        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallback, null);
        }

        private void AcceptedCallback(IAsyncResult result)
        {
            Socket clientSocket = _socket.EndAccept(result);
            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, 1024, SocketFlags.None, ReceivedCallback, clientSocket);
            //Logger.LogEvent(string.Format("Client {0} connected", clientSocket.RemoteEndPoint));
            Accept();
        }

        private void ReceivedCallback(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;
            SocketError se;
            int bufferSize = clientSocket.EndReceive(result, out se);
            if (se != SocketError.Success)
            {
                
            }
            byte[] packet = new byte[bufferSize];
            Array.Copy(_buffer, packet, packet.Length);
            _buffer = new byte[1024];
            
            //Handle the packet

            //

            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, 1024, SocketFlags.None, ReceivedCallback, clientSocket);
        }
    }


}

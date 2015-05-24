using System;
using System.Net;
using System.Net.Sockets;

namespace Core
{
    public class ClientSocket
    {
        private readonly Socket _socket;
        private byte[] _buffer;

        public Boolean Connected
        {
            get { return _socket.Connected; }
        }

        public ClientSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(String ipAddress, int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallback, null);
        }

        private void ConnectCallback(IAsyncResult result)
        {
            if (!_socket.Connected) return;
            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
        }

        private void ReceivedCallback(IAsyncResult result)
        {
            int bufLegth = _socket.EndReceive(result);
            byte[] packet = new byte[bufLegth];
            Array.Copy(_buffer, packet, packet.Length);

            //Packet handle

            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, 1024, SocketFlags.None, ReceivedCallback, null);
        }

        public void Send(byte[] packet)
        {
            _socket.Send(packet);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Packets;
using Packets.Packets;

namespace Core
{
    public static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            ushort packetLenght = BitConverter.ToUInt16(packet, 0);
            ushort packetType = BitConverter.ToUInt16(packet, 2);
            PacketStructure pckt;
            switch (packetType)
            {
                case 1000:
                case 2000:
                    pckt = new Message(packet);
                    String.Format(((Message) pckt).Text);
                    break;
            }
        }
    }
}

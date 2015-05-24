using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    public abstract class PacketStructure
    {
        private byte[] _buffer;
        public byte[] Data { get { return _buffer; } }

        public PacketStructure(ushort lenght, ushort type)
        {
            _buffer = new byte[lenght];
        }

        public PacketStructure(byte[] packet)
        {
            _buffer = packet;
        }

        public void WriteUShort(ushort value, ushort offset)
        {
            var tempBuf = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempBuf, 0, _buffer, offset, 2);
        }

        public ushort ReadUShort(int offset)
        {
            return BitConverter.ToUInt16(_buffer, offset);
        }

        public void WriteUInt(uint value, ushort offset)
        {
            var tempBuf = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempBuf, 0, _buffer, offset, 4);
        }


        public void WriteString(string value, ushort offset)
        {
            var tempBuf = Encoding.UTF8.GetBytes(value);
            Buffer.BlockCopy(tempBuf, 0, _buffer, offset, value.Length);
        }

        public string ReadString(int offset, int count)
        {
            return Encoding.UTF8.GetString(_buffer, offset, count);
        }
    }
}

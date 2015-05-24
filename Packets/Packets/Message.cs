namespace Packets.Packets
{
    public class Message: PacketStructure
    {
        private string _message;
        public Message(string message)
            :base((ushort)(4+message.Length), 2000)
        {
            Text = message;
        }

        public Message(byte[] packet)
            :base(packet)
        {
            
        }

        public string Text
        {
            get { return ReadString(4, Data.Length-4); }
            set
            {
                _message = value;
                WriteString(value, 4);
            }
        }
    }
}

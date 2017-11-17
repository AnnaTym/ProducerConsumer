namespace SysLogServer.MessageParsers
{
    public interface IMessageParser
    {
        void ParseMessage(byte[] message);
    }
}

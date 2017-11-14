namespace MessageReciverService.MessageParsers
{
    public interface IMessageParser
    {
        void ParseMessage(byte[] message);
    }
}

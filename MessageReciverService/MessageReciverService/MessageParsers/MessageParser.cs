using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

using MessageReciverService.Contracts;

namespace MessageReciverService.MessageParsers
{
    [Export(typeof(IMessageParser))]
    public class MessageParser : IMessageParser
    {
        [ImportMany]
        private IEnumerable<IHandler> handlers;

        public void ParseMessage(byte[] reciveBytes)
        {
            string message = Encoding.ASCII.GetString(reciveBytes, 0, reciveBytes.Length);

            foreach (IHandler handler in handlers)
            {
                handler.Handle(message);
            }
        }
    }
}

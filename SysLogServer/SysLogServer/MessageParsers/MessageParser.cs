using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

using SysLogServer.Contracts;

namespace SysLogServer.MessageParsers
{
    [Export(typeof(IMessageParser))]
    public class MessageParser : IMessageParser
    {
#pragma warning disable 649
        [ImportMany]
        private IEnumerable<IHandler> handlers;
#pragma warning restore 649

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

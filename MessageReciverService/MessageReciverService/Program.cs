using System.ComponentModel.Composition.Hosting;

using MessageReciverService.Listeners;
using MessageReciverService.MessageParsers;

namespace MessageReciverService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var catalog = new DirectoryCatalog(@".\", "*.*");
            var container = new CompositionContainer(catalog);

            var listener = container.GetExportedValue<IListener>();
            var parser = container.GetExportedValue<IMessageParser>();

            listener.MessageRecivedAction = parser.ParseMessage;

            listener.Start();
        }

        
    }
}

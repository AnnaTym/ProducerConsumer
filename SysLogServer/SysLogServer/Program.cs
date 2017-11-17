using System;
using System.ComponentModel.Composition.Hosting;

using SysLogServer.Listeners;
using SysLogServer.MessageParsers;

namespace SysLogServer
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
            listener.StartAsync();

            Console.WriteLine("Press any key to stop server");
            Console.ReadKey();

            listener.Stop();

            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}

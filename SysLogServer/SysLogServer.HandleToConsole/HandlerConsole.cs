using System;
using System.ComponentModel.Composition;

using SysLogServer.Contracts;

namespace SysLogServer.HandleToConsole
{
    [Export(typeof(IHandler))]
    public class HandlerConsole : IHandler
    {
        public void Handle(object obj)
        {
            string message = obj as string;
            Console.WriteLine($"Received message :\n {message}\n");
        }
    }
}

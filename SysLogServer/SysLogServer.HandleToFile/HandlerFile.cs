using System;
using System.ComponentModel.Composition;
using System.IO;

using SysLogServer.Contracts;

namespace SysLogServer.HandleToFile
{
    [Export(typeof(IHandler))]
    public class HandlerFile : IHandler
    {
        public void Handle(object obj)
        {
            string message = obj as string;
            using (var outputFile = new StreamWriter(Environment.CurrentDirectory + @"\Message.txt", true))
            {
                outputFile.WriteLine(message);
            }
        }
    }
}

using System;
using System.ComponentModel.Composition;
using System.IO;

using MessageReciverService.Contracts;

namespace MessageReciverService.HandleToFile
{
    [Export(typeof(IHandler))]
    public class HandlerFile : IHandler
    {
        public void Handle(object obj)
        {
            string message = obj as string;

            string mydocpath = Environment.CurrentDirectory;

            using (var outputFile = new StreamWriter(mydocpath + @"\Message.txt", true))
            {
                outputFile.WriteLine(message);
            }
        }
    }
}

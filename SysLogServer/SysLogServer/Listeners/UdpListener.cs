using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Net.Sockets;

namespace SysLogServer.Listeners
{
    [Export(typeof(IListener))]
    public class UdpListener : IListener
    {
        public Action<byte[]> MessageRecivedAction { get; set; }

        private readonly UdpClient listener;
        private bool isListen;

        public UdpListener()
        {
            int listenPort = Int32.Parse(ConfigurationManager.AppSettings["udpPort"]);
            listener = new UdpClient(listenPort);
        }

        public async void StartAsync()
        {
            isListen = true;

            Console.WriteLine("Server was started");
            try
            {
                while (isListen)
                {
                    UdpReceiveResult bytes = await listener.ReceiveAsync();
                    MessageRecivedAction?.Invoke(bytes.Buffer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
                Console.WriteLine("Server was stopped");
            }
        }

        public void Stop()
        {
            isListen = false;
        }
    }
}
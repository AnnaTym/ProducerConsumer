using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Sockets;

namespace SysLogServer.Listeners
{
    [Export(typeof(IListener))]
    public class UdpListener : IListener
    {
        public Action<byte[]> MessageRecivedAction { get; set; }

        private const int listenPort = 11000;
        private readonly UdpClient listener;
        private IPEndPoint groupEP;
        private bool isListen;

        public UdpListener()
        {
            listener = new UdpClient(listenPort);
            groupEP = new IPEndPoint(IPAddress.Any, listenPort);
        }

        public void Start()
        {
            isListen = true;

            Console.WriteLine("UdpClient start");

            try
            {
                while (isListen)
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    MessageRecivedAction?.Invoke(bytes);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
                Console.WriteLine("UdpClient stop");
            }
        }

        public void Stop()
        {
            isListen = false;
        }
    }
}
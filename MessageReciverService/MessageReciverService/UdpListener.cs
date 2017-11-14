using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageReciverService
{
    public class UdpListener
    {
        private const int listenPort = 11000;
        private readonly UdpClient listener;
        private  IPEndPoint groupEP;
        private bool isListen;

        public UdpListener()
        {
            listener = new UdpClient(listenPort);
            groupEP = new IPEndPoint(IPAddress.Any, listenPort);
        }

        public void Start()
        {
            isListen = true;

            try
            {
                while (isListen)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    Console.WriteLine($"Received broadcast from {groupEP} :\n {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        public void Stop()
        {
            isListen = false;
        }

    }
}

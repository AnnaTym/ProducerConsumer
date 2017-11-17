using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpClient
{
    public static class Program
    {
        private static string address = "127.0.0.1";

        public static void Main()
        {
            var s = new Socket(AddressFamily.InterNetwork,
                               SocketType.Dgram,
                               ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse(address);
            var ep = new IPEndPoint(broadcast, 11000);

            for (int i = 0; i < 100; i++)
            {
                byte[] sendbuf = Encoding.ASCII.GetBytes("Message " + i);

                System.Threading.Thread.Sleep(100);

                s.SendTo(sendbuf, ep);
                Console.WriteLine($"Message {i} sent to the broadcast address {address}");
            }

            Console.WriteLine("Message sent to the broadcast address");
            Console.ReadKey();
        }
    }
}

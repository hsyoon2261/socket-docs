using System;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //client = new TcpClient();
                IPAddress ipAd = IPAddress.Parse("124.53.127.89");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAd, 9999);
                client.Connect(ipEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("good");
            while (true)
            {
                
            }
            
        }
    }
}
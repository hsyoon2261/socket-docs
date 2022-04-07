using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleChatClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("124.53.127.89"), 7755));
            
            //reading
            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);
            string msgReceive = Encoding.UTF8.GetString(data, 0, count);
            Console.WriteLine(msgReceive);

            //sending to server
            
            while (true)
            {
                string msgSend = Console.ReadLine();
                clientSocket.Send(Encoding.UTF8.GetBytes(msgSend));
            }

            Console.ReadKey();
            clientSocket.Close();
        }
    }
}

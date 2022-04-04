using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 8080);
            NetworkStream ns = client.GetStream();
            string HelloMsg = "Hello World!";
            byte[] SendByteMessage = Encoding.ASCII.GetBytes(HelloMsg);
            ns.Write(SendByteMessage,0,SendByteMessage.Length);
            byte[] ReceiveByteMessage = new byte[32];
            ns.Read(ReceiveByteMessage, 0, 32);
            string ReceiveMessage = Encoding.ASCII.GetString(ReceiveByteMessage);
            Console.WriteLine(ReceiveMessage);
            StreamWriter writer = new StreamWriter(ns);
            StreamReader reader = new StreamReader(ns);

            String msg = Console.ReadLine();
            writer.WriteLine(msg);
            writer.Flush();

            string msg1 = reader.ReadLine();
            Console.WriteLine("writing message : " + msg1);
         
            writer.Close();
            reader.Close();
            client.Close();
            
            
        }
    }
}
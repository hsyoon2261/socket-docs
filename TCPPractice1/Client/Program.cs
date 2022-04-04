using System;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 8080);
            NetworkStream ns = client.GetStream();
            StreamWriter writer = new StreamWriter(ns);
            StreamReader reader = new StreamReader(ns);

            String msg = Console.ReadLine();
            writer.WriteLine(msg);
            writer.Flush();

            string msg1 = reader.ReadLine();
            Console.WriteLine("writing message : " + msg1);
            if (msg1 == "q")
            {
                writer.Close();
                reader.Close();
                client.Close();
            }
            
        }
    }
}
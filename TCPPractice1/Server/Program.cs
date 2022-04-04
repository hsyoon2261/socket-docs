using System;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcp_Listener = new TcpListener(8080);
            try
            {
                tcp_Listener.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("fail connection" + e.ToString());
                Environment.Exit(0);
            }

            Console.WriteLine("Start Server..");

            while (true)
            {
                TcpClient client = tcp_Listener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                StreamReader reader = new StreamReader(ns);
                StreamWriter writer = new StreamWriter(ns);
                string msg = reader.ReadLine();
                Console.WriteLine("message from client : " + msg);
                
                writer.WriteLine(msg);
                writer.Flush();
                // writer.Close();
                // reader.Close();
                // client.Close();
            }

        }
    }
}
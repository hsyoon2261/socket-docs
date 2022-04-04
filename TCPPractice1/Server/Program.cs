using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcp_Listener = new TcpListener(8080);
            //Console.WriteLine($"connect to {tcp_Listener.LocalEndpoint.ToString()}");
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
                byte[] ReceiveMessage = new byte[100];
                ns.Read(ReceiveMessage, 0, 100);
                string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
                Console.WriteLine(strMessage);
                string EchoMessage = "Hi Client";
                byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
                ns.Write(SendMessage,0,SendMessage.Length);
                StreamReader reader = new StreamReader(ns);
                StreamWriter writer = new StreamWriter(ns);
                string msg = reader.ReadLine();
                Console.WriteLine("message from client : " + msg);
                
                writer.WriteLine(msg);
                writer.Flush();
                writer.Close();
                reader.Close();
                ns.Close();
            }

        }
    }
}
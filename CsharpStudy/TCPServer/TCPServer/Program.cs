using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TcpSrv
{
    class Program
    {
        static void Main(string[] args)
        {
            // (1) 로컬 포트 7000 을 Listen
            TcpListener server = new TcpListener(9000);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("client connected");

            while (true)
            {
                byte[] byteData = new byte[1024];

                //NetworkStream ns = client.GetStream();
                //ns.Read(byteData, 0, byteData.Length);
                client.GetStream().Read(byteData, 0, byteData.Length);
                string stringData = Encoding.Default.GetString(byteData);
                int endPoint = stringData.IndexOf('\0');
                string parsedMessage = stringData.Substring(0, endPoint + 1);
                Console.WriteLine(parsedMessage);

                //server.Stop();
                //ns.Close();
            }
        }
    }
}
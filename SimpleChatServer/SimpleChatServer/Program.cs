using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SimpleChatServer
{
    internal class Program
    {
        static Socket serverSocket, clientSocket;
        static IPEndPoint ipEndPoint;
        static IPAddress ipAddress;
        static int PORT = 88;
        static byte[] dataBuffer = new byte[1024];
        static void Main(string[] args)
        {
            //SyncServer();
            ASyncServer();
        }
        private static void ASyncServer()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipAddress = IPAddress.Parse("127.0.0.1");
            ipEndPoint = new IPEndPoint(ipAddress, PORT);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(0);
            clientSocket = serverSocket.Accept();

            // sending msg
            string msg = "Hello Client";
            byte[] Byte = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(Byte);
            // read msg
            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallback, null);

            Console.ReadKey();
            //다음 문자나 사용자가 누른 기능 키를 가져옵니다. 누른 키는 콘솔 창에 표시됩니다.
            clientSocket.Close();
            serverSocket.Close();
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            int count = clientSocket.EndReceive(ar);
            string msgReceive = Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine(msgReceive);
            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallback, null); //재귀 호출

        }
    }
}

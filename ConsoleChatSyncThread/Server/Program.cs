using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class ClientHandler
    {
        private NetworkStream stream = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;
        private Socket socket = null;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            Program.socketList.Add(socket);
        }
        public void Chat()
        {
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            try
            {
                while (true)
                {
                    string str = reader.ReadLine();
                    Console.WriteLine(str);
                    foreach (Socket s in Program.socketList)
                    {
                        if (s != socket)
                        {
                            stream = new NetworkStream(s);
                            writer = new StreamWriter(stream) {AutoFlush = true};
                            writer.WriteLine(str);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    
    class Program
    {
        static IPEndPoint ipEndPoint;
        static int PORT = 7755;
        public static List<Socket> socketList = new List<Socket>();
        
        static void Main(string[] args)
        {

            Socket serverSocket = null;
            Socket clientsocket = null;
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ipAd = IPAddress.Parse("124.53.127.89");
                ipEndPoint = new IPEndPoint(ipAd, PORT);
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(0);
                


                while (true)
                {

                    clientsocket = serverSocket.Accept();
                    ClientHandler cHandler = new ClientHandler(clientsocket);
                    Thread t = new Thread(new ThreadStart(cHandler.Chat));
                    t.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                clientsocket.Close();
            }
        }
    }
}
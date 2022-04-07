using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class ServerHandler
    {
        private StreamReader reader = null;

        public ServerHandler(StreamReader reader)
        {
            this.reader = reader;
        }

        public void Chat()
        {
            try
            {
                while (true)
                {
                    string str = reader.ReadLine();
                    Console.WriteLine(str);
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

        static void Main(string[] args)
        {
            //TcpClient client = null;
            Socket client = null;

            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //client = new TcpClient();
                IPAddress ipAd = IPAddress.Parse("124.53.127.89");
                ipEndPoint = new IPEndPoint(ipAd, PORT);


                client.Connect(ipEndPoint);

                NetworkStream stream = new NetworkStream(client);
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream){AutoFlush = true};
                
                //thread
                ServerHandler serverHandler = new ServerHandler(reader);
                Thread t = new Thread(new ThreadStart(serverHandler.Chat));
                t.Start();

                string sendData = Console.ReadLine();
                while (true)
                {
                    writer.WriteLine(sendData);
                    if (sendData.IndexOf("<EOF>") > -1) 
                        break;
                    sendData = Console.ReadLine();


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                client.Close();
                client = null;
            }
        }
    }
}
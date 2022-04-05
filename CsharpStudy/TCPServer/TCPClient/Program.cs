using System;
using System.Data;
using System.Net.Sockets;
using System.Text;

namespace TcpCli
{
    class Program
    {
        static TcpClient client = null;
        public static bool health = true;
        static void Main(string[] args)
        {
            Chat chat = new Chat();
            while (health == true)
            {
                chat.Process();
            }

            Console.WriteLine("크라이언트를 종료합니다.");
            // Console.WriteLine("This is Client Console ");
            // Console.WriteLine("1.Connect Server");
            // Console.WriteLine("2.Send Meesage");
            // string key = Console.ReadLine();
            // int order = 0;
            // int.TryParse(key, out order);
            //
            // if (order == 1 | order == 2)
            // {
            //     switch(order)
            //     {
            //         case 1:
            //         {
            //             if (client != null)
            //             {
            //                 Console.WriteLine("이미 연결되어있습니다.");
            //                 Console.ReadKey();
            //             }
            //             else
            //             {
            //                 Connect();
            //             }
            //
            //             break;
            //         }
            //         case 2:
            //         {
            //             if (client == null)
            //             {
            //                 Console.WriteLine("먼저 서버와 연결해주세요");
            //                 Console.ReadKey();
            //             }
            //             else
            //             {
            //                 SendMessage();
            //             }
            //             break;
            //         }
            //     }
            // }
            //
            // else
            // {
            //     Console.WriteLine("잘못 입력하셨습니다.");
            //     Console.ReadKey();
            // }
            // Console.Clear();
            //
            // //byte[] buffer = Encoding.Default.GetBytes("Client connect");
            // //client.GetStream().Write(buffer, 0, buffer.Length);
            //
            // client.Close();
        }

        // private static void Connect()
        // {
        //     client = new TcpClient();
        //     client.Connect("127.0.0.1",9000);
        //     Console.WriteLine("Connect Success");
        //     Console.WriteLine("Seding Message");
        //     Console.ReadKey();
        // }
        //
        // private static void SendMessage()
        // {
        //     Console.WriteLine("Seding Message");
        //     string message = Console.ReadLine();
        //     byte[] byteData = new byte[message.Length];
        //     byteData = Encoding.Default.GetBytes(message);
        //     if (client != null)
        //     {
        //         client.GetStream().Write(byteData,0,byteData.Length);
        //         Console.WriteLine("sended");
        //         Console.ReadKey();
        //     }
        //     
        // }
    }
}
using System;
using System.Net.Sockets;

namespace TcpCli
{
    public class ConfigClient
    {
        //protected TcpClient client = null;
        protected string serverIP = "";
        protected int serverPort = 0;
        protected string userName = "";

        public void SetInfo(string ip, int port, string name)
        {
            this.serverIP = ip;
            this.serverPort = port;
            this.userName = name;
            Console.WriteLine(serverPort);
            Console.WriteLine(serverIP);
            Console.WriteLine(userName);
        }
    }
}
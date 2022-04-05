using System.Net.Sockets;

namespace TcpCli
{
    public class ConfigClient
    {
        //protected TcpClient client = null;
        protected string serverIP = 0;
        protected int serverPort = 0;
        protected string userName = "";

        public void SetInfo(string ip, int port, string name)
        {
            this.serverIP = ip;
            this.serverPort = port;
            this.userName = name;
        }
    }
}
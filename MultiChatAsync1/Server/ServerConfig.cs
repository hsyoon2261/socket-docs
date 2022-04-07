using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class ServerConfig
    {
        public int PortInput;
        private List<ServerClient> clients;
        private List<ServerClient> disconnectList;
        private TcpListener server;
        private bool serverStarted;

        public void ServerCreate()
        {
            clients = new List<ServerClient>();
            disconnectList = new List<ServerClient>();
            try
            {
                int port = 9999;
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                

                StartListening();
                serverStarted = true;
                Console.WriteLine($"서버가 {port}에서 시작되었습니다.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Update()
        {
            if (!serverStarted) return;
            foreach (ServerClient c in clients)
            {
                if (!IsConnected(c.tcp))
                {
                    c.tcp.Close();
                    disconnectList.Add(c);
                    continue;
                }
                else
                {
                    NetworkStream s = c.tcp.GetStream();
                    if (s.DataAvailable)
                    {
                        string data = new StreamReader(s, true).ReadLine();
                        if (data != null)
                            OnIncomingData(c, data);
                    }
                }
            }

            for (int i = 0; i < disconnectList.Count - 1; i++)
            {
                Broadcast($"{disconnectList[i].clientName} 연결이 끊어졌습니다", clients);

                clients.Remove(disconnectList[i]);
                disconnectList.RemoveAt(i);
            }
        }

        bool IsConnected(TcpClient c)
        {
            try
            {
                if (c != null && c.Client != null && c.Client.Connected)
                {
                    if (c.Client.Poll(0, SelectMode.SelectRead))
                        return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void StartListening()
        {
            server.BeginAcceptTcpClient(AcceptTcpClient, server);
        }

        public void AcceptTcpClient(IAsyncResult ar)
        {
            TcpListener listener = (TcpListener) ar.AsyncState;
            clients.Add(new ServerClient(listener.EndAcceptTcpClient(ar)));
            StartListening();

            Broadcast("%NAME", new List<ServerClient>() {clients[clients.Count - 1]});
        }

        public void OnIncomingData(ServerClient c, string data)
        {
            if (data.Contains("&NAME"))
            {
                c.clientName = data.Split('|')[1];
                return;
            }

            Broadcast($"{c.clientName}이 연결되었습니다.", clients);
        }

        public void Broadcast(string data, List<ServerClient> cl)
        {
            foreach (var c in cl)
            {
                try
                {

                    StreamWriter writer = new StreamWriter(c.tcp.GetStream());
                    writer.WriteLine(data);
                    writer.Flush();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public class ServerClient
        {
            public TcpClient tcp;
            public string clientName;

            public ServerClient(TcpClient clientSocket)
            {
                clientName = "Guest";
                tcp = clientSocket;
            }
        }
    }
}
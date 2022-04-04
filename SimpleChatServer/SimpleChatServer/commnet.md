private static void SyncServer()
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
            byte[] dataBuffer = new byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msgReceive = Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine(msgReceive);

            Console.ReadKey();
            //다음 문자나 사용자가 누른 기능 키를 가져옵니다. 누른 키는 콘솔 창에 표시됩니다.
            clientSocket.Close();
            serverSocket.Close();
        }
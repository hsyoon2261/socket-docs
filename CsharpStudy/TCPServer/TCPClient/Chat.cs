using System;
using System.Runtime.Serialization;

namespace TcpCli
{
    public enum ChatMode
    {
        None,
        Lobby,
        Connection,
        Room
    }
    public class Chat
    {
        private ChatMode mode = ChatMode.Lobby;
        private ConfigClient configClient = null;

        public void Process()
        {
            switch (mode)
            {
                case ChatMode.Lobby :
                    ProcessLobby();
                    break;
                case ChatMode.Connection :
                    ProcessConnection();
                    break;
            }
        }

        public void ProcessLobby()
        {
            string input = "";
            Console.WriteLine("안녕하세요 클라이언트님 당신의 이름을 입력해 주세요");
            input = Console.ReadLine();
            if (input == "")
                input = "이름없음";
            configClient = new ConfigClient();
            configClient.SetInfo("127.0.0.1",9000,input);
            mode = ChatMode.Connection;
        }

        public void ProcessConnection()
        {
            Console.WriteLine("안녕하세요 연결센터입니다.");
            Console.WriteLine("연결을 시도하시겠습니까? [1] 예 [2] 아니오");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("곧 만들예정");
                    break;
                case "2":
                    mode = ChatMode.Lobby;
            }
        }

    }
}
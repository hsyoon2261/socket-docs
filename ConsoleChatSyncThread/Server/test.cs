using System.Net.Sockets;

namespace Server
{
   public class Session
   {
      public Socket soc { get; set; }
      public string name { get; set; }
   }
}
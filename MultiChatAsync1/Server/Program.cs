using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic.CompilerServices;

namespace Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ServerConfig yes = new ServerConfig();
            try
            {
                yes.ServerCreate();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            

            while (true)
            {

            }

        }
    }
}
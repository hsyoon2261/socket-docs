using System;
using System.Net;

namespace NetworkClass
{
    class Practice
    {
        public void printIP()
        {
            Console.WriteLine("----here is printIP method---");
            Console.WriteLine("press ip adress");
            string Address = Console.ReadLine();
            IPAddress IP = IPAddress.Parse(Address);
            Console.WriteLine($"ip: {IP.ToString()}");
            Console.WriteLine("hello world");
        }

        public void printIPfromDNS()
        {
            Console.WriteLine("----here is printIPfromDNS method---");
            string dns_name = "www.naver.com";
            IPAddress[] IP = Dns.GetHostAddresses(dns_name);
            foreach (IPAddress hostIpAddress in IP)
            {
                Console.WriteLine($"{hostIpAddress}");
            }

            IPHostEntry HostInfo = Dns.GetHostEntry(dns_name);
            //HostInfo.HostName = "naver";
            foreach (IPAddress hostIpAddress in HostInfo.AddressList)
            {
                Console.WriteLine($"{HostInfo.HostName}'s ip address : {hostIpAddress} extracting from HostEntry");
            }
        }

        public void IPEndPoint01()
        {
            Console.WriteLine("----here is IPEndPoint01 method---");
            IPAddress IPInfo = IPAddress.Parse("127.0.0.1");
            int Port = 13;
            IPEndPoint EndPointInfo = new IPEndPoint(IPInfo, Port);
            Console.WriteLine(EndPointInfo.ToString());
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Practice test = new Practice();
            //test.printIP();
            test.printIPfromDNS();
            test.IPEndPoint01();
        }
    }
}
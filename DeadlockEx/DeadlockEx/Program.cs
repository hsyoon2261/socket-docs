using System;
using System.Threading;

namespace DeadlockEx
{
    internal class nums
    {
        public int a = 10;
    }

    internal class nums2
    {
        public int b = 10;
    }

    internal class Program
    {
        private static readonly nums plusnum = new();
        private static readonly nums2 plusnum2 = new();

        private static void Plus()
        {
            for (var i = 0; i < 10; i++)
                lock (plusnum)
                {
                    //Thread.Sleep(100);
                    Console.WriteLine("I am in lock1...");
                    lock (plusnum2)
                    {
                        Console.WriteLine("I am in lock2...");
                        Console.WriteLine(plusnum2.b + plusnum.a);
                    }
                }
        }

        private static void Multiple()
        {
            for (var i = 0; i < 10; i++)
                lock (plusnum2)
                {
                    //Thread.Sleep(100);
                    Console.WriteLine("I am in lock1...");
                    lock (plusnum)
                    {
                        Console.WriteLine("I am in lock2...");
                        Console.WriteLine(plusnum2.b * plusnum.a);
                    }
                }
        }

        private static void Main(string[] args)
        {
            var th1 = new Thread(() => Plus());
            var th2 = new Thread(() => Multiple());
            th1.Start();
            th2.Start();
        }
    }
}
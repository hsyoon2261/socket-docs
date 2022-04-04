using System;

namespace DelegateAndEvent
{
    delegate void PrintPlus(string str);
    
    class A
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public void Print2(string str)
        {
            Console.WriteLine("adding event");
            Console.WriteLine(str);
        }

        public event PrintPlus EventHandler; //이름은 달라도 된다.

        public void PrintEvent(String str)
        {
            EventHandler(str);
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            A Test = new A();
            PrintPlus DelMethod1 = Test.Print;
            DelMethod1("Hello delegate");
            Console.WriteLine("chaining test...");
            DelMethod1 += Test.Print;
            DelMethod1("Hello delegate");
            Console.WriteLine("--------event start----------");
            A Test2 = new A();
            Test2.EventHandler += Test.Print;
            Test2.EventHandler += Test.Print2;
            Test2.PrintEvent("Hello event");
            
            

        }
    }
}
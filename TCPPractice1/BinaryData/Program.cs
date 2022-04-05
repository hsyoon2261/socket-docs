using System;
using System.IO;


namespace BinaryData
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));
            
            bw.Write(int.MaxValue);
            bw.Write("Good Morning");
            bw.Write(uint.MaxValue);
            bw.Write("안녕하세요");
            bw.Write("Logs");
            bw.Write(double.MaxValue);

            bw.Close();

            BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));

            Console.WriteLine("File Size: {0} bytes", br.BaseStream.Length);
            Console.WriteLine("{0}",br.ReadInt32());
            Console.WriteLine("{0}",br.ReadString());
            Console.WriteLine("{0}", br.ReadUInt32());
            Console.WriteLine("{0}", br.ReadString());
            Console.WriteLine("{0}", br.ReadString());
            Console.WriteLine("{0}", br.ReadDouble());

            br.Close();
        }
    }
}
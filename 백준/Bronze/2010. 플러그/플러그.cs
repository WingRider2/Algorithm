namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System;         
    using System.IO;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            long T = long.Parse(sr.ReadLine());
            long sum = 0;
            for (long i = 0; i < T; i++)
            {
                sum += long.Parse(sr.ReadLine());
            }       

                      
            sw.WriteLine(sum - T  + 1);
            sw.Flush();
        }

    }

}
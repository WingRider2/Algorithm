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
            int n = int.Parse(sr.ReadLine());

            if (n <= 1) { sw.WriteLine(1); sw.Flush(); return; }
            
            int a = 1;  
            int b = 1; 
            for (int i = 2; i <= n; i++)
            {
                int c = (a + b) % 10007;
                a = b;
                b = c;
            }
            //sb.AppendLine(art);            
            sw.WriteLine(b);
            sw.Flush();
        }

    }

}
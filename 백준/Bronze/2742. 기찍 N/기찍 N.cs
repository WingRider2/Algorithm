namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;
    using System;          // Array, Console 등
    using System.IO;       // StreamReader/Writer, BufferedStream
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            string str = sr.ReadLine();

            if (!int.TryParse(str, out int num)) return;

            for (int i = 0; i < num; i++)
            {
                sb.AppendLine((num - i).ToString());
            }            
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }
        

    }

}
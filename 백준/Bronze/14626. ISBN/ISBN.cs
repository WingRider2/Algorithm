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
            int num = 0;
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '*')
                {
                    count = ((i % 2) == 0) ? 1 :  7;
                    continue;
                }
                int temp = str[i] - '0';
                num += ((i % 2) == 0) ? temp : temp * 3;
            }
            int need = (10 - (num % 10)) % 10;

            sb.Append((need*count)%10);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }
        

    }

}
namespace ConsoleApp1
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            var num1 = int.Parse(sr.ReadLine());
            var num2 = sr.ReadLine();
            int odd = 0;
            int nodd = 0;
            for (int i = 0; i < num1; i++)
            {
                int temp = num2[i];
                if (temp % 2 == 0) odd++;
                else nodd++;
            }

            sb.AppendLine(((odd - nodd)==0? -1 : (odd - nodd)>0? 0: 1).ToString());      

            sw.Write(sb.ToString());
            sw.Flush();
        }
    }
}

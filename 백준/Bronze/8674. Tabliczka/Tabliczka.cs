namespace ConsoleApp1
{
    using System;
    using System.IO;
    using System.Text;
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            var num = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long ans = (num[0]%2==0||num[1]%2==0) ? 0 : Math.Min(num[0], num[1]);
            sb.Append(ans);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

    }

}
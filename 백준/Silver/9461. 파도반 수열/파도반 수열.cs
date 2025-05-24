namespace ConsoleApp1
{
    using System.Numerics;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Text.RegularExpressions;
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            long[] p = new long[101];
            p[0] = 1;
            p[1] = 1;
            p[2] = 1;
            p[3] = 2;
            p[4] = 2;
            for (int i = 5; i < p.Length; i++)
            {
                p[i] = p[i - 1] + p[i - 5];
            }

            int T = int.Parse(sr.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(sr.ReadLine());
                sb.AppendLine(p[n-1].ToString());
            }

            sw.Write(sb);
            sw.Flush();
        }

    }

}
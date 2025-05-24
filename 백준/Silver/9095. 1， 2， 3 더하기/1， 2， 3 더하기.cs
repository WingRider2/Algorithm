namespace ConsoleApp1
{
    using System.Numerics;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Text.RegularExpressions;

    class Node {
        public List<Edge> edges = new();
        public bool isWordEnd;
    }
    class Edge {
        public string world;   // 합쳐진 문자열
        public Node   child;
    }
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int T = int.Parse(sr.ReadLine());


            int[] dp = new int[13];
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i < dp.Length; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(sr.ReadLine());
                sb.AppendLine(dp[n].ToString());
            }

            sw.Write(sb);
            sw.Flush();
        }

    }

}
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int count = int.Parse(sr.ReadLine());

            int[,] dp = new int[41, 2];
            dp[0, 0] = 1;
            dp[1, 1] = 1;

            for (int i = 2; i <= 40; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + dp[i - 2, 0];
                dp[i, 1] = dp[i - 1, 1] + dp[i - 2, 1];
            }

            for (int i = 0; i < count; i++)
            {
                int n = int.Parse(sr.ReadLine());

                sb.AppendLine($"{dp[n,0]} {dp[n,1]}");
            }
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }       
    }
}

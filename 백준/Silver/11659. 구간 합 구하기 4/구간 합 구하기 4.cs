namespace ConsoleApp1
{
    using System.Linq;
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
            string[] input = sr.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);            

            var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            long[] prefix = new long[N + 1];
            for (int i = 0; i < N; i++)
                prefix[i + 1] = prefix[i] + nums[i];


            for (int i = 0; i < M; i++)
            {
                string[] temp = sr.ReadLine().Split();
                int start = int.Parse(temp[0]) - 1; 
                int end   = int.Parse(temp[1]);    

                long sum = prefix[end] - prefix[start];
                sb.AppendLine(sum.ToString());
            }

            sw.Write(sb);
            sw.Flush();
        }

    }

}
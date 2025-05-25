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
        public static StringBuilder ans = new StringBuilder();
        static void Main(string[] args)
        {
            int N = int.Parse(sr.ReadLine());
            int count = 0;
            var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int i = 0; i < N; i++)
            {
                if (line[i] != i + 1) count++;
            }

            sw.Write(count);
            sw.Flush();
        }

    }

}
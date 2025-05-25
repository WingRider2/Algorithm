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
            bool found = false;

            for (int i = 1; i <= 9; i++)
            {
                if (N % i == 0)
                {
                    int j = N / i;
                    if (1 <= j && j <= 9)
                    {
                        found = true;
                        break;
                    }
                }
            }

            sw.Write(found ? 1 : 0);
            sw.Flush();
        }

    }

}
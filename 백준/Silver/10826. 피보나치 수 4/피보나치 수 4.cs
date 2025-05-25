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
            BigInteger N = BigInteger.Parse(sr.ReadLine());
            sb.Append(Fib(N));
            sw.WriteLine(sb.ToString());
            sw.Flush();

        }
        public static BigInteger Fib(BigInteger n)
        {
            BigInteger a = 0, b = 1;
            for (long i = 0; i < n; i++)
            {
                BigInteger tmp = a + b;
                a = b;
                b = tmp;
            }
            return a; 
        }
    }

}
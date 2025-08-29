namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System;         
    using System.IO;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            long n = long.Parse(sr.ReadLine());
            BigInteger ans = (n < 2) ? BigInteger.One : Product(2, n);

            sb.Append(ans);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

        static BigInteger Product(long l, long r)
        {
            if (l > r) return BigInteger.One;
            if (l == r) return new BigInteger(l);
            if (r - l == 1) return new BigInteger(l) * r;

            long m = (l + r) >> 1;
            return Product(l, m) * Product(m + 1, r);
        }
    }

}
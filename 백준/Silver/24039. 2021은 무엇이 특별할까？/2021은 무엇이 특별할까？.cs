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
            int[] primes = {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
                31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
                73, 79, 83, 89, 97, 101, 103
            };
            List<int> primeProducts = new List<int>();
            for (int i = 0; i < primes.Length - 1; i++)
            {
                primeProducts.Add(primes[i] * primes[i + 1]);
            }
            int num = int.Parse(sr.ReadLine());
            int ans = primeProducts.Where(n => n > num).OrderBy(n => n).ToList()[0];
            sb.Append(ans);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

    }

}
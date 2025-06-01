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
            var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int ans = int.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    for (int k = j + 1; k < 5; k++)
                    {
                        ans = Math.Min(ans, LCM3(nums[i], nums[j], nums[k]));
                    }
                }
            }
            sb.Append(ans);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

        static int LCM3(int a, int b, int c)
        {
            return LCM(LCM(a, b), c);
        }
        static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        static int GCD(int a, int b)
        {
            if (b == 0) return a;
            else return GCD(b, a % b);
        }
    }

}
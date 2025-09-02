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
            int T = int.Parse(sr.ReadLine());            

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());

                for (int k = 0; k < N; k++)
                {
                    int[] a = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    sb.AppendLine($"{a[0] + a[1]} {a[0] * a[1]}");
                }
            }       

                      
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

    }

}
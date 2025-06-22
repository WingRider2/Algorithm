namespace ConsoleApp1
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            var N = int.Parse(sr.ReadLine());
            List<long[]> ints = new();
            for (int i = 0; i < N; i++)
            {
                var arr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
                ints.Add(arr);
            }
            ints.Sort((a, b) =>
                {
                    if (a[1] != b[1]) return a[1].CompareTo(b[1]); 
                    return a[0].CompareTo(b[0]);                   
                });


            int ans = 0;
            long lastEnd = 0;
            
            foreach (var interval in ints)
            {
                long start = interval[0];
                long end = interval[1];
                if (start >= lastEnd)
                {
                    lastEnd = end;
                    ans++;
                }
            }
            sb.AppendLine(ans.ToString());
            sw.Write(sb.ToString());
            sw.Flush();
        }
    }
}

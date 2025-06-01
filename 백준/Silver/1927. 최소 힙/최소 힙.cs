namespace ConsoleApp1
{
    using System;
    using System.IO;
    using System.Numerics;
    using System.Text;
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            var minHeap = new PriorityQueue<int,int>();
            int num = int.Parse(sr.ReadLine());
            for (int i = 0; i < num; i++)
            {
                int tempNum = int.Parse(sr.ReadLine());
                if (tempNum == 0)
                {
                    if (minHeap.TryDequeue(out var element, out var priority))
                    {
                        sb.AppendLine(element.ToString());
                    }
                    else{
                        sb.AppendLine("0");
                    }
                }
                else
                {
                    minHeap.Enqueue(tempNum, tempNum);
                }
            }
            sw.WriteLine(sb.ToString());
            sw.Flush();

        }

    }

}
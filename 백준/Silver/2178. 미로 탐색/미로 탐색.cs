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
            int[] ints = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = ints[0];
            int M = ints[1];
            int[,] map = new int[N, M];

            (int, int) start = (0, 0);
            (int, int) end = (N, M);
            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                for (int k = 0; k < M; k++)
                {
                    map[i, k] = str[k] - '0';
                }
            }

            int[] x = { 1, -1, 0, 0 };
            int[] y = { 0, 0, 1, -1 };

            int[,] ans = new int[N, M];
            bool[,] vised = new bool[N, M];
            Queue<(int, int)> queue = new();

            queue.Enqueue(start);
            ans[start.Item1, start.Item2] = 1;
            
            while (queue.Count != 0)
            {
                (int, int) temp = queue.Dequeue();
                vised[temp.Item1, temp.Item2] = true;
                
                for (int i = 0; i < 4; i++)
                {
                    int tempx = temp.Item1 + x[i];
                    int tempy = temp.Item2 + y[i];

                    
                    if (tempx < 0 || tempx >= N) continue;
                    if (tempy < 0 || tempy >= M) continue;
                    if (vised[tempx, tempy]) continue;
                    if (map[tempx, tempy] != 0 && ans[tempx, tempy] < ans[temp.Item1, temp.Item2])
                    {
                        ans[tempx, tempy] = ans[temp.Item1, temp.Item2]+1;
                        queue.Enqueue((tempx, tempy));
                    }
                }
            }   

            sw.WriteLine(ans[N-1,M-1]);
            sw.Flush();
        }

    }

}
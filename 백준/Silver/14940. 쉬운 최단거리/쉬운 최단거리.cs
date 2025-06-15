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
            var nm = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[,] map = new int[nm[0], nm[1]];
            int[,] ans = new int[nm[0], nm[1]];

            (int n1, int n2) key = new();
            for (int i = 0; i < nm[0]; i++)
            {
                var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int k = 0; k < nm[1]; k++)
                {
                    if (line[k] == 2) key = (i, k);
                    map[i, k] = line[k];
                    ans[i, k] = int.MaxValue;
                }
            }

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            bool[,] isVisit = new bool[nm[0], nm[1]];
            Queue<(int n1, int n2)> queue = new Queue<(int n1, int n2)>();
            ans[key.n1, key.n2] = 0;
            isVisit[key.n1, key.n2] = true;
            queue.Enqueue(key);

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];

                    if (nx < 0 || ny < 0 || nx >= nm[0] || ny >= nm[1]) continue;
                    if (map[nx, ny] != 1 || isVisit[nx, ny]) continue;

                    ans[nx, ny] = ans[x, y] + 1;
                    isVisit[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }

            for (int i = 0; i < nm[0]; i++)
            {
                for (int k = 0; k < nm[1]; k++)
                {                    
                    if (map[i, k] == 0) sb.Append("0 "); // 벽
                    else if (ans[i, k] == int.MaxValue) sb.Append("-1 "); // 도달 못한 땅
                    else sb.Append(ans[i, k] + " "); // 도달한 거리
                }
                sb.AppendLine();
            }

            sw.Write(sb.ToString());
            sw.Flush();
        }
    }
}

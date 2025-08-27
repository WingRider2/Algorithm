namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;
    using System;         
    using System.IO;
    using System.ComponentModel;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int ans = 0;
            int[] ints = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[,] box = new int[ints[1], ints[0]];


            bool[,] isVisit = new bool[ints[1], ints[0]];
            Queue<(int n1, int n2)> queue = new Queue<(int n1, int n2)>();

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < ints[1]; i++)
            {
                int[] tempInts = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                for (int k = 0; k < tempInts.Length; k++)
                {
                    box[i, k] = tempInts[k];
                    if (box[i, k] == 1)
                    {
                        isVisit[i, k] = true;
                        queue.Enqueue((i, k));
                    }
                    if (box[i, k] == -1)
                    {
                        isVisit[i, k] = true;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];

                    if (nx < 0 || ny < 0 || nx >= ints[1] || ny >= ints[0]) continue;
                    if (isVisit[nx, ny]) continue;

                    box[nx, ny] = box[x, y] + 1;
                    isVisit[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }

            bool isCant = false;
            for (int i = 0; i < ints[0]; i++)
            {
                for (int k = 0; k < ints[1]; k++)
                {
                    if (box[k, i] > ans) ans = box[k, i];
                    if (box[k, i] == 0) isCant = true;
                }
            }

            sb.Append(isCant ? -1 : ans-1);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }


    }

}
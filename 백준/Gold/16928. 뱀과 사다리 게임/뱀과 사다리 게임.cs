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
            var parts = Console.ReadLine().Split();
            int N = int.Parse(parts[0]); // 사다리 개수
            int M = int.Parse(parts[1]); // 뱀 개수

            var jump = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
            {
                parts = Console.ReadLine().Split();
                int A = int.Parse(parts[0]), B = int.Parse(parts[1]);
                jump[A] = B;
            }
            for (int i = 0; i < M; i++)
            {
                parts = Console.ReadLine().Split();
                int U = int.Parse(parts[0]), V = int.Parse(parts[1]);
                jump[U] = V;
            }

            var dist = new int[101];
            for (int i = 1; i <= 100; i++) dist[i] = -1;
            var q = new Queue<int>();
            dist[1] = 0;
            q.Enqueue(1);

            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                if (cur == 100) break;

                for (int d = 1; d <= 6; d++)
                {
                    int nxt = cur + d;
                    if (nxt > 100) continue;
                    if (jump.ContainsKey(nxt))
                        nxt = jump[nxt];

                    if (dist[nxt] == -1)
                    {
                        dist[nxt] = dist[cur] + 1;
                        q.Enqueue(nxt);
                    }
                }
            }
            sb.Append(dist[100]);

            sw.Write(sb);
            sw.Flush();
        }

    }

}
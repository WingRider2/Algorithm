namespace ConsoleApp1
{
    using System.Numerics;
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
            int N = 0;
            string SN = sr.ReadLine();
            var graph = new List<int>[N+1];
            if (int.TryParse(SN, out N))//노드연결
            {
                graph = new List<int>[N + 1];
                for (int i = 1; i <= N; i++)
                    graph[i] = new List<int>();
                for (int i = 0; i < N - 1; i++)
                {
                    string[] strs = sr.ReadLine().Split();
                    int[] inputs = Array.ConvertAll(strs, int.Parse);
                    graph[inputs[0]].Add(inputs[1]);
                    graph[inputs[1]].Add(inputs[0]);
                }
            }

            //부모설정
            int LOG = (int)Math.Log2(N) + 1;
            int[,] up = new int[LOG, N + 1];
            int[] depth = new int[N + 1];
            var q = new Queue<int>();
            q.Enqueue(1);
            depth[1] = 0;
            up[0, 1] = 0; // 루트의 조상은 0
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (int v in graph[u])
                {
                    if (v == up[0, u]) continue;
                    up[0, v] = u;
                    depth[v] = depth[u] + 1;
                    q.Enqueue(v);
                }
            }

            for (int k = 1; k < LOG; k++)
            {
                for (int v = 1; v <= N; v++)
                {
                    int mid = up[k - 1, v];
                    up[k, v] = (mid == 0 ? 0 : up[k - 1, mid]);
                }
            }

            int M = int.Parse(sr.ReadLine());
            while (M-- > 0)
            {
                var sp = sr.ReadLine().Split();
                int a = int.Parse(sp[0]), b = int.Parse(sp[1]);
                sb.AppendLine(Lca(a, b, up, depth, LOG).ToString());
            }

            sw.Write(sb);
            sw.Flush();
        }  
        static int Lca(int u, int v, int[,] up, int[] depth, int LOG)
        {
            if (depth[u] < depth[v]) (u, v) = (v, u);
            int diff = depth[u] - depth[v];
            for (int k = 0; k < LOG; k++)
                if ((diff & (1 << k)) != 0)
                    u = up[k, u];
            if (u == v) return u;
            for (int k = LOG - 1; k >= 0; k--)
            {
                if (up[k, u] != up[k, v])
                {
                    u = up[k, u];
                    v = up[k, v];
                }
            }
            // 이제 둘의 부모가 LCA
            return up[0, u];
        }
    }

}
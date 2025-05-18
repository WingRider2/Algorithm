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

            //부모와 깊이 설정
            int LOG = (int)Math.Log2(N) + 1; // 부모로 올수있는경우의 수의 크기
            int[,] up = new int[LOG, N + 1]; // 앞에는 첫번째 부모인가 두번째 부모인가 , 각 노드
            int[] depth = new int[N + 1]; //노드의 깊이
            var q = new Queue<int>(); 
            q.Enqueue(1);
            depth[1] = 0;
            up[0, 1] = 0; // 루트의 조상은 0
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (int v in graph[u])
                {
                    if (v == up[0, u]) continue; //부모를 향하는 간선을 보면 실행x
                    up[0, v] = u;
                    depth[v] = depth[u] + 1;
                    q.Enqueue(v);
                }
            }

            for (int k = 1; k < LOG; k++) //부모 분만 아니라 할머니, 고조할머니 등을 저장
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
            if (depth[u] < depth[v]) (u, v) = (v, u); //깊이가 다르면 깊이 u를 더 큰값으로 한다.
            int diff = depth[u] - depth[v]; // 갚이 차이를 구하고

            for (int k = 0; k < LOG; k++) //깊이가 더 깊은 쪽을 올려서 깊이가 같은 값으로 한다.
                if ((diff & (1 << k)) != 0) // <<비트 마스킹을 쓰는 이유는 LOG는 log 2의 
                    u = up[k, u];

            //여기서 부터 본격 LCA
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
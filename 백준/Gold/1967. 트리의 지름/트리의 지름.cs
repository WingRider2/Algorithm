namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

        public class Node{
        public int id;
        public List<(Node child, int weight)> children = new();
    }
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        static int max = 0;
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(sr.ReadLine());
            Node[] nodes = new Node[n + 1];

            //노드생성
            for (int i = 1; i <= n; i++)
            {
                nodes[i] = new Node();
                nodes[i].id = i;
            }
            //노드 연결
            for (int i = 1; i < n; i++)
            {
                string[] strings = sr.ReadLine().Split();
                int[] ints = Array.ConvertAll(strings, int.Parse);
                int parent = ints[0];
                int child = ints[1];
                int weight = ints[2];
                nodes[parent].children.Add((nodes[child], weight));
                nodes[child].children.Add((nodes[parent], weight));
            }

            //리프 노드에서 시작해서 위로 올라가면서 가중치 계산해야함
            DFS(nodes[1], null);
            sb.Append(max);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

        static int DFS(Node node, Node? parent)// 양옆으로 내려가는 노드의 합을 구해야함
        {
            int longest = 0;
            int second = 0;

            foreach (var (child, weight) in node.children)
            {
                if (child == parent) continue;
                int dist = DFS(child, node) + weight;

                if (dist > longest)
                {
                    second = longest;
                    longest = dist;
                }
                else if (dist > second)
                {
                    second = dist;
                }
            }

            max = Math.Max(max, longest + second);
            return longest;

        }

    }

}
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

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int n  = int.Parse(sr.ReadLine());
            Node[] nodes = new Node[n+1];

            for (int i = 1; i <= n; i++)
            {
                nodes[i] = new Node();
                nodes[i].Nodes = new List<Node>();
                nodes[i]._int = i;
            }

            for (int i = 2; i <= n; i++)
            {
                string[] strings  = sr.ReadLine().Split();
                int[] ints = Array.ConvertAll(strings , int.Parse);
                
                    nodes[ints[1]].Nodes.Add(nodes[ints[0]]);
                    nodes[ints[0]].Nodes.Add(nodes[ints[1]]);

                //문제가 에반데
            }     

            int[] ans = new int[n+1];
            bool[] isVisble = new bool[n+1];
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            while (q.Count > 0)
            {
                int f = q.Dequeue();
                isVisble[f] = true;
                foreach (var item in nodes[f].Nodes)
                {
                    if(!isVisble[item._int]){
                        q.Enqueue(item._int);
                        ans[item._int] = f;
                    }
                }                               
            } 

            for (int i = 2; i < ans.Length; i++)
            {
                sb.AppendLine(ans[i].ToString());
            }
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }


    }
    public class Node{
        public int _int;
        public List<Node> Nodes;
    }
}
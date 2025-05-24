namespace ConsoleApp1
{
    using System.Numerics;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Text.RegularExpressions;

    class Node {
        public List<Edge> edges = new();
        public bool isWordEnd;
    }
    class Edge {
        public string world;   // 합쳐진 문자열
        public Node   child;
    }
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {


             int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                List<string> keys = new();
                Dictionary<string, List<string>> dic = new();

                int n = int.Parse(sr.ReadLine());
                for (int k = 0; k < n; k++)
                {
                    string[] tempstrings = sr.ReadLine().Split();
                    if (!dic.ContainsKey(tempstrings[1]))
                    {
                        keys.Add(tempstrings[1]);
                        dic.Add(tempstrings[1], new List<string>());
                    }
                    dic[tempstrings[1]].Add(tempstrings[0]);
                }

                int sum = 1;
                for (int k = 0; k < dic.Count; k++)
                {
                    sum *= dic[keys[k]].Count()+1;
                }
                sb.AppendLine((sum - 1).ToString());
            }

            sw.Write(sb);
            sw.Flush();
        }

    }

}
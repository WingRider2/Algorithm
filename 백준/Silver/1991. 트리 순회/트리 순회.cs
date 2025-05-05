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
            Node[] nodes = new Node[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
                nodes[i]._char = (char)('A'+i);
            }
            for (int i = 0; i < n; i++)
            {
                string[] strings  = sr.ReadLine().Split();
                char[] chars = Array.ConvertAll(strings , char.Parse);
                if(chars[1] != '.') nodes[chars[0]-'A'].left = nodes[chars[1]-'A'];
                else nodes[chars[0]-'A'].left = null;

                if(chars[2] != '.') nodes[chars[0]-'A'].right = nodes[chars[2]-'A'];
                else nodes[chars[0]-'A'].right = null;                
            }     

            sb.AppendLine(showPT(nodes[0]));
            sb.AppendLine(showIT(nodes[0]));
            sb.AppendLine(showBT(nodes[0]));
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

        static string showPT(Node? node)
        {
            if(node == null) return "";
            return node._char + showPT(node.left) + showPT(node.right);
        }
        static string showIT(Node? node)
        {
            if(node == null) return "";
            return showIT(node.left) + node._char +  showIT(node.right);
        }
        static string showBT(Node? node)
        {
            if(node == null) return "";
            return showBT(node.left) +  showBT(node.right) + node._char;
        }
    }
    public class Node{
        public char _char;
        public Node? left;
        public Node? right;
    }
}
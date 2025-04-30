using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            Stack<char> stack = new Stack<char>();// 넣을 공간
            string N = sr.ReadLine();
            bool isString = true;
            foreach (var item in N)
            {
                if (item == ' ')
                {
                    while (stack.Count > 0)
                    {
                        sb.Append(stack.Pop());
                    }
                    sb.Append(item);
                }
                else if (item == '<')
                {
                    isString = false;
                    while (stack.Count > 0)
                    {
                        sb.Append(stack.Pop());
                    }
                }
                else if (item == '>')
                {
                    isString = true;
                    sb.Append(item);
                    continue;
                }


                if (isString)
                {
                    if (item != ' ') stack.Push(item);
                }
                else
                {
                    if (item != ' ') sb.Append(item);
                }

            }
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }
            stack.Clear();
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }       

    }

}

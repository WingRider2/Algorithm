using System.Collections;
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
            int N = int.Parse(sr.ReadLine());
            
            string[] temp = sr.ReadLine().Split();
            int[] tempTops = Array.ConvertAll(temp , int.Parse);

            int[] ans = new int[N];
            Stack<(int Key, int V)> tops = new Stack<(int , int)>();
            for (int i = N-1; i >= 0; i--)
            {
                if(tops.Count == 0 ) {
                    tops.Push((i ,tempTops[i]));
                    continue;
                }

                while(tops.Count > 0){
                    if(tops.Peek().V < tempTops[i]){
                        (int Key, int V) tempTop =  tops.Pop();
                        ans[tempTop.Key] = i+1;
                    }
                    else{
                        break;
                    }
                }

                tops.Push((i ,tempTops[i]));                
            }

            
            for (int i = 0; i < ans.Length; i++)
            {
                sb.Append(ans[i]);
                if(i < ans.Length-1) sb.Append(" ");
            }       


            sw.WriteLine(sb.ToString());
            sw.Flush();
        }       
    }
}

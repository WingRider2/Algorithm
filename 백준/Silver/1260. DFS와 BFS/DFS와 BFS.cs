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

            string[] N = sr.ReadLine().Split();
            int[] ints = Array.ConvertAll(N,int.Parse);

            List<int>[] list= new List<int>[ints[0]+1];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new List<int>();
            }

            for (int i = 0; i < ints[1]; i++)
            {
                string[] N2 = sr.ReadLine().Split();
                int[] ints2 = Array.ConvertAll(N2,int.Parse);
                list[ints2[0]].Add(ints2[1]);
                list[ints2[1]].Add(ints2[0]);
            }

            for (int i = 0; i <= ints[0]; i++)
            {
                list[i].Sort();
            }

            //DFS
            bool[] isVisit =  new bool[list.Length];
            Stack<int> stack = new Stack<int>();
            stack.Push(ints[2]);
            while(stack.Count>0){
                int temp = stack.Pop();    
                if(!isVisit[temp]) sw.Write($"{temp} ");  
                isVisit[temp] = true;  
                for (int i = list[temp].Count-1; i >= 0; i--)
                {
                    if(isVisit[list[temp][i]] == false) stack.Push(list[temp][i]);
                }                
            }

            sw.WriteLine();

            //BFS
            isVisit =  new bool[list.Length];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(ints[2]);
            while(queue.Count>0){
                int temp = queue.Dequeue();
                if(!isVisit[temp]) sw.Write($"{temp} ");  
                isVisit[temp] = true;                 
                for (int i = 0; i < list[temp].Count; i++)
                {
                    if(isVisit[list[temp][i]] == false) queue.Enqueue(list[temp][i]);
                }                
            }

            sw.WriteLine(sb.ToString());
            sw.Flush();
        }       

    }

}

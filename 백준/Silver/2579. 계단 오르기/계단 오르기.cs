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
            int count = int.Parse(sr.ReadLine());

            int[] ints = new int[count+1];

            for (int i = 1; i <= count; i++)
            {
                ints[i] = int.Parse(sr.ReadLine());
            }

            

            if (count == 1)
            {
                sb.AppendLine(ints[1].ToString());
            }
            else if (count == 2)
            {
                sb.AppendLine((ints[1] + ints[2]).ToString());
            }else{
                int[] maxs = new int[count+1];
                maxs[1] = ints[1];
                maxs[2] = ints[1]+ints[2];
                maxs[3] = Math.Max(ints[1]+ints[3],ints[2]+ints[3]);
                for (int i = 4; i <= count; i++)
                {
                    maxs[i]=Math.Max(maxs[i-2]+ints[i],maxs[i-3]+ints[i-1]+ints[i]);
                }
                sb.AppendLine(maxs[count].ToString());

            }

            sw.WriteLine(sb.ToString());
            sw.Flush();
        }       
    }
}

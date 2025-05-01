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

            while(true){
                string[] strings = sr.ReadLine().Split();
                int[] ints = Array.ConvertAll(strings , int.Parse);
                if(ints[0]+ints[1]==0) break;
                if(ints[0]<ints[1]){
                    if(ints[1]%ints[0]==0) sb.AppendLine("factor");
                    else sb.AppendLine("neither");
                }else{
                    if(ints[0]%ints[1]==0) sb.AppendLine("multiple");
                    else sb.AppendLine("neither");
                }

            }

            sw.WriteLine(sb.ToString());
            sw.Flush();
        }       

    }

}

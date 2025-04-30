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
            int n = int.Parse(sr.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int m = int.Parse(sr.ReadLine());
                float sum = 0;
                int count = 0;
                for (global::System.Int32 j = 0; j < m; j++)
                {
                    string[] s = sr.ReadLine().Split();
                    float[] ints = Array.ConvertAll(s, float.Parse);
                    count += (int)ints[0];
                    sum += ints[1]* ints[0];
                    
                }
                sw.WriteLine($"{count} {(sum / count).ToString("N1")}");
            }

            sw.Flush();
        }       

    }

}

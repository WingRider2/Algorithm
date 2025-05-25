namespace ConsoleApp1
{
    using System.Linq;
    using System.Numerics;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Text.RegularExpressions;
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int num = line[0];
                int bit = line[1];
                int count = 0;

                while (num > 0)
                {
                    count += num % 2;
                    num = num / 2;
                }

                if (count % 2 == 0 && bit == 0)
                {
                    sb.AppendLine("Valid");
                }
                else if (count % 2 == 1 && bit == 1)
                {
                    sb.AppendLine("Valid");
                }
                else
                {
                    sb.AppendLine("Corrupt");
                }
            }

            sw.WriteLine(sb.ToString());
            sw.Flush();

        }

    }

}
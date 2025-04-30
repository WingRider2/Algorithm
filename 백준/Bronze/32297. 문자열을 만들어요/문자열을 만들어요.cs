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
            string s = sr.ReadLine();

            sw.WriteLine(s.Contains("gori")?"YES" :"NO");

            sw.Flush();
        }       

    }

}

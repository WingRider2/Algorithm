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
            bool isTrue = true;

            foreach (var item in N)
            {
                if (item.CompareTo("1") > 0) isTrue = false;

            }
            sw.WriteLine(isTrue? "S":"F");
            sw.Flush();
        }

    }

}

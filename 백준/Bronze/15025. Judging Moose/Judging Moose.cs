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
            string[] N = sr.ReadLine().Split();
            int num1 = int.Parse(N[0]);
            int num2 = int.Parse(N[1]);
            if (num1 == 0 && num2 == 0)
            {
                sw.WriteLine("Not a moose");
            }
            else if (num1 == num2)
            {
                sw.WriteLine($"Even {num1*2}");
            }
            else
            {
                sw.WriteLine($"Odd {Math.Max(num1, num2) * 2}");
            }

            sw.Flush();
        }

       

    }

}

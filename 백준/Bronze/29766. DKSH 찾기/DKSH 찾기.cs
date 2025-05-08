namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string str = sr.ReadLine();

            string temp = str.Replace("DKSH" , ""); 
            sb.Append((str.Length - temp.Length)/4);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }


    }

}
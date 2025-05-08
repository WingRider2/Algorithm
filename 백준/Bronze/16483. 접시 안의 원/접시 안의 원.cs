namespace ConsoleApp1
{
    using System.Text;
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int? num = int.Parse(sr.ReadLine());

            float ans = MathF.Pow((float)num/2,2);
            sb.Append((int)(ans+0.5f));
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }


    }

}
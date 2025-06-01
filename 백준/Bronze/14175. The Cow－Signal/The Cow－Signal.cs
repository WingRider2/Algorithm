namespace ConsoleApp1
{
    using System;
    using System.IO;
    using System.Text;
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            string[] strings = new string[nums[0]];
            
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = sr.ReadLine();
            }

            for (int i = 0; i < nums[0]; i++)
            {
                string str = strings[i];
                for (int k = 0; k < nums[2]; k++)
                {
                    foreach (var item in str)
                    {
                        for (int z = 0; z < nums[2]; z++)
                        {
                            sb.Append(item);
                        }
                    }
                    sb.AppendLine();
                }
            }
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

    }

}
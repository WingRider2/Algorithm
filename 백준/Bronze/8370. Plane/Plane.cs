namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;
    using System;         
    using System.IO;
    using System.ComponentModel;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int[] ints = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            sb.Append(ints[0]*ints[1] + ints[2]*ints[3]);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }

    }

}
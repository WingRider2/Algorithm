namespace ConsoleApp1
{
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;
    using System;         
    using System.IO;
    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            //string str = sr.ReadLine();

            string art = 
            "     /~\\\n" +
            "    ( oo|\n" +
            "    _\\=/_\n" +
            "   /  _  \\\n" +
            "  //|/.\\|\\\\\n" +
            " ||  \\ /  ||\n" +
            "============\n" +
            "|          |\n" +
            "|          |\n" +
            "|          |";
            Console.WriteLine(art);


            sw.WriteLine(sb.ToString());
            sw.Flush();
        }


    }

}
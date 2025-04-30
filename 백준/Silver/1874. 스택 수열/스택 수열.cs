namespace ConsoleApp1
{
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const int bufferSize = 131072;
        public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
        public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

        static void Main(string[] args)
        {

            int num = int.Parse(sr.ReadLine());
            int[] arr = new int[num];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(sr.ReadLine());
            }
            Stack<int> stack = new Stack<int>();
            int pushNum = 0;
            StringBuilder b = new StringBuilder();
            bool isCan = true;
            foreach (var item in arr)
            {
                if (pushNum == 0) {
                    pushNum++; 
                    stack.Push(1);
                    b.Append("+");
                }
                while (pushNum != item&& pushNum < item)
                {
                    pushNum++;
                    stack.Push(pushNum);
                    b.Append("\n+");
                }
                if(pushNum >= item)
                {
                    int a =stack.Pop();
                    if (a != item)
                    {
                        isCan = false;
                    }
                    b.Append("\n-");
                }
            }
            if (!isCan)
            {
                sw.WriteLine("NO");
            }
            else sw.Write(b);
            sw.Flush();
        }
    }
}
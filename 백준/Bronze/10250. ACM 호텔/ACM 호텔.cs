    internal class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder sb = new StringBuilder();

            string[] s = Console.ReadLine().Split();
            
            for (int i = 0; i < int.Parse(s[0]); i++)
            {
                string[] m = Console.ReadLine().Split();
                int H = int.Parse(m[0]); //6                
                int W = int.Parse(m[1]); // 12
                int traget = int.Parse(m[2]); // 10

                int _y = traget % H != 0 ?traget % H : H;
                int _x = traget % H != 0 ? traget / H+1 : traget / H;
                
                Console.WriteLine(_y.ToString() + _x.ToString("00"));
            }
            //Console.WriteLine(sb.ToString());
        }

    }
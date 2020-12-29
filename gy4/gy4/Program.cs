using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace gy4
{
    class Program
    {
        public static int[] numbers = new int[1000000];
        public static int db1;
        public static int db2;
        static void Main(string[] args)
        {
            //szekvenciális
            Random rnd = new Random(1000);
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(10);
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int db = counter(numbers,0, 999999);
            sw.Stop();
            Console.WriteLine("=== SZEKVENCIALISAN ===");
            Console.WriteLine("Tömb mérete: " + numbers.Length);
            Console.WriteLine("5-ösök darabszáma: " + db);
            Console.WriteLine("idő (ms): " + sw.ElapsedMilliseconds);

            Console.Write("\n\n");
            //párhuzamos
            sw.Start();
            Thread t1 = new Thread(ThreadMethod1);
            Thread t2 = new Thread(ThreadMethod2);
            db = db1 + db2;
            sw.Stop();
            Console.WriteLine("=== PÁRHUZAMOSAN ===");
            Console.WriteLine("Szálak száma: " + 2);
            Console.WriteLine("5-ösök darabszáma: " + db);
            Console.WriteLine("idő (ms): " + sw.ElapsedMilliseconds);
        }
        private static void ThreadMethod1()
        {
             db1 = counter(numbers, 0, 500000);
        }
        private static void ThreadMethod2()
        {
            db2 = counter(numbers, 500000, 1000000);
        }
        private static int counter(int[] numbers,int startIDX,int endIDX)
        {
            int counter = 0;
            for (int i = startIDX; i < endIDX; i++)
            {
                if (numbers[i] == 5)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

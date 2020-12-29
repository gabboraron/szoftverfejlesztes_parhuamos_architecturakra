using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadExamples
{
    class Program
    {
        static int interval;

        [ThreadStatic]
        static ConsoleColor textColor;

        static void Main(string[] args)
        {
            Console.WriteLine("Szál közvetlen létrehozása");
            Console.WriteLine("Fõszál (sorszáma: {0})", Thread.CurrentThread.GetHashCode());
            Thread newThread = new Thread(ThreadMethod); // .NET 1.1 esetén:  Thread newThread = new Thread(new ThreadStart(ThreadMethod));
            newThread.Name = "Új szál";
            newThread.Start();
            Console.ReadLine();
            newThread.Join();

            interval = 100;

            newThread = new Thread(ThreadMethod); 
            newThread.Name = "Új szál";
            newThread.Start();
            Thread.Sleep(150);
            newThread = new Thread(ThreadMethod);
            newThread.Name = "Új szál";
            newThread.Start();
            Thread.Sleep(150);
            newThread = new Thread(ThreadMethod);
            newThread.Name = "Új szál";
            newThread.Start();
            Thread.Sleep(150);
            newThread = new Thread(ThreadMethod);
            newThread.Name = "Új szál";
            newThread.Start();
            Console.ReadLine();
            newThread.Join();
            Console.ResetColor();
 

            Console.WriteLine("Szálak létrehozása a ThreadPool osztály segítségével");
            Console.WriteLine("Fõszál (sorszáma: {0})", Thread.CurrentThread.GetHashCode());
            interval = 100;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod));
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod));
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod));
            Thread.Sleep(150);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod));
            Console.ReadLine();
            Console.ResetColor();
        }

        static void ThreadMethod()
        {
//            Console.WriteLine("{0} (sorszáma {1})", Thread.CurrentThread.Name, Thread.CurrentThread.GetHashCode());

            textColor = (ConsoleColor)(Thread.CurrentThread.ManagedThreadId * 3 % 16);

            Console.ForegroundColor = textColor;
            Console.WriteLine("Szál sorszáma: " + Thread.CurrentThread.ManagedThreadId);

            DisplayThreadData();
            DisplayNumbers();

            Console.ForegroundColor = textColor;
            Console.WriteLine("Vége");
        }

        static void ThreadPoolMethod(object state)
        {
            textColor = (ConsoleColor) (Thread.CurrentThread.ManagedThreadId * 3 % 16);
            
            Console.ForegroundColor = textColor;
            Console.WriteLine("Szál sorszáma: " + Thread.CurrentThread.ManagedThreadId);
            
            DisplayThreadData();
            DisplayNumbers();

            Console.ForegroundColor = textColor;
            Console.WriteLine("Vége");
        }

        private static void DisplayThreadData()
        {
            Console.WriteLine("Szál adatai");
            Console.WriteLine("\tPrioritás:\t\t{0}", Thread.CurrentThread.Priority);
            Console.WriteLine("\tKultúra:\t\t{0}", Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("\tThreadPool szál?\t{0}", Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("\tÁllapot:\t\t{0}", Thread.CurrentThread.ThreadState);
            Console.WriteLine();
        }

        static void DisplayNumbers()
        {
            for (int i = 1; i <= 5 * interval; i++)
            {
                if (i % interval == 0)
                {
                    Console.ForegroundColor = textColor;
                    Console.WriteLine("A számláló értéke " + i);
                    Thread.Sleep(250);
                }
            }
        }
    }
}
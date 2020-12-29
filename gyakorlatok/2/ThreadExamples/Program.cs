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
            Console.WriteLine("Sz�l k�zvetlen l�trehoz�sa");
            Console.WriteLine("F�sz�l (sorsz�ma: {0})", Thread.CurrentThread.GetHashCode());
            Thread newThread = new Thread(ThreadMethod); // .NET 1.1 eset�n:  Thread newThread = new Thread(new ThreadStart(ThreadMethod));
            newThread.Name = "�j sz�l";
            newThread.Start();
            Console.ReadLine();
            newThread.Join();

            interval = 100;

            newThread = new Thread(ThreadMethod); 
            newThread.Name = "�j sz�l";
            newThread.Start();
            Thread.Sleep(150);
            newThread = new Thread(ThreadMethod);
            newThread.Name = "�j sz�l";
            newThread.Start();
            Thread.Sleep(150);
            newThread = new Thread(ThreadMethod);
            newThread.Name = "�j sz�l";
            newThread.Start();
            Thread.Sleep(150);
            newThread = new Thread(ThreadMethod);
            newThread.Name = "�j sz�l";
            newThread.Start();
            Console.ReadLine();
            newThread.Join();
            Console.ResetColor();
 

            Console.WriteLine("Sz�lak l�trehoz�sa a ThreadPool oszt�ly seg�ts�g�vel");
            Console.WriteLine("F�sz�l (sorsz�ma: {0})", Thread.CurrentThread.GetHashCode());
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
//            Console.WriteLine("{0} (sorsz�ma {1})", Thread.CurrentThread.Name, Thread.CurrentThread.GetHashCode());

            textColor = (ConsoleColor)(Thread.CurrentThread.ManagedThreadId * 3 % 16);

            Console.ForegroundColor = textColor;
            Console.WriteLine("Sz�l sorsz�ma: " + Thread.CurrentThread.ManagedThreadId);

            DisplayThreadData();
            DisplayNumbers();

            Console.ForegroundColor = textColor;
            Console.WriteLine("V�ge");
        }

        static void ThreadPoolMethod(object state)
        {
            textColor = (ConsoleColor) (Thread.CurrentThread.ManagedThreadId * 3 % 16);
            
            Console.ForegroundColor = textColor;
            Console.WriteLine("Sz�l sorsz�ma: " + Thread.CurrentThread.ManagedThreadId);
            
            DisplayThreadData();
            DisplayNumbers();

            Console.ForegroundColor = textColor;
            Console.WriteLine("V�ge");
        }

        private static void DisplayThreadData()
        {
            Console.WriteLine("Sz�l adatai");
            Console.WriteLine("\tPriorit�s:\t\t{0}", Thread.CurrentThread.Priority);
            Console.WriteLine("\tKult�ra:\t\t{0}", Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("\tThreadPool sz�l?\t{0}", Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("\t�llapot:\t\t{0}", Thread.CurrentThread.ThreadState);
            Console.WriteLine();
        }

        static void DisplayNumbers()
        {
            for (int i = 1; i <= 5 * interval; i++)
            {
                if (i % interval == 0)
                {
                    Console.ForegroundColor = textColor;
                    Console.WriteLine("A sz�ml�l� �rt�ke " + i);
                    Thread.Sleep(250);
                }
            }
        }
    }
}
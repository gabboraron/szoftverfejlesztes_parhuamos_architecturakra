using System;
using System.Threading;

namespace FirstExample
{

    public class ThreadExample
    {
        public static void RunT0()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.Write("x");
                Thread.Sleep(100);
            }
        }

        public static void Main(string[] args)
        {
            // Main thread starts a new thread which runs RunT0 method
            Thread t0 = new Thread(new ThreadStart(RunT0));
            t0.Start();
        }
    }
}
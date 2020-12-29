using System;
using System.Threading;

namespace MT01Start
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart job = new ThreadStart(Threadjob);
            Thread thrd = new Thread(job);
            thrd.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main thread :" + i);
                Thread.Sleep(1000);
            }
        }

            static void Threadjob()
            {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Other thread :" + i);
                Thread.Sleep(500);
            }
                
        }
    }
}

using System;
using System.Threading;

namespace MT02ParameterizedStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thrd = new Thread(new ParameterizedThreadStart(Threadjob));
            thrd.Start((object)10);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main thread: " + i);
                Thread.Sleep(1000);
            }
        }

        static void Threadjob(object par)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Parametrized thread (parameter)={0}, and i={1}: ", par.ToString(), i);
                Thread.Sleep(500);
            }
            
        }
    }
}

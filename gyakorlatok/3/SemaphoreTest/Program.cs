using System;
using System.Threading;
using System.Text;

namespace SemaphoreTest
{
    class Program
    {
        static Semaphore s = new Semaphore(3, 3);   // Available=3; Capacity=3

        static void Main()
        {
            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            s.WaitOne();
            Console.WriteLine(id + " is in!");           // Only three threads
            Thread.Sleep(1000 * (int)id);                // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            s.Release();
        }
    }
}

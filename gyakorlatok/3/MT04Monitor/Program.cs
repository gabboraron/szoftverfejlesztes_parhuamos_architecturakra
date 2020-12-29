using System;
using System.Threading;

namespace MT04Monitor
{
    class Program
    {
        static int count = 0;
        static readonly object countLock = new object();

        static void Main(string[] args)
        {
            Thread thrd = new Thread(new ThreadStart(Threadjob));
            thrd.Start();

            for (int i = 0; i < 5; i++)
            {
                Monitor.Enter(countLock);
                // count++;
                try
                {
                    int tmp = count;
                    Console.WriteLine("Read count = {0}", tmp);
                    Thread.Sleep(50);
                    tmp++;
                    Console.WriteLine("Incremented tmp to = {0}", tmp);
                    Thread.Sleep(20);
                    count = tmp;
                    Console.WriteLine("Written count = {0}", tmp);
                    if (i == 3)
                        throw new ApplicationException();
                    Monitor.Exit(countLock); // Hibás Monitor.Exit kezelés!
                }
                catch (ApplicationException)
                {
                }
                Thread.Sleep(30);
            }
            thrd.Join();
            Console.WriteLine("Final count: {0}", count);
            Console.ReadLine();
        }

        static void Threadjob()
        {
            for (int i = 0; i < 5; i++)
            {
                Monitor.Enter(countLock);
                //count++;
                int tmp = count;
                Console.WriteLine("\t\t\tRead count = {0}", tmp);
                Thread.Sleep(20);
                tmp++;
                Console.WriteLine("\t\t\tIncremented tmp to = {0}", tmp);
                Thread.Sleep(10);
                count = tmp;
                Console.WriteLine("\t\t\tWritten count = {0}", tmp);
                Monitor.Exit(countLock);
                Thread.Sleep(40);
            }
        }
    }
}


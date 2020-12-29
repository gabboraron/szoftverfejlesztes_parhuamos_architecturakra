using System;
using System.Threading;
using System.Collections;


namespace SzalPolling
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList threads = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                Szal sz = new Szal();
                sz.PeldanyNo = i;
                Thread t = new Thread(new ThreadStart(sz.TMetodus));
                threads.Add(t);
                t.Start();
            }
            // Alvó állapot megjelenítése a fõszálból
            while(true)
            {
                 for (int i = 0; i < 10; i++)
                {
                    Thread t = (Thread)threads[i];
                    if (t.ThreadState == ThreadState.WaitSleepJoin)
                    {
                        Console.WriteLine("Alszok: {0}, állapot:{1}", i, t.ThreadState);
                    }
                }
                // Kisebb CPU terhelést jelent:
                Thread.Sleep(1);
            }
        }

        class Szal
        {
            public int PeldanyNo;
            public void TMetodus()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Szál {0}, iteráció: {1}",
                                      PeldanyNo, i);
                    Thread.Sleep(5);
                }
            }
        }
    }
}

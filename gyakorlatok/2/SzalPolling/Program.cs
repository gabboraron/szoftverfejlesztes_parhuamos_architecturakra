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
            // Alv� �llapot megjelen�t�se a f�sz�lb�l
            while(true)
            {
                 for (int i = 0; i < 10; i++)
                {
                    Thread t = (Thread)threads[i];
                    if (t.ThreadState == ThreadState.WaitSleepJoin)
                    {
                        Console.WriteLine("Alszok: {0}, �llapot:{1}", i, t.ThreadState);
                    }
                }
                // Kisebb CPU terhel�st jelent:
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
                    Console.WriteLine("Sz�l {0}, iter�ci�: {1}",
                                      PeldanyNo, i);
                    Thread.Sleep(5);
                }
            }
        }
    }
}

using System;
using System.Threading;

namespace AbortTest
{
    class Test
    {
        static void P()
        {
            try
            {
                try
                {
                    try
                    {
                        while (true)
                        {
                            Thread.Sleep(1);
                            Console.WriteLine("run");
                        }
                    }
                    catch (ThreadAbortException) { Console.WriteLine("-- inner aborted"); }
                }
                catch (ThreadAbortException) 
                { 
                    Console.WriteLine("-- outer aborted");
                    Console.WriteLine("Thread state: " + Thread.CurrentThread.ThreadState);
                    Thread.ResetAbort();
                    Console.WriteLine("Thread state: " + Thread.CurrentThread.ThreadState);
                    Thread.Sleep(200);
                }
            }
            //finally { Console.WriteLine("-- finally"); }
            catch (ThreadAbortException)
            {
                Console.WriteLine("-- last catch");

            }
        }

        static void Main(string[] arg)
        {
            Thread t = new Thread(P);
            t.Start(); Thread.Sleep(200);
            t.Abort();
            Console.WriteLine("done");
            t.Join(); 
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}

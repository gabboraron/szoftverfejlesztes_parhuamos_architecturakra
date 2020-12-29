using System;
using System.Threading;
using System.Text;

namespace SignalingWaitPulse
{
    class SimpleWaitPulse
    {
        static object locker = new object();
        static bool go;

        static void Main()
        {                                  // The new thread will block
            new Thread(Work).Start();      // because go==false.

            Console.ReadLine();            // Wait for user to hit Enter

            lock (locker)                  // Let's now wake up the thread by        
            {                              // setting go=true and pulsing.
                go = true;
                // Monitor.PulseAll(locker);
                Monitor.Pulse(locker);
            }
        }

        static void Work()
        {
            lock (locker)
                while (!go)
                    Monitor.Wait(locker);

            Console.WriteLine("Woken!!!");
        }
    }
}

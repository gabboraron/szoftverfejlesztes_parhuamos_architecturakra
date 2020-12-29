using System;
using System.Threading;
using System.Text;

namespace BasicWaitHandle
{
    class BasicWaitHandle
    {
        static EventWaitHandle wh = new AutoResetEvent(false);

        static void Main()
        {
            new Thread(Waiter).Start();
            Thread.Sleep(1000);                  // Pause for a second...
            wh.Set();                            // Wake up the Waiter.
        }

        static void Waiter()
        {
            Console.WriteLine("Waiting...");
            wh.WaitOne();                        // Wait for notification
            Console.WriteLine("Notified");
        }
    }
}

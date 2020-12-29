using System;
using System.Threading;
using System.Text;

namespace TwoWaySignalingWithEventWaitHandle
{
    class TwoWaySignaling
    {
        // static EventWaitHandle ready = new AutoResetEvent(false);
        // or with Cross-Process EventwitHandle: 
        static EventWaitHandle ready = new EventWaitHandle(false, EventResetMode.AutoReset, "bmfnik.hu TwoWaySignaling");
        static EventWaitHandle go = new AutoResetEvent(false);

        static volatile string task;         // We must either use volatile
        // or lock around this field
        static void Main()
        {
            new Thread(Work).Start();

            // Signal the worker 5 times
            for (int i = 1; i <= 5; i++)
            {
                ready.WaitOne();              // First wait until worker is ready
                task = "a".PadRight(i, 'h');  // Assign a task
                go.Set();                     // Tell worker to go!
            }

            ready.WaitOne();
            task = null;                 // Signal the worker to exit using a null task
            go.Set();
        }

        static void Work()
        {
            while (true)
            {
                ready.Set();                  // Indicate that we're ready
                go.WaitOne();                 // Wait to be kicked off...
                if (task == null) return;     // Gracefully exit
                Console.WriteLine(task);
            }
        }
    }
}

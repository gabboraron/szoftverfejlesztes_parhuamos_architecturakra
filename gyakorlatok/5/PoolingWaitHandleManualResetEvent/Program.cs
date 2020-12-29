using System;
using System.Threading;
using System.Text;

namespace PoolingWaitHandleManualResetEvent
{
    class Test
    {
        static ManualResetEvent starter = new ManualResetEvent(false);

        public static void Main()
        {
            ThreadPool.RegisterWaitForSingleObject(starter, Go, "hello", -1, true);
            Thread.Sleep(5000);
            Console.WriteLine("Signaling worker...");
            starter.Set();
            Console.ReadLine();
        }

        public static void Go(object data, bool timedOut)
        {
            Console.WriteLine("Started " + data);
            // Perform task...
        }
    }
}

using System;
using System.Threading;

namespace MonitorThreadPoolAutoReset
{
    // Note: The class whose internal public member is the synchronizing 
    // method is not public; none of the client code takes a lock on the 
    // Resource object.The member of the nonpublic class takes the lock on 
    // itself. Written this way, malicious code cannot take a lock on 
    // a public object.
    class SyncResource
    {
        public void Access(Int32 threadNum)
        {
            // Uses Monitor class to enforce synchronization.
            lock (this)
            {
                // Synchronized: Despite the next conditional, each thread 
                // waits on its predecessor.
                if (threadNum % 2 == 0)
                    Thread.Sleep(2000);
                Console.WriteLine("Start Synched Resource access (Thread={0})", threadNum);
                Thread.Sleep(200);
                Console.WriteLine("Stop Synched Resource access (Thread={0})", threadNum);
            }
        }
    }

    // Without the lock, the method is called in the order in which threads reach it.
    class UnSyncResource
    {
        public void Access(Int32 threadNum)
        {
            // Does not use Monitor class to enforce synchronization.
            // The next call throws the thread order.
            if (threadNum % 2 == 0)
                Thread.Sleep(2000);
            Console.WriteLine("Start UnSynched Resource access (Thread={0})", threadNum);
            Thread.Sleep(200);
            Console.WriteLine("Stop UnSynched Resource access (Thread={0})", threadNum);
        }
    }

    public class App
    {
        static Int32 numAsyncOps = 5;
        static AutoResetEvent asyncOpsAreDone = new AutoResetEvent(false);
        static SyncResource SyncRes = new SyncResource();
        static UnSyncResource UnSyncRes = new UnSyncResource();

        public static void Main()
        {

            for (Int32 threadNum = 0; threadNum < 5; threadNum++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(SyncUpdateResource), threadNum);
            }

            // Wait until this WaitHandle is signaled.
            asyncOpsAreDone.WaitOne();
            Console.WriteLine("\t\nAll synchronized operations have completed.\t\n");

            // Reset the thread count for unsynchronized calls.
            numAsyncOps = 5;

            for (Int32 threadNum = 0; threadNum < 5; threadNum++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(UnSyncUpdateResource), threadNum);
            }

            // Wait until this WaitHandle is signaled.
            asyncOpsAreDone.WaitOne();
            Console.WriteLine("\t\nAll unsynchronized thread operations have completed.");
            Console.ReadLine();
        }


        // The callback method's signature MUST match that of a 
        // System.Threading.TimerCallback delegate (it takes an Object 
        // parameter and returns void).
        static void SyncUpdateResource(Object state)
        {
            // This calls the internal synchronized method, passing 
            // a thread number.
            SyncRes.Access((Int32)state);

            // Count down the number of methods that the threads have called.
            // This must be synchronized, however; you cannot know which thread 
            // will access the value **before** another thread's incremented 
            // value has been stored into the variable.
            if (Interlocked.Decrement(ref numAsyncOps) == 0)
                asyncOpsAreDone.Set();
            // Announce to Main that in fact all thread calls are done.
        }

        // The callback method's signature MUST match that of a 
        // System.Threading.TimerCallback delegate (it takes an Object 
        // parameter and returns void).
        static void UnSyncUpdateResource(Object state)
        {
            // This calls the internal synchronized method, passing a thread number.
            UnSyncRes.Access((Int32)state);

            // Count down the number of methods that the threads have called.
            // This must be synchronized, however; you cannot know which thread 
            // will access the value **before** another thread's incremented 
            // value has been stored into the variable.
            if (Interlocked.Decrement(ref numAsyncOps) == 0)
                asyncOpsAreDone.Set();
            // Announce to Main that in fact all thread calls are done.
        }
    }
}

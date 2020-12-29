using System;
using System.Threading;

namespace ReaderWriter
{
    class Program
    {
        static int theResource = 0;
        static ReaderWriterLock rwl = new ReaderWriterLock();
        static void Main()
        {
            Thread tr0 = new Thread(ThreadReader);
            Thread tr1 = new Thread(ThreadReader);
            Thread tw = new Thread(ThreadWriter);
            tr0.Start(); tr1.Start(); tw.Start();
            tr0.Join(); tr1.Join(); tw.Join();
            Console.ReadLine();
        }
        static void ThreadReader()
        {
            for (int i = 0; i < 3; i++)
                try
                {
                    // AcquireReaderLock() raises an 
                    // ApplicationException when timed out.
                    rwl.AcquireReaderLock(1000);
                    Console.WriteLine("Begin Read  theResource = {0}", theResource);
                    Thread.Sleep(10);
                    Console.WriteLine("End   Read  theResource = {0}", theResource);
                    rwl.ReleaseReaderLock();
                }
                catch (ApplicationException) { Console.WriteLine("reader error");/* ... */ }
        }
        static void ThreadWriter()
        {
            for (int i = 0; i < 3; i++)
                try
                {
                    // AcquireReaderLock() raises an 
                    // ApplicationException when timed out.
                    rwl.AcquireWriterLock(1000);
                    Console.WriteLine("Begin Write theResource = {0}", theResource);
                    Thread.Sleep(100);
                    theResource++;
                    Console.WriteLine("End   Write theResource = {0}", theResource);
                    rwl.ReleaseWriterLock();
                }
                catch (ApplicationException) { Console.WriteLine("writer error"); /* ... */ }
        }
    }
}

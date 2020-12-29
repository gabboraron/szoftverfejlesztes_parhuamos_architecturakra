using System;
using System.Threading;
using System.Text;

namespace MutexOneApplicationInstance
{
    class OneAtATimePlease
    {
         //Naming a Mutex makes it available computer-wide. Use a name that's
         //unique to your company and application (e.g., include your URL).

        //static Mutex mutex = new Mutex(false, "Albahari OneAtATimeDemo");

        //static void Main()
        //{
        //     Wait a few seconds if contended, in case another instance
        //     of the program is still in the process of shutting down.

        //    if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
        //    {
        //        Console.WriteLine("Another instance of the app is running. Bye!");
        //        return;
        //    }
        //    try
        //    {
        //        Console.WriteLine("Running. Press Enter to exit");
        //        Console.ReadLine();
        //    }
        //    finally { mutex.ReleaseMutex(); }
        //}



        static void Main()
        {
            // Wait a few seconds if contended, in case another instance
            // of the program is still in the process of shutting down.
            bool first;
            Mutex mutex = new Mutex(false, "Albahari OneAtATimeDemo", out first);

            if (!first)
            {
                Console.WriteLine("Another instance of the app is running. Bye!");
                return;
            }
            else
                try
                {
//                    mutex.WaitOne(TimeSpan.FromSeconds(3));
                    Console.WriteLine("Running. Press Enter to exit");
                    Console.ReadLine();
                }
                finally { /* mutex.ReleaseMutex(); */ }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace ThreadTest
{
    class ThreadTest
    {
        bool done;
        static void Main()
        {
            ThreadTest tt = new ThreadTest(); // Create a common instance
            new Thread(tt.Go).Start();
            tt.Go();
        }

        // Note that Go is now an instance method
        void Go()
        {
            if (!done) { Console.WriteLine("Done"); done = true; }
        }
    }



}

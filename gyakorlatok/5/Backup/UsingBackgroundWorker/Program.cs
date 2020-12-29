using System;
using System.Threading;
using System.ComponentModel;

namespace UsingBackgroundWorker
{
    class Program
    {
        static BackgroundWorker bw;

        static void Main()
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            bw.RunWorkerAsync("Hello to worker");

            Console.WriteLine("Press Enter in the next 5 seconds to cancel");
            Console.ReadLine();
            if (bw.IsBusy) bw.CancelAsync();
            Console.ReadLine();
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bw.ReportProgress(0, "Hello from worker"); 
            for (int i = 0; i <= 100; i += 20)
            {
                if (bw.CancellationPending) { e.Cancel = true; return; }
                bw.ReportProgress(i);
                Thread.Sleep(1000);     // Just for the demo... don't go sleeping
            }                           // for real in pooled threads!

            e.Result = 123;             // This gets passed to RunWorkerCompleted
        }

        static void bw_RunWorkerCompleted(object sender,
                                           RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("You cancelled!");
            else if (e.Error != null)
                Console.WriteLine("Worker exception: " + e.Error.ToString());
            else
                Console.WriteLine("Complete: " + e.Result);      // from DoWork
        }

        static void bw_ProgressChanged(object sender,
                                        ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
                Console.WriteLine("Message from thread: " + e.UserState.ToString());
            else
                Console.WriteLine("Reached " + e.ProgressPercentage + "%");
        }
    }
}

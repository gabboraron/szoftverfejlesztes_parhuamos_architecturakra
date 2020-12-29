using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProducerConsumerAutoResetEvent
{
    public class TaskQueue : IDisposable
    {
        EventWaitHandle wh = new AutoResetEvent(false);
        object locker = new object();
        Thread[] workers;
        Queue<string> taskQ = new Queue<string>();

        public TaskQueue(int workerCount)
        {
            workers = new Thread[workerCount];

            // Create and start a separate thread for each worker
            for (int i = 0; i < workerCount; i++)
                (workers[i] = new Thread(Consume)).Start();
        }

        public void Dispose()
        {
            // Enqueue one null task per worker to make each exit.
            foreach (Thread worker in workers)
            {
                EnqueueTask(null);
                worker.Join();
            }
            wh.Close();
        }

        public void EnqueueTask(string task)
        {
            lock (locker)
            {
                taskQ.Enqueue(task);            // We must pulse because we're
                wh.Set();                       // changing a blocking condition.
            }
        }

        void Consume()
        {
            while (true)                        // Keep consuming until
            {                                   // told otherwise
                string task = null;
                lock (locker)
                {
                    if (taskQ.Count > 0)
                    {
                        task = taskQ.Dequeue();
                        if (task == null) return;
                    }
                }
                if (task == null)
                {
                    wh.WaitOne();
                    return;         // This signals our exit
                }
                else
                {
                    Console.Write(task);              // Perform task.
                    Thread.Sleep(1000);               // Simulate time-consuming task
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (TaskQueue q = new TaskQueue(2))
            {
                q.EnqueueTask("Hello");
                for (int i = 0; i < 10; i++)
                    q.EnqueueTask(" Task" + i);
                q.EnqueueTask("Good bye!");

                Console.WriteLine("Enqueued tasks");
                Console.WriteLine("Waiting for tasks to complete...");
            }

            // Exiting the using statement runs TaskQueue's Dispose method, which
            // shuts down the consumers, after all outstanding tasks are completed.

            Console.WriteLine("\r\nAll tasks done!");
        }
    }
}


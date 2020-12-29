using System;
using System.Threading;
using System.Text;

namespace LockStringBuilder
{
    class Program
    {
        static StringBuilder text = new StringBuilder();
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Thread firstThread = new Thread(new ThreadStart(Fun1));
            Thread secondThread = new Thread(new ThreadStart(Fun2));
            firstThread.Start();
            secondThread.Start();
            firstThread.Join();
            secondThread.Join();
            Console.WriteLine("text is:\r\n{0}", text.ToString());
            Console.ReadLine();
        }

        public static void Fun1()
        {
            lock (lockObject)
            {
                for (int i = 1; i < 20; i++)
                {
                    Thread.Sleep(10);
                    text.Append(i.ToString() + " ");
                }
            }
        }
        public static void Fun2()
        {
            lock (lockObject)
            {
                for (int i = 21; i < 40; i++)
                {
                    Thread.Sleep(2);
                    text.Append(i.ToString() + " ");
                }
            }
        }

    }
}

using System;
using System.Threading;

namespace ProducerConsumerWithMonitorWaitPulse
{
    class Buffer
    {
        char[] buf;
        int head, tail, n;
        int size;

        public Buffer(int size)
        {
            buf = new char[size];
            this.size = size;
            head = tail = n = 0;
        }

        public void Put(char ch)
        {
            Console.WriteLine(Thread.CurrentThread.Name + " calls Put");
            lock (this)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " access granted");
                while (n == size) Monitor.Wait(this);
                buf[tail] = ch; 
                tail = (tail + 1) % size; 
                n++;
                Console.WriteLine(Thread.CurrentThread.Name + " ready: n=" + n);
                Console.WriteLine();
                Monitor.Pulse(this);
            }
        }

        public char Get()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " calls Get");
            lock (this)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " access granted");
                while (n == 0) Monitor.Wait(this);
                char ch = buf[head]; head = (head + 1) % size; n--;
                Console.WriteLine(Thread.CurrentThread.Name + " ready: n=" + n);
                Console.WriteLine();
                Monitor.Pulse(this);
                return ch;
            }
        }
    }

    class BufferTest
    {
        static Buffer buf = new Buffer(4);
        static Random rand = new Random();

        static void Produce()
        {
            for (int i = 0; i < 10; i++)
            {
                char a = (char)(65 + i);
                buf.Put(a);
                Thread.Sleep(rand.Next(100));
            }
        }

        static void Consume()
        {
            for (int i = 0; i < 10; i++)
            {
                char ch = buf.Get();
                Console.WriteLine(ch);
                Thread.Sleep(rand.Next(1000));
            }
        }

        static void Main(string[] arg)
        {
            Thread p1 = new Thread(new ThreadStart(Produce));
            Thread p2 = new Thread(new ThreadStart(Produce));
            Thread p3 = new Thread(new ThreadStart(Produce));
            Thread p4 = new Thread(new ThreadStart(Produce));
            Thread c1 = new Thread(new ThreadStart(Consume));
            Thread c2 = new Thread(new ThreadStart(Consume));
            Thread c3 = new Thread(new ThreadStart(Consume));
            p1.Name = "Producer1"; p2.Name = "Producer2";
            p3.Name = "Producer3"; p4.Name = "Producer4";
            c1.Name = "Consumer1"; c2.Name = "Consumer2";
            c3.Name = "Consumer3"; 
            p1.Start(); p2.Start(); c1.Start(); c2.Start();
            p3.Start(); p4.Start(); c3.Start();
            Console.ReadLine();
        }
    }
}


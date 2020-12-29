using System;
using System.Threading;

namespace PingPongByMonitorPulseAndWait
{
    public class Program
    {
        static object ball = new object();
        public static void Main()
        {
            Thread threadPing = new Thread(ThreadPingProc);
            Thread threadPong = new Thread(ThreadPongProc);
            threadPing.Start(); threadPong.Start();
            threadPing.Join(); threadPong.Join();
            Console.ReadLine();
        }
        static void ThreadPongProc()
        {
            Console.WriteLine("ThreadPong: Hello!");
            lock (ball)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("ThreadPong: Pong ");
                    Monitor.Pulse(ball);
                    Monitor.Wait(ball);
                }
                Monitor.Pulse(ball);
            }
            Console.WriteLine("ThreadPong: Bye!");
        }
        static void ThreadPingProc()
        {
            Console.WriteLine("ThreadPing: Hello!");
            lock (ball)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("ThreadPing: Ping ");
                    Monitor.Pulse(ball);
                    Monitor.Wait(ball);
                }
                Monitor.Pulse(ball);
            }
            Console.WriteLine("ThreadPing: Bye!");
        }
    }
}

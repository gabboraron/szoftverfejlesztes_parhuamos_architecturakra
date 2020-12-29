using System;
using System.Threading;


namespace signal_pingpong
{
    class Program
    {
        public static int ball;
        static void Main(string[] args)
        {
            new Thread ping = Thread(PingProc);
            new Thread pong = Thread(Pong);
            Console.WriteLine("Hello World!");
        }

        static void PingProc()
        {
            lock (ball)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Ping");
                    Monitor.Pulse(ball);
                    Monitor.Wait(ball);
                }
            }
        }
        static void PongProc()
        {
            lock (ball)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Pong");
                    Monitor.Pulse(ball);
                    Monitor.Wait(ball);
                }
            }
        }
    }
}

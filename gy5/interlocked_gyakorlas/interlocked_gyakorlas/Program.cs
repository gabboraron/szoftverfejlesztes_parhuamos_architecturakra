using System;
using System.Threading;

namespace interlocked_gyakorlas
{
    class Program
    {
        static Semaphore s = new Semaphore(3, 3); //első érték: elérhetőek száma, hogy a tlejes kapacitásban hány elérhető; a második érték a kapacitás
        static void Main()
        {
            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            s.WaitOne();
            Console.WriteLine(id + " is in!");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine(id + " is leaving");
            s.Release();
        }
    }
}


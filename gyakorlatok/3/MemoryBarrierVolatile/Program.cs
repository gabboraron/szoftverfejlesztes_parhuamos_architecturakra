using System;
using System.Threading;

namespace MemoryBarrierVolatile
{
    //// Volatile lehet:
    //- Referencia t�pusok (nem amire hivatkoznak)
    //- Pointer (unsafe k�dblokkban)
    //- 32 bites CPU-namespace: sbyte, byte, short, ushort, int, uint, char, float, bool
    //- 64 bites CPU-namespace: double, long, ulong
    //- felsorol�sok, amelyek az al�bbikon alapulnak: sbyte, byte, short, ushort, int, uint
    
    class ThreadUnsafe
    {
        // 1. V�rakozhat-e sok�ig a Wait met�dus, miut�n endIsNigh igaz lesz?
        // 2. �rhat-e ki a Wait: Gone false-t?
        // Cache miatt a v�ltoz�k friss�t�si sorrendje elt�rhet a k�dsorrendt�l
        static bool endIsNigh, repented;
        // Cache helyett mindig aktu�lis �rt�k jelenik meg:
        //static volatile bool endIsNigh, repented;
        static void Main()
        {
            new Thread(Wait).Start();   // Start up the spinning waiter
            Thread.Sleep(1000);         // Give it a second to warm up!
            repented = true;
            endIsNigh = true;
            Console.WriteLine("Going...");
        }
        static void Wait()
        {
            while (!endIsNigh) ;        // Spin until endIsNigh
            Console.WriteLine("Gone, " + repented);
        }
    }
}

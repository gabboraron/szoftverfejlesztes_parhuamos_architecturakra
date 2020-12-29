using System;
using System.Threading;

namespace MemoryBarrierVolatile
{
    //// Volatile lehet:
    //- Referencia típusok (nem amire hivatkoznak)
    //- Pointer (unsafe kódblokkban)
    //- 32 bites CPU-namespace: sbyte, byte, short, ushort, int, uint, char, float, bool
    //- 64 bites CPU-namespace: double, long, ulong
    //- felsorolások, amelyek az alábbikon alapulnak: sbyte, byte, short, ushort, int, uint
    
    class ThreadUnsafe
    {
        // 1. Várakozhat-e sokáig a Wait metódus, miután endIsNigh igaz lesz?
        // 2. Írhat-e ki a Wait: Gone false-t?
        // Cache miatt a változók frissítési sorrendje eltérhet a kódsorrendtõl
        static bool endIsNigh, repented;
        // Cache helyett mindig aktuális érték jelenik meg:
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

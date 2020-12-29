using System;
using System.Threading;
using System.Text;

namespace AtomicityInterlocked
{
    class Program
    {
        static int x, y;
        static long sum;

        static void Main()
        {
            x = 3;      // atomic
            x++;        // non atomic
            y += x;     // non atomic (read and write)
            sum = 0;    // non atomic on 32-bit CPU

                                                                         // sum 
            // Simple increment/decrement operations:
            Interlocked.Increment(ref sum);                              // 1
            Interlocked.Decrement(ref sum);                              // 0

            // Add/subtract a value:
            Interlocked.Add(ref sum, 3);                                 // 3

            // Read a 64-bit field:
            Console.WriteLine(Interlocked.Read(ref sum));                // 3

            // Write a 64-bit field while reading previous value:
            // (This prints "3" while updating sum to 10)
            Console.WriteLine(Interlocked.Exchange(ref sum, 10));        // 10
            Console.WriteLine(sum);                                      // 3

            // Update a field only if it matches a certain value (10):
            Console.WriteLine(Interlocked.CompareExchange(ref sum, 123, 10)); // 10
            Console.WriteLine(sum);                                      // 123
            Console.ReadLine();
        }
    }
}

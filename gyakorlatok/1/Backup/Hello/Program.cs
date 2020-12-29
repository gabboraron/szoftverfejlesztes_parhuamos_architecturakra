using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
                Console.WriteLine(String.Format("Szervusz, {0}!", args[0]));
            else
                Console.WriteLine("Szervusz, világ!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace parkolo_szemaforral
{
    class Program
    {
        //static Semaphore s = new Semaphore(3, 3); //első érték: elérhetőek száma, hogy a tlejes kapacitásban hány elérhető; a második érték a kapacitás
        static Semaphore s; //első érték: elérhetőek száma, hogy a tlejes kapacitásban hány elérhető; a második érték a kapacitás
        static void Main()
        {
            Console.Write("Adja meg hány parkoló elérhető: ");
            int free = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg hány parkolóhely van összesen: ");
            int total = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg hány autóra működjön a szimuláció: ");
            int cars = Convert.ToInt32(Console.ReadLine());

            s = new Semaphore(free, total);

            Console.WriteLine("\nA parkolo megnyílt: \n");
            for (int i = 1; i <= cars; i++) new Thread(Enter).Start(i);

            Console.ReadKey();
        }
            

            static void Enter(object id)
            {
                Console.WriteLine(id + ". autó parkolna");
                s.WaitOne();
                Console.WriteLine(id + ". autó leparkolt!");
                Thread.Sleep(1000 * (int)id);
                Console.WriteLine(id + ". autó távozik...");
                s.Release();
            }
    }
}
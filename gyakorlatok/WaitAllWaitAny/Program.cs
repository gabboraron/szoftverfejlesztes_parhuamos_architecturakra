using System;
using System.Threading;
using System.Collections;

namespace WaitAllWaitAny
{
    class Program
    {
        // ManualResetEvent haszn�lata


        static void Main(string[] args)
        {
            ArrayList threads = new ArrayList();
            ManualResetEvent[] eddigOk = new ManualResetEvent[10];
            ManualResetEvent[] vege = new ManualResetEvent[10];

            for (int i = 0; i < 10; i++)
            {
                Szal sz = new Szal();
                sz.PeldanyNo = i;
                Thread t = new Thread(new ThreadStart(sz.T4Metodus));
                threads.Add(t);

                //Indul�skor kikapcsolt
                eddigOk[i] = new ManualResetEvent(false);
                sz.eddigOk = eddigOk[i];
                vege[i] = new ManualResetEvent(false);
                sz.vege = vege[i];
                t.Start();
            }
            //V�runk...
            int index = WaitHandle.WaitAny(eddigOk);
            Console.WriteLine("A leggyorsabb v�gzett a r�szfeladat�val: " + index.ToString());
            //V�runk tov�bb...
            WaitHandle.WaitAll(vege);
            Console.WriteLine("Minden sz�l dolgozik.");

            for (int i = 0; i < 10; i++)
            {
                Thread t = (Thread)threads[i];
                t.Join();
            }
            Console.WriteLine("Minden sz�l v�gzett.");
            Console.ReadLine();
        }
    }
    class Szal
    {
        public int PeldanyNo;
        public ManualResetEvent eddigOk;
        public ManualResetEvent vege;

        public void T4Metodus()
        {
            Console.WriteLine("T4({0}) sz�l l�trej�tt.", PeldanyNo);

            //Visszajelz�nk, eddig k�sz vagyunk.
            eddigOk.Set();
            Thread.Sleep(200);

            vege.Set();
            Thread.Sleep(2000); //Dolgozunk tov�bb...
        }
    }
}

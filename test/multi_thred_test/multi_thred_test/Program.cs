using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multi_thred_test
{
    class thredData
    {
        public int my_simulation_size;
        public int[,] my_simulation;
        public string my_path;
        public int my_nrOfAvailableThreads;
        public int my_oneThreeadSubsimulationSize;

        public thredData(ref int simsize, ref int[,] simu, ref string path, ref int availabelthrd, ref int subsimsize)
        {
            my_simulation_size = simsize;
            my_simulation = new int[simsize, simsize];
            for (int i = 0; i < simsize; i++)
            {
                for (int j = 0; j < simsize; j++)
                {
                    my_simulation[i, j] = simu[i, j];
                }
            }
            my_path = path;
            my_nrOfAvailableThreads = availabelthrd;
            my_oneThreeadSubsimulationSize = subsimsize;
        }

    }

    class Program
    {
        public static int simulation_size = 20;
        public static int[,] simulation = new int[20, 20];
        public static string path = Directory.GetCurrentDirectory();
        public static int nrOfAvailableThreads = Environment.ProcessorCount;
        public static int oneThreeadSubsimulationSize = simulation_size / nrOfAvailableThreads;
        public static thredData tmp;

        public static void Main(string[] args)
        {
            for (int idx = 0; idx < simulation_size; idx++)
            {
                for (int jdx = 0; jdx < simulation_size; jdx++)
                {
                    simulation[idx, jdx] = idx * 100 + jdx;
                }
            }

            StreamWriter sw = new StreamWriter(path + "_matrix.txt");
            Console.WriteLine("Szimulációs mátrix itt érhető el: " + path + "_matrix.txt");

            for (int idx = 0; idx < simulation_size; idx++)
            {
                for (int jdx = 0; jdx < simulation_size; jdx++)
                {
                    sw.Write(simulation[idx, jdx] + " ");
                }
                sw.WriteLine(" ");
            }
            sw.Close();


            //////////////////////////////////////////////

            Console.Write(" Az észlelt szálak száma: " + nrOfAvailableThreads + " => "); Console.WriteLine("alszimulációs mátrix mérete: " + oneThreeadSubsimulationSize + " X " + simulation_size);

            tmp = new thredData(ref simulation_size, ref simulation, ref path, ref nrOfAvailableThreads, ref oneThreeadSubsimulationSize);

            //generate threads
            for (int thrdnr = 0; thrdnr < nrOfAvailableThreads; thrdnr++)
            {
                Thread newThread = new Thread(ThreadMethod);
                newThread.Name = Convert.ToString(thrdnr);
                newThread.Start();
            }

            Console.ReadKey();
        }

        private static void ThreadMethod()
        {
            Thread thr = Thread.CurrentThread;
            int simulationSize = Convert.ToInt32(thr.Name);

            int thrd_simulation_size;
            int[,] thrd_simulation;
            string thrd_path;
            int thrd_nrOfAvailableThreads;
            int thrd_oneThreeadSubsimulationSize;

            lock (tmp)
            {
                thrd_simulation_size = tmp.my_simulation_size;
                thrd_simulation = new int[thrd_simulation_size, thrd_simulation_size];
                //int[,] my_simulation;
                for (int i = 0; i < tmp.my_simulation_size; i++)
                {
                    for (int j = 0; j < tmp.my_simulation_size; j++)
                    {
                        thrd_simulation[i, j] = tmp.my_simulation[i, j];
                    }
                }
                thrd_path = tmp.my_path;
                thrd_nrOfAvailableThreads = tmp.my_nrOfAvailableThreads;
                thrd_oneThreeadSubsimulationSize = tmp.my_oneThreeadSubsimulationSize;
            }

            Console.WriteLine(thr.Name + "thrd_simulation_size: " + thrd_simulation_size);
            Console.WriteLine(thr.Name + "thrd_nrOfAvailableThreads: " + thrd_nrOfAvailableThreads);
            Console.WriteLine(thr.Name + "thrd_oneThreeadSubsimulationSize: " + thrd_oneThreeadSubsimulationSize);
            Console.WriteLine("Nevem: " + thr.Name + " | mátrixom:" + thrd_simulation.Length);
            Console.WriteLine("Nevem: " + thr.Name + " | " + thrd_oneThreeadSubsimulationSize * simulationSize + " -> "+ thrd_oneThreeadSubsimulationSize);

            for (int i = thrd_oneThreeadSubsimulationSize * simulationSize; i < (thrd_oneThreeadSubsimulationSize * simulationSize) +thrd_oneThreeadSubsimulationSize; i++)//sor
            {
                for (int j = 0; j < thrd_simulation_size; j++)//oszlop
                {
                    Console.Write(thr.Name + ":" + thrd_simulation[i, j] + " ");
                }
                Console.Write("\n");
            }
            //Console.ReadKey();

        }
    }
}

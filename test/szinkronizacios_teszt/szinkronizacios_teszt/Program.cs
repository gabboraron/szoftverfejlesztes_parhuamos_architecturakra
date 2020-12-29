using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multi_thred_test
{
    class MyMutex
    {
        public Boolean used;
        public Mutex mutex;
        public MyMutex(string name)
        {
            mutex = new Mutex(false, name, out used);
            used = false;
        }

    }

    public class TaskInfo
    {
        public RegisteredWaitHandle Handle = null;
        public string OtherInfo = "default";
    }

    public class ThrdSignalPack
    {
        public AutoResetEvent ev;
        public TaskInfo ti;
    }
    class Program
    {
        public static int simulation_size = 20;
        public static int[,] simulation = new int[20, 20];
        public static string path = Directory.GetCurrentDirectory();
        public static int nrOfAvailableThreads = Environment.ProcessorCount;
        public static int oneThreeadSubsimulationSize = simulation_size / nrOfAvailableThreads;
        public static object obj = new object();
        //public static EventWaitHandle ewh = new AutoResetEvent(false);
        //public static EventWaitHandle[] ewhs;
        //public static Semaphore[] semaphores = new Semaphore[nrOfAvailableThreads]; //annyi szemafor ahány  szál, mindegyiknek egy, í]y egymást le tudják kérdezgetni
        public static MyMutex[] mutexes = new MyMutex[nrOfAvailableThreads];
        public static ThrdSignalPack[] signals = new ThrdSignalPack[nrOfAvailableThreads];

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

            //create a vector with semaphores, for threads
            //?
            //syncronize

            //generate threads
            for (int thrdnr = 0; thrdnr < nrOfAvailableThreads; thrdnr++)
            {
                //Thread newThread = new Thread(ThreadMethod);
                //newThread.Name = Convert.ToString(thrdnr);
                //newThread.Start();
                
                //mutexes[thrdnr] = new MyMutex(Convert.ToString(thrdnr));// new Mutex(false, Convert.ToString(thrdnr));// ez már nem játszik

                ///mutexes[thrdnr] = new MyMutex(Convert.ToString(thrdnr));
                //semaphores[thrdnr] = new Semaphore(0, 1);
                signals[thrdnr].ti = (TaskInfo) new TaskInfo();
                signals[thrdnr].ev = new AutoResetEvent(false);
                signals[thrdnr].ti.OtherInfo = Convert.ToString(thrdnr);
                signals[thrdnr].ti.Handle = ThreadPool.RegisterWaitForSingleObject(
                                                signals[thrdnr].ev,
                                                new WaitOrTimerCallback(WaitProc),
                                                signals[thrdnr].ti,
                                                300000,
                                                false
                                            );


            }

            Console.ReadKey();
        }

        public static void WaitProc(object state, bool timedOut)
        {
            // The state object must be cast to the correct type, because the
            // signature of the WaitOrTimerCallback delegate specifies type
            // Object.
            TaskInfo ti = (TaskInfo)state;

            int simulationSize = Convert.ToInt32(ti.OtherInfo);
            string cause = "TIMED OUT";
            int thrd_simulation_size;
            int[,] thrd_simulation;
            string thrd_path;
            int thrd_nrOfAvailableThreads;
            int thrd_oneThreeadSubsimulationSize;
            thrd_simulation_size = simulation_size;
            thrd_simulation = new int[thrd_simulation_size, thrd_simulation_size];
            //int[,] my_simulation;
            for (int i = 0; i < simulation_size; i++)
            {
                for (int j = 0; j < simulation_size; j++)
                {
                    thrd_simulation[i, j] = simulation[i, j];
                }
            }
            thrd_path = path;
            thrd_nrOfAvailableThreads = nrOfAvailableThreads;
            thrd_oneThreeadSubsimulationSize = oneThreeadSubsimulationSize;

            for (int sz = 0; sz < 3; sz++)
            {
                //Mutex.WaitOn();
                for (int i = thrd_oneThreeadSubsimulationSize * simulationSize; i < (thrd_oneThreeadSubsimulationSize * simulationSize) + thrd_oneThreeadSubsimulationSize; i++)//sor
                {
                    for (int j = 0; j < thrd_simulation_size; j++)//oszlop
                    {
                        //Console.Write(thr.Name + ":" + thrd_simulation[i, j] + " ");
                    }
                    //Console.Write("\n");
                }

                //semaphores[Convert.ToInt32(thr.Name)].WaitOne();
                if (Convert.ToInt32(simulationSize) > 0)
                {
                    //előző szál megvárása
                    //semaphores[Convert.ToInt32(thr.Name) - 1].WaitOne();
                    signals[Convert.ToInt32(simulationSize) - 1].ev.Set();
                }
                if (Convert.ToInt32(simulationSize) < thrd_nrOfAvailableThreads)
                {
                    //következő szál megvárása
                    //semaphores[Convert.ToInt32(thr.Name) + 1].WaitOne();
                    signals[Convert.ToInt32(simulationSize) + 1].ev.Set();
                }

                if (!timedOut)
                {
                    cause = "SIGNALED";
                    // If the callback method executes because the WaitHandle is
                    // signaled, stop future execution of the callback method
                    // by unregistering the WaitHandle.
                    if (ti.Handle != null)
                        ti.Handle.Unregister(null);
                }
            }
            Console.WriteLine("WaitProc( {0} ) executes on thread {1}; cause = {2}.",
                ti.OtherInfo,
                Thread.CurrentThread.GetHashCode().ToString(),
                cause
            );
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
            //lock (obj)
            //{
                thrd_simulation_size = simulation_size;
                thrd_simulation = new int[thrd_simulation_size, thrd_simulation_size];
                //int[,] my_simulation;
                for (int i = 0; i < simulation_size; i++)
                {
                    for (int j = 0; j < simulation_size; j++)
                    {
                        thrd_simulation[i, j] = simulation[i, j];
                    }
                }
                thrd_path = path;
                thrd_nrOfAvailableThreads = nrOfAvailableThreads;
                thrd_oneThreeadSubsimulationSize = oneThreeadSubsimulationSize;
            //}
            /*
            Console.WriteLine(thr.Name + "thrd_simulation_size: " + thrd_simulation_size);
            Console.WriteLine(thr.Name + "thrd_nrOfAvailableThreads: " + thrd_nrOfAvailableThreads);
            Console.WriteLine(thr.Name + "thrd_oneThreeadSubsimulationSize: " + thrd_oneThreeadSubsimulationSize);
            Console.WriteLine("Nevem: " + thr.Name + " | mátrixom:" + thrd_simulation.Length);
            Console.WriteLine("Nevem: " + thr.Name + " | " + thrd_oneThreeadSubsimulationSize * simulationSize + " -> " + thrd_oneThreeadSubsimulationSize);
            */

            /*
            //try
            //{
                //mutexes[Convert.ToInt32(thr.Name)];
                Mutex.OpenExisting(Convert.ToString(thr.Name));
                Console.WriteLine("\n Látom a mutexem! " + Convert.ToString(thr.Name) + " vagyok!");
                Console.WriteLine(Convert.ToString(thr.Name) + ": " + mutexes[Convert.ToInt32(thr.Name)].used);
                mutexes[Convert.ToInt32(thr.Name)].mutex.ReleaseMutex();
                Console.WriteLine(Convert.ToString(thr.Name) + ": -felengedés után - " + mutexes[Convert.ToInt32(thr.Name)].used);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("\n Nem látom a mutexem! " + Convert.ToString(thr.Name) + " vagyok!");
            //}
            */

            //
            for (int sz = 0; sz < 3; sz++)
            {
                //Mutex.WaitOn();
                for (int i = thrd_oneThreeadSubsimulationSize * simulationSize; i < (thrd_oneThreeadSubsimulationSize * simulationSize) + thrd_oneThreeadSubsimulationSize; i++)//sor
                {
                    for (int j = 0; j < thrd_simulation_size; j++)//oszlop
                    {
                        //Console.Write(thr.Name + ":" + thrd_simulation[i, j] + " ");
                    }
                    //Console.Write("\n");
                }

                //semaphores[Convert.ToInt32(thr.Name)].WaitOne();
                if (Convert.ToInt32(thr.Name) > 0)
                {
                    //előző szál megvárása
                    //semaphores[Convert.ToInt32(thr.Name) - 1].WaitOne();
                    signals[Convert.ToInt32(thr.Name) - 1].ev.Set();
                }
                if (Convert.ToInt32(thr.Name) < thrd_nrOfAvailableThreads)
                {
                    //következő szál megvárása
                    //semaphores[Convert.ToInt32(thr.Name) + 1].WaitOne();
                    signals[Convert.ToInt32(thr.Name) + 1].ev.Set();
                }
            }

            //Console.ReadKey();

        }
    }
}

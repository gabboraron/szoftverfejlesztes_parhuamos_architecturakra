using System;
using System.Threading;
using System.Threading.Tasks;


public class TaskThings
{
    public TaskThings() { }
    public int id;
    public Boolean done;
    public Task t;
}


public class Example
{
    static object lockObject = new object();
    static int szinkszamlalo = 0;

    public static int i = 1;
    public static int j = 0;

    private static Boolean fst = false;
    private static Boolean snd = false;

    public static TaskThings[] szalaim;
    public static int[] szimulacio = new int[2];

    public static void Main()
    {
        #region
        //ShowThreadInfo("Application");

        //var t = Task.Run(() => ShowThreadInfo("Task"));

        /*
        Task t2 = new Task(Increment1);  
        Task t3 = new Task(Increment2);

        t2.RunSynchronously();
        t3.RunSynchronously();

        */

        //fst.ture += fst.Fst;
        //t.Wait();
        #endregion

        int MAX = 2;
        szalaim = new TaskThings[MAX];

        szimulacio[0] = 0;                  szimulacio[1] = 1;
        szalaim[0] = new TaskThings();      szalaim[1] = new TaskThings();

        for (int szal_idx = 0; szal_idx < MAX; szal_idx++)
        {
            szalaim[szal_idx].id = szal_idx;
            szalaim[szal_idx].done = false;
            //szalaim[szal_idx].t = new Task(Increment);
            szalaim[szal_idx].t = new Task(() => Increment(Convert.ToString(szal_idx)));
            szalaim[szal_idx].t.RunSynchronously();
        }

        //Console.WriteLine("VÉGE?");
        Console.ReadKey();
    }

    static async void Increment(string id)
    {
        int me = Convert.ToInt32(id);
        int szinkronizciokSzama = 0;

        Console.WriteLine(id + ". szál: szimulációs érték - " + Convert.ToString(szimulacio[me]) );
        //Console.WriteLine(id + ". szál: saját obj érték [id] - " + Convert.ToString(szalaim[me].id) );
        lock (lockObject)
        {
            szimulacio[me]++;
            Console.WriteLine(id + ". szál: szimulációs érték inc után - " + Convert.ToString(szimulacio[me]));
        }
        szalaim[me].done = true;
        Szinkronizalas2(me);
        while (szinkszamlalo != szinkronizciokSzama+1)
        {
            await Task.Delay(1);
        }
        Console.WriteLine(id + ". szál: szimulációs érték szinkronizálás  után - " + Convert.ToString(szimulacio[me]));
    }

    private static void Szinkronizalas2(int who)
    {
        Boolean OK = false;
        if (szalaim[who].done)
        {
            try
            {
                if (szalaim[who - 1].done)
                {
                    OK = true;
                }

                if (szalaim[who + 1].done)
                {
                    OK = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR - " + Convert.ToString(who));
            }
        }
        
        if (OK)
        {
            Console.WriteLine("Szinkronizalas");
            int tmp = szimulacio[1];
            szimulacio[1] = szimulacio[0];
            szimulacio[0] = tmp;
            szinkszamlalo++;
            Console.WriteLine("Szinkronizalas vége! - " + szinkszamlalo);
        }
    }

    #region

    static void Szinkronizalas()
    {
        if (szinkszamlalo < 1 && fst && snd)
        {
            Console.WriteLine("Szinkronizalas");
            int tmp = i;
            i = j;
            j = tmp;
            szinkszamlalo++;
            Console.WriteLine("Szinkronizalas vége! - " + szinkszamlalo);
        }
    }
    static async void Increment1()
    {
        lock (lockObject)
        {
            i++;
            Console.WriteLine("Increment1 - regi: " + i);
            fst = true;
        }

        Szinkronizalas();
        while (szinkszamlalo != 1)
        {

            //Console.WriteLine("Increment1 szinronizálni tud");
            await Task.Delay(1);
        }
        Console.WriteLine("Increment1 - új: " + i);
    }
    static async void Increment2()
    {
        lock (lockObject)
        {
            j++;
            snd = true;
            Console.WriteLine("Increment2 - regi: " + j);
        }

        Szinkronizalas();

        if (szinkszamlalo == 1)
        {
            //Console.WriteLine("Increment2 szinronizálni tud");
            await Task.Delay(1);
        }
        Console.WriteLine("Increment2 - új: " + j);
    }

    static void ShowThreadInfo(String s)
    {
        Console.WriteLine("{0} Thread ID: {1}",
                          s, Thread.CurrentThread.ManagedThreadId);
    }
    #endregion
}
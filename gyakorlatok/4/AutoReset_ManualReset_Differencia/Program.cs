using System;
using System.Threading;
using System.Text;

namespace AutoReset_ManualReset_Differencia
{
    class Program
    {
       static AutoResetEvent Auto = new AutoResetEvent(false);
       static ManualResetEvent Man = new ManualResetEvent(false);
       
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(T));
            t.Start();

            bool bAuto = Auto.WaitOne(1000, false);
            string state = bAuto ? "Signaled" : "Nonsignaled";
            Console.WriteLine("AutoResetEvent v�rakoz�s el�tt: {0}", state);
            bAuto = Auto.WaitOne(1000, false);
            state = bAuto ? "Signaled" : "Nonsignaled";
            Console.WriteLine("AutoResetEvent v�rakoz�s ut�n: {0}", state);

            bool bMan = Man.WaitOne(1000, false);
            state = bMan ? "Signaled" : "Nonsignaled";
            Console.WriteLine("ManualResetEvent v�rakoz�s el�tt: {0}", state);
            bMan = Man.WaitOne(1000, false);
            state = bMan ? "Signaled" : "Nonsignaled";
            Console.WriteLine("ManualResetEvent: v�rakoz�s ut�n {0}", state);

            bMan = Man.Reset();
            state = bMan ? "Nonsignaled" : "Signaled";
            Console.WriteLine("ManualResetEvent: Reset ut�n {0}", state);
            bMan = Man.WaitOne(1000, false);
            state = bMan ? "Signaled" : "Nonsignaled";
            Console.WriteLine("ManualResetEvent: v�rakoz�s ut�n {0}", state);
            Console.ReadLine();
        }
        
        static void T()
        {
            Auto.Set();
            Man.Set();
            Thread.Sleep(1200);
            Man.Set();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;


namespace WindowsWaitAll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

                //Induláskor kikapcsolt
                eddigOk[i] = new ManualResetEvent(false);
                sz.eddigOk = eddigOk[i];
                vege[i] = new ManualResetEvent(false);
                sz.vege = vege[i];
                t.Start();
            }
            //Várunk...
            WaitHandle.WaitAny(eddigOk);
            Console.WriteLine("A leggyorsabb végzett a részfeladatával.");
            //Várunk tovább...
//            WaitHandle.WaitAll(vege);
//            Console.WriteLine("Minden szál dolgozik.");

            for (int i = 0; i < 10; i++)
            {
                Thread t = (Thread)threads[i];
                t.Join();
            }
            Console.WriteLine("Minden szál végzett.");
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
            Console.WriteLine("T4({0}) szál létrejött.", PeldanyNo);

            //Visszajelzünk, eddig kész vagyunk.
            eddigOk.Set();
            Thread.Sleep(200);

            vege.Set();
            Thread.Sleep(2000); //Dolgozunk tovább...
        }
    }
}
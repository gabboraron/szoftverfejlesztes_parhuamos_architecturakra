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

                //Indul�skor kikapcsolt
                eddigOk[i] = new ManualResetEvent(false);
                sz.eddigOk = eddigOk[i];
                vege[i] = new ManualResetEvent(false);
                sz.vege = vege[i];
                t.Start();
            }
            //V�runk...
            WaitHandle.WaitAny(eddigOk);
            Console.WriteLine("A leggyorsabb v�gzett a r�szfeladat�val.");
            //V�runk tov�bb...
//            WaitHandle.WaitAll(vege);
//            Console.WriteLine("Minden sz�l dolgozik.");

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
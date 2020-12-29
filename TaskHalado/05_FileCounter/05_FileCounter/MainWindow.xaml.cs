using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Threading;
using System.Windows.Forms; // Add reference kell ehhez!!!

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Task> tasks = new List<Task>();
        ViewModel VM;        
        CancellationTokenSource CTS;
        TaskScheduler GUIScheduler;
        
        //bool IsClosing = false; //DEADLOCK - a következő órához kell csak!
        public MainWindow()
        {
            InitializeComponent();
            VM = new ViewModel();
            DataContext = VM;
            CTS = new CancellationTokenSource();
            GUIScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           FolderBrowserDialog FD=new FolderBrowserDialog();

            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var T=Task.Run(() =>
                {
                    processPath(FD.SelectedPath, CTS.Token);
                });
                tasks.Add(T);
            }
        }

        #region BusinessLogic osztályba való, ami eseménnyel jelez vissza a window felé
        // Nem igazi MVVM - igazi MVVM-nél eseményekkel kommunikáló osztályok lennének
        int newElem()
        {
            // először legyen itt - kiakad, mert a GUI csak single-thread-access
            // VM.Directories.Add("Loading . . . ");

            int idx = -1;
            Dispatcher.Invoke(() =>
            {
                VM.Directories.Add("Loading . . . ");
                idx = VM.Directories.Count - 1;
            });
            return idx;
        }

        void setElem(int idx, string s)
        {
            // Ugyanúgy lehetne itt is DispatcherInvoke - de inkább taskozunk
            // egyrészt, mert deadlock lehetősége van, ha dispatcher
            // másrészt, hogy lássák a taskos megoldást is
            //Dispatcher.Invoke(() => VM.Directories[idx] = s );

            new Task(() => VM.Directories[idx] = s, CancellationToken.None).Start(GUIScheduler);

            // Így is lehetne
            // Task.Factory.StartNew(() => VM.Directories[idx] = s, CancellationToken.None, TaskCreationOptions.None, GUIScheduler);
        }

        void processPath(string FirstPath, CancellationToken CT)
        {
            int idx = newElem();
            float sumsize = 0;
            int num = -1;
            Queue<string> paths = new Queue<string>();
            paths.Enqueue(FirstPath);
            while (!CT.IsCancellationRequested && paths.Count > 0)
            {
                num++;
                string path = paths.Dequeue();
                if ((File.GetAttributes(path) & FileAttributes.Directory) != 0) //FileAttributes.ReparsePoint - most kihagyjuk
                {
                    try
                    {
                        string[] entries = Directory.GetFileSystemEntries(path);
                        foreach (string subPath in entries) paths.Enqueue(subPath);
                    }
                    catch (SystemException) // UnauthorizedAccessException lehet egyes könyvtáraknál
                    {
                    }
                }
                else
                {
                    sumsize += (float)(new FileInfo(path).Length) / (1024 * 1024);
                }
                setElem(idx, num + " - " + sumsize + " MB - " + path);
            }
            setElem(idx, num + " - " + sumsize + " MB - DONE: " + FirstPath);
        }
        #endregion

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CTS.Cancel();
            Task.WaitAll(tasks.ToArray()); 

            /*
            //DEADLOCK - a következő órán bemutatni !
            //a while() -ban !CT.IsCancellationRequested helyett !IsClosing
            IsClosing = true;
            Task.WaitAll(tasks.ToArray()); 
             */

            /*
            // BÉNA ANTI-deadlock => opcionális?
            if (tasks.Count(akt => !akt.IsCompleted) != 0)
            {
                e.Cancel = true;
                Task.Run(() =>
                {
                    Task.WaitAll(tasks.ToArray());
                    Dispatcher.Invoke(() => Close());
                });
            }*/
        }
    }
}

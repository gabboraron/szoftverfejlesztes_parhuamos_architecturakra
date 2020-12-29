using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace BackgroundWorker
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 10; i <= 100; i += 10)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                // Időigényes részművelet kezdődik...
                Thread.Sleep(1000);
                // ...majd véget ér

                // Ebben a metódusban közvetlenül nem módosíthatjuk a felhasználói felületet
                backgroundWorker.ReportProgress(i); 
            }
            e.Result = 2007;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cancelButton.Enabled = false;
            if (e.Cancelled)
                MessageBox.Show("A művelet megszakadt.");
            else if (e.Error != null)
                MessageBox.Show("A művelet elvégzése közben a következő hiba történt: " + e.Error.Message);
            else
                MessageBox.Show("A művelet sikerült, eredménye: " + e.Result);
            startButton.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            progressBar.Value = 0;
            backgroundWorker.RunWorkerAsync();
            cancelButton.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            cancelButton.Enabled = false;
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
            Close();
        }
    }
}
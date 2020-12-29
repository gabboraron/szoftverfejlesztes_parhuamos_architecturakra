using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ProcessExamples
{
    class Program
    {
        static Process browserProcess;

        static void Main(string[] args)
        {
            // 1. példa: külsõ program közvetlen indítása és bevárása
            Process newProcess = new Process();
            newProcess.StartInfo = new ProcessStartInfo(@"..\..\..\Hello\bin\debug\hello.exe",  "Pistike");
            newProcess.StartInfo.ErrorDialog = true;
            newProcess.StartInfo.UseShellExecute = false;
            newProcess.StartInfo.RedirectStandardOutput = true;
            
            newProcess.Start();
            newProcess.ProcessorAffinity = (IntPtr) 0x00000001;

            newProcess.WaitForExit();

            Console.WriteLine("Az elindított folyamat üzenetei:");
            Console.Write(newProcess.StandardOutput.ReadToEnd());
            Console.ReadLine();

            // 2. példa: külsõ program indítása "dokumentumon" keresztül (a programot indítás után "magára hagyjuk")
            ProcessStartInfo documentStartInfo = new ProcessStartInfo();
            documentStartInfo.FileName = "http://www.google.com/";
            documentStartInfo.ErrorDialog = true;
            
            Process documentProcess = Process.Start(documentStartInfo);
            
            Console.ReadLine();

            // 3. példa: külsõ program indítása és kilépésének észlelése eseménykezelõvel
            ProcessStartInfo browserStartInfo = new ProcessStartInfo();
            browserStartInfo.FileName = "iexplore.exe";
            browserStartInfo.Arguments = "http://www.google.com/";
            browserStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            browserStartInfo.ErrorDialog = true;
            browserProcess = new Process();
            browserProcess.StartInfo = browserStartInfo;
            browserProcess.Exited += new EventHandler(Process_Exit);
            browserProcess.EnableRaisingEvents = true;
            
            browserProcess.Start();

            Console.ReadLine();
            if (!browserProcess.HasExited)
                // browserProcess.Kill();
                browserProcess.CloseMainWindow();
        }

        static void Process_Exit(object sender, EventArgs e)
        {
            Console.WriteLine(String.Format("A böngészõ befejezte futását (kilépési kód: {0}, kilépés idõpontja: {1})", browserProcess.ExitCode, browserProcess.ExitTime));
        }
    }
}

using System;
using System.Diagnostics;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# fordító használata saját programból
            if (args.Length > 0)
            {
                ProcessStartInfo startinfo = new ProcessStartInfo();
                startinfo.FileName = String.Format(@"{0}\..\Microsoft.NET\Framework\v{1}\csc.exe", Environment.GetFolderPath(Environment.SpecialFolder.System), Environment.Version.ToString(3));
                startinfo.Arguments = String.Format(@"/nologo /t:exe {0}", args[0]);
                startinfo.RedirectStandardOutput = true;
                startinfo.UseShellExecute = false;

                Process compilerProcess = Process.Start(startinfo);

                string output = compilerProcess.StandardOutput.ReadToEnd();
                compilerProcess.WaitForExit();

                if (output == String.Empty)
                    Console.WriteLine("A forráskód hibátlan, a fordítás sikerült.");
                else
                    Console.WriteLine("Hibaüzenetek:" + Environment.NewLine + output);
                Console.ReadLine();
            }
        }
    }
}

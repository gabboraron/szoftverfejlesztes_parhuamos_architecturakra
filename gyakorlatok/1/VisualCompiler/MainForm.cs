using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VisualCompiler
{
    public partial class MainForm: Form
    {
        private string compilerExecutablePath = String.Format(@"{0}\..\Microsoft.NET\Framework\v{1}\csc.exe", Environment.GetFolderPath(Environment.SpecialFolder.System), Environment.Version.ToString(3));
        private string sourceFileName = "temp0123";

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadSourceFile()
        {
            sourceCodeEditorBox.LoadFile(Path.GetFileNameWithoutExtension(sourceFileName) + ".cs", RichTextBoxStreamType.PlainText);
        }

        private void SaveSourceFile()
        {
            sourceCodeEditorBox.SaveFile(Path.GetFileNameWithoutExtension(sourceFileName) + ".cs", RichTextBoxStreamType.PlainText);
        }

        private bool Compile()
        {
            SaveSourceFile();
            compilerMessagesBox.Clear();

            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = compilerExecutablePath;
            startinfo.Arguments = String.Format(@"/nologo /t:exe {0}", Path.GetFileNameWithoutExtension(sourceFileName) + ".cs");
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            startinfo.CreateNoWindow = true;
            Process compilerProcess = Process.Start(startinfo);

            string output = compilerProcess.StandardOutput.ReadToEnd();
            compilerProcess.WaitForExit();

            if (output == String.Empty)
            {
                compilerMessagesBox.Text = "Nincs hiba";
                return true;
            }
            else
            {
                compilerMessagesBox.Text = output;
                return false;
            }
        }

        private void Run()
        {
            if (File.Exists(Path.GetFileNameWithoutExtension(sourceFileName) + ".exe"))
                Process.Start(Path.GetFileNameWithoutExtension(sourceFileName) + ".exe");
        }

        private void sourceCodeEditorBox_TextChanged(object sender, EventArgs e)
        {
            saveToolStripButton.Enabled = compileToolStripButton.Enabled = runToolStripButton.Enabled = (sourceCodeEditorBox.Text != string.Empty);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            sourceCodeEditorBox.Clear();
            compilerMessagesBox.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = sourceFileName;
            openFileDialog.Filter = "C# forrásfájlok|*.cs|Minden fájl|*.*";
            openFileDialog.FilterIndex = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFileName = openFileDialog.FileName;
                LoadSourceFile();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = sourceFileName;
            saveFileDialog.Filter = "C# forrásfájlok|*.cs";
            saveFileDialog.DefaultExt = "cs";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFileName = saveFileDialog.FileName;
                SaveSourceFile();
            }
        }

        private void compileToolStripButton_Click(object sender, EventArgs e)
        {
            Compile();
        }

        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            if (Compile())
                Run();
        }

    }
}
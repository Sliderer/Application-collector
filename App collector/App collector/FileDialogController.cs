using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace App_collector
{
    internal class FileDialogController
    {
        internal delegate void DeletedFile();
        internal static event DeletedFile FileDoesNotExist;

        internal static File GetNewFile()
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            File file = RegexController.GetFileInfo(fileDialog);
            return file; 
        }

        internal static void OpenFile(File file)
        {
            string fileToOpen = file.path;
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = fileToOpen
            };

            try
            {
                process.Start();
            }
            catch
            {
                MessageBox.Show("Error");
                FileDoesNotExist.Invoke();
            }

        }
    }
}

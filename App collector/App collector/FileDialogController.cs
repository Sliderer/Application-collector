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
        internal static File GetNewFile()
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            File file = RegexController.GetFileInfo(fileDialog);
            return file; 
        }

        internal static void OpenFile(File file)
        {
            var fileToOpen = file.path;
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = fileToOpen
            };

            process.Start();
        }
    }
}

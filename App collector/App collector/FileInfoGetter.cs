using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace App_collector
{
    internal class FileInfoGetter
    {
        internal File GetNewFile()
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            File file = RegexController.GetFileInfo(fileDialog);
            return file; 
        }
    }
}

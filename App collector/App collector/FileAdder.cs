using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_collector
{
    internal class FileAdder
    {
        internal static void AddFile(File file)
        {
            FilePanel filePanel = new FilePanel();
            filePanel.FileLabel = file.filename + "." + file.type;
            MainWindow.WrapPanel.Children.Add(filePanel);
        }
    }
}

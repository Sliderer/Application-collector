using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_collector
{
    internal class FilesViewer
    {
        internal static void FilterFiles(string type)
        {
            WrapPanel panel = MainWindow.WrapPanel;
            panel.Children.Clear();
            foreach(FilePanel filePanel in FilePanelsContainer.filePanels)
            {
                if (filePanel.FileType == type || type == "all types")
                {
                    FileAdder.AddPanel(filePanel);
                }
            }
        }
    }
}

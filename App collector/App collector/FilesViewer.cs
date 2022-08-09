using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_collector
{
    internal class FilesViewer
    {
        internal static void FilterFiles(ComboBoxItem selectedItem)
        {
            WrapPanel panel = MainWindow.WrapPanel;
            string? type = selectedItem.Content.ToString();

            if (type == null) return;

            panel.Children.Clear();
            foreach(FilePanel filePanel in FilePanelsContainer.filePanels)
            {
                if (filePanel.GetFile.type == type || type == "all types")
                {
                    FileAdder.AddPanel(filePanel);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_collector
{
    internal class FilePanelsContainer
    {
        internal static List<FilePanel> filePanels = new List<FilePanel>();

        internal static void AddFilePanel(FilePanel filePanel)
        {
            filePanels.Add(filePanel);
        }
    }
}

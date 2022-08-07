using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_collector
{
    internal class SavedFilesLoader
    {
        public static void LoadSavedFiles()
        {
            List<File> files = SavedFileController.GetSavedFiles();
            foreach(File file in files)
            {
                FileAdder.AddFile(file);
            }
        }
    }
}

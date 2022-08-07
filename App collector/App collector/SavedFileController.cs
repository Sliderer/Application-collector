using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace App_collector
{
    internal class SavedFileController
    {
        internal static void SaveFile(File file)
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(file);
            System.IO.File.AppendAllText("SavedFiles.txt", data + '\n');
        }

        internal static List<File> GetSavedFiles()
        {
            List<File> savedFiles = new List<File>();
            string[] filesJsons = System.IO.File.ReadAllLines("SavedFiles.txt");
            for(int i =0; i < filesJsons.Length; ++i)
            {
                if (filesJsons[i] == "") continue;
                File? file = Newtonsoft.Json.JsonConvert.DeserializeObject<File>(filesJsons[i]);
                if (file != null)
                {
                    savedFiles.Add(file);
                }
            }
            return savedFiles;
        }
    }
}

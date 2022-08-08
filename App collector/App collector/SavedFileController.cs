using System.Collections.Generic;

namespace App_collector
{
    internal class SavedFileController
    {
        internal static void SaveFile(File file)
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(file);
            System.IO.File.AppendAllText("SavedFiles.txt", data + '\n');
        }

        internal static IEnumerable<File> GetSavedFiles()
        {
            string[] filesJsons = System.IO.File.ReadAllLines("SavedFiles.txt");
            for(int i = 0; i < filesJsons.Length; ++i)
            {
                File? file = null;
                try
                {
                    file = Newtonsoft.Json.JsonConvert.DeserializeObject<File>(filesJsons[i]);
                }
                catch {
                    continue;
                }

                if (file != null)
                {
                    yield return file;
                }
            }
        }
    }
}

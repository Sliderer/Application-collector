using System.Collections.Generic;

namespace App_collector
{
    internal class SavingController
    {
        internal static void SaveFile(File file)
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(file);
            System.IO.File.AppendAllText("SavedFiles.txt", data + '\n');
            SaveFileType(file.type);
        }

        internal static void SaveFileType(string type)
        {
            if (TypesComboBoxController.UpdateTypes(type))
            {
                System.IO.File.AppendAllText("FileTypes.txt", type + '\n');
            }
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

        internal static IEnumerable<string> GetTypes()
        {
            return System.IO.File.ReadLines("FileTypes.txt");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace App_collector
{
    internal class RegexController
    {
        public static File GetFileInfo(FileDialog fileDialog)
        {
            string data = fileDialog.FileName;
            File file = new File();
            file.path = data;

            Match match = new Regex(@"([^\\]+)\.([^.]+)$").Match(data);
            file.type = match.Groups[2].Value;
            file.filename = match.Groups[1].Value;
            return file;
        }
    }
}

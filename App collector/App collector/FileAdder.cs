
using System;
using System.Drawing;
using System.IO;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace App_collector
{
    internal class FileAdder
    {
        private static FileAdder instance;

        internal static bool AddFile(File file)
        {

            if (!Check(file))
            {
                return false;
            }

            FilePanel filePanel = new FilePanel();

            filePanel.FillTextInFilePanel(file);
            filePanel.AddImageInFilePanel(file);

            MainWindow.WrapPanel.Children.Add(filePanel);
            return true;
        }

        private static bool Check(File file)
        {
            return file.path != "";
        }
    }
}

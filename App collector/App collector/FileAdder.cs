
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
        internal static bool AddFile(File file)
        {
            if (!Check(file))
            {
                return false;
            }

            FilePanel filePanel = new FilePanel();

            filePanel.FillPanel(file);

            FilePanelsContainer.AddFilePanel(filePanel);
            AddPanel(filePanel);
            return true;
        }

        internal static void AddPanel(FilePanel filePanel)
        {
            MainWindow.WrapPanel.Children.Add(filePanel);
        }

        private static bool Check(File file)
        {
            return file.path != "" && System.IO.File.Exists(file.path);
        }
    }
}

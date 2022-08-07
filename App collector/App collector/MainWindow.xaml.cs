global using System.Windows;
global using System.Windows.Controls;
global using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace App_collector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;

        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            LoadSavedFiles();
        }

        private void LoadSavedFiles()
        {
            SavedFilesLoader.LoadSavedFiles();
        }

        private void AddApplicationButton_Click(object sender, RoutedEventArgs e)
        {
            FileInfoGetter fileInfoGetter = new FileInfoGetter();
            File file = fileInfoGetter.GetNewFile();
            FileAdder.AddFile(file);
            SavedFileController.SaveFile(file);
        }

        public static WrapPanel WrapPanel
        {
            get
            {
                return instance.FilesWrapPanel;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_collector
{
    /// <summary>
    /// Логика взаимодействия для FilePanel.xaml
    /// </summary>
    public partial class FilePanel : UserControl
    {


        public string FileLabel
        {
            get { return (string)GetValue(FileLabelProperty); }
            set { SetValue(FileLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileLabelProperty =
            DependencyProperty.Register("FileLabel", typeof(string), typeof(FilePanel), new PropertyMetadata(""));



        public File CurrentFile
        {
            get { return (File)GetValue(CurrentFileProperty); }
            set { SetValue(CurrentFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentFileProperty =
            DependencyProperty.Register("CurrentFile", typeof(File), typeof(FilePanel), new PropertyMetadata(null));



        public FilePanel()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void FileBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FileDialogController.OpenFile(CurrentFile);
        }

        internal void FillTextInFilePanel(File file)
        {
            FileLabel = "";
            if (file.filename.Length + file.type.Length + 1 <= 15)
            {
                FileLabel = file.filename + "." + file.type;
            }
            else
            {
                FileLabel = file.filename.Substring(0, Math.Min(20, file.filename.Length)) + "..." + file.type;
                FileBorder.Width = FileBorder.MaxWidth;
            }
            CurrentFile = file;
        }

        internal void AddImageInFilePanel(File file)
        {
            using (Icon ico = Icon.ExtractAssociatedIcon(file.path))
            {
                FileImage.Source = Imaging.CreateBitmapSourceFromHIcon(ico.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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


        public FilePanel()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

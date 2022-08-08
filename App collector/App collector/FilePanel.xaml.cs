using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        private double smallWidth = 100;
        private double bigWidth = 200;
        private double startWidth = 0;
        private double enableAnimationWidth = 300;
        private TimeSpan animationDuration = TimeSpan.FromMilliseconds(300);
        private bool isAnimationPlaying = false;

        private DoubleAnimation nextAnimation;
        private DoubleAnimation MouseEnterAnimation;
        private DoubleAnimation MouseLeaveAnimation;

        private string fileType;

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
            FileDialogController.FileDoesNotExist += DeleteMyself;
            FileDialogController.OpenFile(CurrentFile);
        }

        private void DeleteMyself()
        {
            MainWindow.WrapPanel.Children.Remove(this);
            FilePanelsContainer.DeletePanel(this);
        }

        internal void FillPanel(File file)
        {
            fileType = file.type;
            FillTextInFilePanel(file);
            AddImageInFilePanel(file);
            InitAnimations();
        }

        private void FillTextInFilePanel(File file)
        {
            FileLabel = "";
            if (file.filename.Length + file.type.Length + 1 <= 15)
            {
                FileLabel = file.filename + "." + file.type;
                ChangeBorderWidth(smallWidth);
                startWidth = smallWidth;
            }
            else
            {
                FileLabel = file.filename.Substring(0, Math.Min(20, file.filename.Length)) + "..." + file.type;
                ChangeBorderWidth(bigWidth);
                startWidth = bigWidth;
            }
            CurrentFile = file;
        }
        private void AddImageInFilePanel(File file)
        {
            using (Icon icon = Icon.ExtractAssociatedIcon(file.path))
            {
                FileImage.Source = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
        }

        private void ChangeBorderWidth(double width)
        {
            FileBorder.Width = width;
        }

        private void InitAnimations()
        {
            MouseEnterAnimation = new DoubleAnimation
            {
                From = startWidth,
                To = enableAnimationWidth,
                Duration = animationDuration
            };

            MouseEnterAnimation.Completed += AnimationPlayed;

            MouseLeaveAnimation = new DoubleAnimation
            {
                From = enableAnimationWidth,
                To = startWidth,
                Duration = animationDuration
            };
            MouseLeaveAnimation.Completed += AnimationPlayed;
        }

        private void FileBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            PlayAnimation(MouseEnterAnimation);
        }

        private void FileBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            PlayAnimation(MouseLeaveAnimation);
        }

        private void PlayAnimation(DoubleAnimation animation)
        {
            if (!isAnimationPlaying)
            {
                FileBorder.BeginAnimation(Border.WidthProperty, animation);
                isAnimationPlaying = true;
            }
            else
            {
                nextAnimation = animation;
            }
        }

        private void AnimationPlayed(object sender, EventArgs e)
        {
            isAnimationPlaying = false;
            if (nextAnimation != null)
            {
                PlayAnimation(nextAnimation);
                nextAnimation = null;
            }
        }

        public string FileType
        {
            get
            {
                return fileType;
            }
        }
    }
}

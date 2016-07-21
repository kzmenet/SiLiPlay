using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace SiLiPlay
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        PlayerWindows playwindow = new PlayerWindows();
        public MainWindow()
        {
 
            playwindow.Show();
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            playwindow.Close();

        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "動画ファイル|*.mp4;*.avi;*.wmv|すべてのファイル|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Open";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == true)
            {
                playwindow.open(new Uri(ofd.FileName));
            }

        }

        private void playbutton_Click(object sender, RoutedEventArgs e)
        {
            playwindow.play();

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            playwindow.stop();
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            playwindow.mediaElement.Volume = Volumeslider.Value;
        }

        private void FadeRunButton_Click(object sender, RoutedEventArgs e)
        {
            var animation = new DoubleAnimation();


            animation.From = Volumeslider.Value;
            animation.To = Fadeslider.Value;
            animation.Duration = TimeSpan.FromSeconds(double.Parse(FadetimeBox.Text));
            Storyboard.SetTargetProperty(animation, new PropertyPath("Value"));
            Storyboard.SetTarget(animation, Volumeslider);
            var sb = new Storyboard();
            sb.FillBehavior = FillBehavior.HoldEnd;
            sb.Children.Add(animation);
            sb.Begin();


        }

        private void Volumesetbutton_Click(object sender, RoutedEventArgs e)
        {
            Volumeslider.Value = double.Parse(Volumetext.Text)/100;
        }



        private void Fadesetbutton_Click(object sender, RoutedEventArgs e)
        {
            Fadeslider.Value = double.Parse(Fadetext.Text) / 100;
        }
    }
}

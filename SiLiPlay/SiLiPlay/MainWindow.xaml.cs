using Microsoft.Win32;
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
            InitializeComponent();
            playwindow.Show();
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
            playwindow.mediaElement.Volume = slider1.Value;
        }
    }
}

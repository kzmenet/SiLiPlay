using System;
using System.Windows;

namespace SiLiPlay
{
    /// <summary>
    /// PlayerWindows.xaml の相互作用ロジック
    /// </summary>
    public partial class PlayerWindows : Window
    {


        public PlayerWindows()
        {
            InitializeComponent();
            
        }

        public void open(Uri a)
        {
            mediaElement.Source = a;
            showoneframe();


        }
        public void play()
        {
            mediaElement.Play();
        }
        public void pause()
        {
            mediaElement.Pause();
        }
        public void stop()
        {
            mediaElement.Stop();
            showoneframe();
        }
        private void showoneframe()
        {
            mediaElement.IsMuted = true;
            mediaElement.Position = new TimeSpan(1000);
            mediaElement.Play();
            mediaElement.Pause();
            mediaElement.IsMuted = false;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (pwindow.WindowState == WindowState.Maximized)
            {
                pwindow.WindowState = WindowState.Normal;
            }
            else if (pwindow.WindowState == WindowState.Normal)
            {
                pwindow.WindowState = WindowState.Maximized;
            }else
            {
                pwindow.WindowState = WindowState.Normal;
            }
        }
    }
}

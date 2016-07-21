using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace SiLiPlay
{
    /// <summary>
    /// PlayerWindows.xaml の相互作用ロジック
    /// </summary>
    public partial class PlayerWindows : Window
    {

        private bool Windowsizemediasize = false; 
        public bool windowsizemediasize { get { return Windowsizemediasize; } set { Windowsizemediasize = value; windowsizelock(); } }
        
        

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
            mediaElement.Play();
            mediaElement.Position = new TimeSpan(1000);
            mediaElement.Pause();
            mediaElement.IsMuted = false;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void windowsizelock()
        {
            if (Windowsizemediasize)
            {
                Height = mediaElement.NaturalVideoHeight;
                Width = mediaElement.NaturalVideoWidth;
                ResizeMode = ResizeMode.NoResize;
            }
            else
            {
                ResizeMode = ResizeMode.CanResize;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {/*
            if (Windowsizemediasize)
            {
                if (mediaElement.NaturalVideoWidth != 0)
                {
                    double aspect = (double)Width / (double)mediaElement.NaturalVideoWidth;
                    Height = mediaElement.NaturalVideoHeight * aspect;
                    MessageBox.Show((mediaElement.NaturalVideoHeight * aspect).ToString());
                }
            }

        */}
    }
}
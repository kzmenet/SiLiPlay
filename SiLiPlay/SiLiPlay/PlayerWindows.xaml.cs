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

    }
}

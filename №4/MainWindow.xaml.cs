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

namespace _4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
        }

        private void ChooseFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                mediaElement.Source = new Uri(openFileDialog.FileName);
                mediaElement.Play();
                mediaElement.MediaOpened += (s, args) =>
                {
                    TimeSpan totalTime = mediaElement.NaturalDuration.TimeSpan;
                    totalTimeTextBlock.Text = $"{totalTime.Hours:D2}:{totalTime.Minutes:D2}:{totalTime.Seconds:D2} / {totalTime.Hours:D2}:{totalTime.Minutes:D2}:{totalTime.Seconds:D2}";
                };
                CompositionTarget.Rendering += (s, args) =>
                {
                    if (mediaElement.NaturalDuration.HasTimeSpan)
                    {
                        TimeSpan currentTime = mediaElement.Position;
                        progressBar.Value = currentTime.TotalSeconds / mediaElement.NaturalDuration.TimeSpan.TotalSeconds * 100;
                    }
                };
            }
        }
    }
}

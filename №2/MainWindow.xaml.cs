using System;
using System.Collections.Generic;
using System.IO;
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

namespace _2
{
    public partial class MainWindow : Window
    {
        private string[] imagesPaths;
        private int currentImageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Запрос папки с изображениями у пользователя
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                imagesPaths = openFileDialog.FileNames;
            }

            // Начало слайдшоу
            Dispatcher.Invoke(() => ShowNextImage());
        }

        private void ShowNextImage()
        {
            if (imagesPaths == null || imagesPaths.Length == 0)
            {
                MessageBox.Show("Выберите папку с изображениями!");
                return;
            }

            BitmapImage imageSource = new BitmapImage(new Uri(imagesPaths[currentImageIndex]));
            imageControl.Source = imageSource;

            currentImageIndex++;
            if (currentImageIndex == imagesPaths.Length)
            {
                currentImageIndex = 0;
            }

            // Устанавливаем таймер для показа следующего изображения
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.3);
            timer.Tick += (sender, e) => ShowNextImage();
            timer.Start();
        }
    }
}

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

namespace LabWork42
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
            inkCanvas.DefaultDrawingAttributes.Width = 3;
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));

                inkCanvas.Strokes.Clear();

                inkCanvas.Background = new ImageBrush(bitmapImage);
            }
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)ColorComboBox.SelectedItem;
            inkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(selectedItem.Foreground.ToString());
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            inkCanvas.DefaultDrawingAttributes.Width = (int)SizeSlider.Value;
        }
    }
}

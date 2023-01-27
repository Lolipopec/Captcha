using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Captcha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = 0;
        public MainWindow()
        {
            InitializeComponent();
            CreateImg();
        }
        private void CreateImg()
        {
            Random random = new Random();
            num = random.Next(1000, 9999);
            var pixels = new byte[Convert.ToInt32(CaptchaImage.Width) * Convert.ToInt32(CaptchaImage.Height) * 4];
            random.NextBytes(pixels);
            BitmapSource bitmapSource = BitmapSource.Create(Convert.ToInt32(CaptchaImage.Width), Convert.ToInt32(CaptchaImage.Height), 96, 96, PixelFormats.Bgra32, null, pixels, Convert.ToInt32(CaptchaImage.Width) * 4);
            var visual = new DrawingVisual();
            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawText(
                    new FormattedText(num.ToString(), CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                        new Typeface("Arial"), 100, System.Windows.Media.Brushes.Red), new System.Windows.Point(0, CaptchaImage.Height/2));
                drawingContext.DrawImage(bitmapSource, new Rect(0, 0, 256, 256));
            }
            var image = new DrawingImage(visual.Drawing);
            CaptchaImage.Source = image;
        }
        private void RefButton_Click(object sender, RoutedEventArgs e)
        {
            //CreateImg();
            ModalWindow modalWindow = new ModalWindow("Пароль");
            if (modalWindow.ShowDialog()==true)
            {
                MessageBox.Show("ТРУ");
            }
            else
            {
                MessageBox.Show("Не ТРУ");
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (num == Convert.ToInt32(CheckTextBox.Text))
                {
                    MessageBox.Show("Успешно");
                }
                else
                {
                    MessageBox.Show("Неправильно введен текст с капчи!");
                    Thread.Sleep(10000);
                    CreateImg();
                }
            }
            catch { }
        }
    }
}

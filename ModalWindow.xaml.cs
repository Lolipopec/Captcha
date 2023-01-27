using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Captcha
{
    /// <summary>
    /// Логика взаимодействия для ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        string s;
        public ModalWindow(string s)
        {
            InitializeComponent();
            this.s = s;
        }

        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            if (s == TB.Text)
                this.DialogResult = true;
            else
            {
                Thread.Sleep(10000);
                this.DialogResult = false;
            }
        }
    }
}

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

namespace Binary_calculator_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        int total, randomInt;
        public MainWindow()
        {
            InitializeComponent();
            btnCheck.IsEnabled = false;
        }

        private void HelpButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Help yourself", "Help box");
        }

        private void StartGameButton(object sender, RoutedEventArgs e)
        {
            randomInt = rand.Next(0, 511);
            txtQuestion.Content = "What is " + randomInt + " in binary?";
            txtAnswer.Content = "";
            foreach (var x in mainGrid.Children.OfType<TextBox>())
            {
                x.Text = "0";
            }
            btnCheck.IsEnabled = true;
        }

        private void CheckButton(object sender, RoutedEventArgs e)
        {
            total = 0;
            txtAnswer.Content = "";
            foreach (var x in mainGrid.Children.OfType<TextBox>())
            {
                if (x.Text=="1")
                {
                    total += Convert.ToInt32(x.Tag);
                }
                txtAnswer.Content += x.Text;
            }
            if (total == randomInt)
            {
                btnCheck.IsEnabled = false;
                txtAnswer.Content += " is correct!";
            }
            else
            {
                txtAnswer.Content += " is incorrect";
            }
        }
    }
}

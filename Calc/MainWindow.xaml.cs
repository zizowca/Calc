using System;
using System.Data;
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

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement element in MyCalc.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += ButtonClick;
                }
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "CE")
            {
                textBox.Text = "";
            }
            else if (str == "=")
            {
                string result = new DataTable().Compute(textBox.Text, null).ToString();
                textBox.Text = result;
            }
            else if (str == "x²") // возвести в квадрат
            {
                double x = Convert.ToDouble(textBox.Text);
                string x2 = Math.Pow(x,2).ToString();
                textBox.Text = x2;
            }
            else if (str == "x³") // возвести в куб
            {
                double x = Convert.ToDouble(textBox.Text);
                string x3 = Math.Pow(x, 3).ToString();
                textBox.Text = x3;
            }
            else if (str == "√x") // вычислить корень
            {
                double x = Convert.ToDouble(textBox.Text);
                string y = Math.Sqrt(x).ToString();
                textBox.Text = y;
            }
            else if (str == "sin") // вычислить sin
            {
                double x = Convert.ToDouble(textBox.Text);
                string sin = Math.Sin(x*Math.PI/180).ToString();
                textBox.Text = sin;
            }
            else if (str == "cos") // вычислить cos
            {
                double x = Convert.ToDouble(textBox.Text);
                string cos = Math.Cos(x * Math.PI / 180).ToString();
                textBox.Text = cos;
            }

            else if (str == "%") // вычислить %
            {
                double x = Convert.ToDouble(textBox.Text);
                string proc = (x/100 ).ToString();
                textBox.Text = proc;
            }

            else if (str == "+/-") // сделать отрицательным/положительным
            {
                double x = Convert.ToDouble(textBox.Text);
                string z = (x-2*x).ToString();
                textBox.Text = z;
            }

            else
            {
                textBox.Text += str;
            }
        }
    }
}

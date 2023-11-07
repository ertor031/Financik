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
using System.Windows.Shapes;

namespace Financik
{
    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {
        public string ViewModel { get; set; }
        public Statistic()
        {
            InitializeComponent();
            CategoryComboBox.Items.Add("dsdds");
            CategoryComboBox.Items.Add("dsddsdss");
        }

        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel);
        }
        private async Task Button_Click(object sender, RoutedEventArgs e)
        {
            ///Нужно сделать два метода или один которые будут возвращать - и + нашего кошелька, ну и тут как я понял нкжно сделать модель
            SpendList.AppendText("Test");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

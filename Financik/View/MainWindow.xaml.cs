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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Financik.Models;

namespace Financik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User currentUser;
        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _ = MyTimer();
            this.currentUser = currentUser;
        }

        public async Task MyTimer()
        {
            while (true)
            {
                MyTime.Content = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Statistic taskWindow = new Statistic();
            taskWindow.ViewModel = "ViewModel";
            taskWindow.Show();

        }
    }
}

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
using Financik.Db;
using Financik.Models;

namespace Financik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User currentUser;
        PersonalFinanceDb db;
        Card currentCard;
        public MainWindow(User currentUser, PersonalFinanceDb db)
        {
            InitializeComponent();
            _ = MyTimer();
            this.currentUser = currentUser;
            this.db = db;
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

        private void btnAddStatistic_Click(object sender, RoutedEventArgs e)
        {
            AddFinance addFinanceWindow = new AddFinance(currentCard, currentUser, db);
            addFinanceWindow.Show();
            this.Close();
        }
    }
}

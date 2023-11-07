using Financik.Data;
using Financik.Db;
using Financik.Models;
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

namespace Financik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonalFinanceDbContextFactory _factory = new PersonalFinanceDbContextFactory();
        private PersonalFinanceDb db;
        public User users;
        public string[] args;
        public MainWindow()
        {
            InitializeComponent();
            db = new PersonalFinanceDb(_factory.CreateDbContext(args));
            _ = MyTimer();
        }

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (Checkboxer.IsChecked == true)
        //    {

        //        Authorisation.IsEnabled = true;
        //        Regestration.IsEnabled = true;
        //    }
        //    else
        //    {
        //        Authorisation.IsEnabled = false;
        //        Regestration.IsEnabled = false;
        //    }
        //}

        public async Task MyTimer()
        {
            while (true)
            {
                MyTime.Content = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }

        //private void Authorisation_Click(object sender, RoutedEventArgs e)
        //{

        //    users =  db.GetUserByLoginAndPassword(MyLogin.Text, MyPassword.Password);
       
        //}

        private void Regestration_Click(object sender, RoutedEventArgs e)
        {
            ///Код для регистрации
            //////Есле регистрации успешка то add card enable = true
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Statistic taskWindow = new Statistic();
        //    taskWindow.ViewModel = "ViewModel";
        //    taskWindow.Show();

        //}

        //private async void Regestration_Click_1(object sender, RoutedEventArgs e)
        //{
        //        await db.AddUserAsync(new Models.User { Login = MyLogin.Text, Password = MyPassword.Password });
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}

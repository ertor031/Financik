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
using System.Windows.Shapes;

namespace Financik.View
{
    /// <summary>
    /// Логика взаимодействия для LogReg.xaml
    /// </summary>
    public partial class LogReg : Window
    {
        PersonalFinanceDbContextFactory _factory = new PersonalFinanceDbContextFactory();
        PersonalFinanceDb db;
        string[] args;

        // екземпляр класу, має тільки логін і пароль поточного юзера
        User currentUser;

        public LogReg()
        {
            InitializeComponent();
            db = new PersonalFinanceDb(_factory.CreateDbContext(args));
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Checkboxer.IsChecked == true)
            {

                Authorisation.IsEnabled = true;
                Regestration.IsEnabled = true;
            }
            else
            {
                Authorisation.IsEnabled = false;
                Regestration.IsEnabled = false;
            }
        }

        // реєстрація
        private async void Registration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool exists = true;
                // якщо такого користувача ще немає
                if (db.GetUserByLoginAndPassword(MyLogin_r.Text, MyPassword_r.Password) == null)
                    exists = false;


                await db.AddUser(new User { Login = MyLogin_r.Text, Password = MyPassword_r.Password });


                // якщо такого користувача не було і він додався
                if (!exists && db.GetUserByLoginAndPassword(MyLogin_r.Text,MyPassword_r.Password) != null)
                {
                    currentUser = db.GetUserByLoginAndPassword(MyLogin_r.Text, MyPassword_r.Password);
                    MessageBox.Show("Registrated");
                    await OpenMainWindow();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        // авторизація
        private async void Authorisation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (db.GetUserByLoginAndPassword(MyLogin_a.Text, MyPassword_a.Password) != null)
                {
                    currentUser = db.GetUserByLoginAndPassword(MyLogin_a.Text, MyPassword_a.Password);
                    MessageBox.Show("Authorized");

                    await OpenMainWindow();
                }
                else
                {
                    MessageBox.Show("Login or password is incorrect");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // відкриття наступного вікна
        private async Task OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow(currentUser, db);
            this.Close();
            mainWindow.Show();
        }
    }
}

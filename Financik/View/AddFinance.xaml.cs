using Financik.Db;
using Financik.Models;
using Financik.ViewModels;
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
    /// Логика взаимодействия для AddFinance.xaml
    /// </summary>
    public partial class AddFinance : Window
    {
        Card currentCard;
        User currentUser;
        PersonalFinanceDb _db;
        FinanceViewModel vievModel;
        public AddFinance()
        {
            InitializeComponent();
            vievModel = new FinanceViewModel();
            DataContext = vievModel;
        }

        public AddFinance(Card card, User user, PersonalFinanceDb db)
        {
            InitializeComponent();
            currentCard = card;
            currentUser = user;
            _db = db;
            _ = LoadCard();
            vievModel = new FinanceViewModel();
            DataContext = vievModel;
        }
        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rbCategory.IsChecked == true)
                {
                    DateTime? selectedDateFrom = dpFrom.SelectedDate;
                    DateTime? selectedDateTo = dpTo.SelectedDate;
                    await _db.AddCategory(new Category { Name = tbTitle.Text, CardId = currentCard.Id });
                    await _db.AddCost(new Cost { CardId = currentCard.Id, Count = Decimal.Parse(tbPrice.Text), DayFrom = (DateTime)selectedDateFrom, DayTo = (DateTime)selectedDateTo });
                }
                else if (rbIncomeSource.IsChecked == true)
                {
                    DateTime? selectedDateFrom = dpFrom.SelectedDate;
                    DateTime? selectedDateTo = dpTo.SelectedDate;
                    await _db.AddIncomeSource(new IncomeSource { Name = tbTitle.Text, CardId = currentCard.Id });
                    await _db.AddIncome(new Income { CardId = currentCard.Id, Count = Decimal.Parse(tbPrice.Text), DayFrom = (DateTime)selectedDateFrom, DayTo = (DateTime)selectedDateTo });
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentUser, _db);
            this.Close();
            mainWindow.Show();
        }

        public async Task LoadCard()
        {
            try
            {
                NumCard.Content = currentCard.Number;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

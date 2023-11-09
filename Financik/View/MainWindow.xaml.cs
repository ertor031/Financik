using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        List<Card> currentCardList;
        Card currentCard;


        public MainWindow(User currentUser, PersonalFinanceDb db)
        {
            InitializeComponent();
            _ = MyTimer();
            this.currentUser = currentUser;
            this.db = db;
            _ = CardsLoader();
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
            currentCard = db.GetCardByNumber(Boxer.SelectedItem.ToString());
            Statistic taskWindow = new Statistic(db, currentCard);
            taskWindow.ViewModel = "ViewModel";
            taskWindow.Show();
        }

        private void btnAddStatistic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Boxer.SelectedItem != null)
                {
                    currentCard = db.GetCardByNumber(Boxer.SelectedItem.ToString());
                    AddFinance addFinanceWindow = new AddFinance(currentCard, currentUser, db);
                    addFinanceWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select card", "Card");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            
            Random rnd = new Random();
            Int64 NumberCard = rnd.NextInt64(1000000000000000, 9999999999999999);
            await db.AddCard(new Card { Number = NumberCard.ToString(), Date = DateTime.Now, UserId = currentUser.Id});
            Boxer.Items.Add(NumberCard);
        }

        public async Task CardsLoader()
        {
            try
            {
                currentCardList = db.GetCardsByUserId(currentUser.Id);
                foreach (var cards in currentCardList)
                {
                    Boxer.Items.Add(cards.Number);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

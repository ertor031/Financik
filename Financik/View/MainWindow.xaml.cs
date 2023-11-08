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
        List<Card> currentCardList;
        Card currentCard;


        public MainWindow(User currentUser, PersonalFinanceDb db)
        {
            InitializeComponent();
            _ = MyTimer();
            Boxer.Items.Add("cocl");
            this.currentUser = currentUser;
            this.db = db;
        

        }

        public async Task MyTimer()
        {
            while (true)
            {
               
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
            try
            {
                currentCard = db.GetCardByNumber(Boxer.SelectedItem.ToString());
                AddFinance addFinanceWindow = new AddFinance(currentCard, currentUser, db);
                addFinanceWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select card", "Card");
            }
        }

        private async void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            //MyTasker();
            Random rnd = new Random();
            Int64 NumberCard = rnd.NextInt64(1000000000000000, 9999999999999999);
            await db.AddCard(new Card { Number = NumberCard.ToString(), Date = DateTime.Now, UserId = currentUser.Id});
            Boxer.Items.Add(NumberCard);
        }

        //public void MyTasker()
        //{ 
        //    currentCardList = currentUser.Cards;
            
        //    foreach (var card in currentCardList)
        //    {
        //        Boxer.Items.Add(card.Number);
        //    }
        //}

    }
}

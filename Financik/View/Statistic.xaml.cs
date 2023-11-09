using Financik.Db;
using Financik.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private PersonalFinanceDb _db;
        private Card _card;

        public Statistic(PersonalFinanceDb db, Card card) : this()
        {
            _db = db;
            _card = card;

            var categories = _db.GetCategoriesByCard(card.Number);
            var incomeSources = _db.GetIncomeSourcesByCard(card.Number);

            foreach (var category in categories) CategoryComboBox.Items.Add(category);
            foreach (var incomeSource in incomeSources) IncomeSourceComboBox.Items.Add(incomeSource);
        }
        public Statistic()
        {
            InitializeComponent();
        }

        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IncomeSourceComboBox.SelectedItem != null)
            {
                IncomeSource incomeSource = IncomeSourceComboBox.SelectedItem as IncomeSource;
                IncomeList.ItemsSource = _db.GetIncomesByCard(_card.Number).Where(i => i.IncomeSourceId == incomeSource.Id);
            }
            if (CategoryComboBox.SelectedItem != null)
            {
                Category category = CategoryComboBox.SelectedItem as Category;
                
                SpendList.ItemsSource = _db.GetCostsByCard(_card.Number).Where(c => c.CategoryId == category.Id);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
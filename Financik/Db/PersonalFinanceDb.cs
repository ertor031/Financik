using Financik.Data;
using Financik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Db
{
    internal class PersonalFinanceDb
    {
        private readonly PersonalFinanceDbContext _db;
        public PersonalFinanceDb(PersonalFinanceDbContext db)
        {
            _db = db;
        }

        //For card
        public void AddCard(Card card)
        {
            if (_db.Cards.Any(c => c.Number == card.Number))
            {
                System.Windows.Forms.MessageBox.Show("This card already exists in the database");
            }
            else
            {
                _db.Cards.Add(card);
                _db.SaveChanges();
            }
        }

        public Card? GetCardByNumber(string number)
        {
            try
            {
                var card = _db.Cards.Where(c => c.Number == number).FirstOrDefault();
                return card;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void DeleteCardByNumber(string number)
        {
            var card = _db.Cards.Where(c => c.Number == number).FirstOrDefault();
            if (card != null)
            {
                _db.Cards.Remove(card);
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no card with {number} number");
            }
        }

        public void UpdateCardByNumber(string number, int userId, DateTime date)
        {
            var card = _db.Cards.Where(c => c.Number == number).FirstOrDefault();
            if (card != null)
            {
                card.Date = date;
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no card with {number} number");
            }
        }

        //For category
        public void AddCategory(Category category)
        {
            if (_db.Categories.Any(c => c.Name == category.Name))
            {
                System.Windows.Forms.MessageBox.Show("This category already exists in the database");
            }
        }

        public Category? GetCategoryByName(string name)
        {
            try
            {
                var category = _db.Categories.Where(c => c.Name == name).FirstOrDefault();
                return category;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdateCategoryById(int id, string name)
        {
            var category = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                category.Name = name;
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no category with {id} id");
            }
        }

        public void DeleteCategoryByName(string name)
        {
            var category = _db.Categories.Where(c => c.Name == name).FirstOrDefault();
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no category with {name} name");
            }
        }

        //For cost
        public void AddCost(Cost cost)
        {
            if (_db.Costs.Any(c => c.Card == cost.Card && c.DayFrom == cost.DayFrom && c.DayTo == cost.DayTo))
            {
                System.Windows.Forms.MessageBox.Show("This cost already exists in the database");
            }
            else
            {
                _db.Costs.Add(cost);
                _db.SaveChanges();
            }
        }

        public Cost? GetCostById(int id)
        {
            try
            {
                var cost = _db.Costs.Where(c => c.Id == id).FirstOrDefault();
                return cost;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdateCostById(int id, int count = 0, DateTime dayFrom = default, DateTime dayTo = default)
        {
            var cost = _db.Costs.Where(c => c.Id == id).FirstOrDefault();
            if (cost != null)
            {
                if (count != 0)
                    cost.Count = count;
                if (dayFrom != default)
                    cost.DayFrom = dayFrom;
                if (dayTo != default)
                    cost.DayTo = dayTo;
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no cost with {id} id");
            }
        }

        public void DeleteCostById(int id)
        {
            var cost = _db.Costs.Where(c => c.Id == id).FirstOrDefault();
            if (cost != null)
            {
                _db.Costs.Remove(cost);
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no cost with {id} id");
            }
        }

        //For income
        public void AddIncome(Income income)
        {
            if (_db.Incomes.Any(i => i.Card == income.Card && i.DayFrom == income.DayFrom && i.DayTo == income.DayTo))
            {
                System.Windows.Forms.MessageBox.Show("This income already exists in the database");
            }
            else
            {
                _db.Incomes.Add(income);
                _db.SaveChanges();
            }
        }

        public Income? GetIncomeById(int id)
        {
            try
            {
                var income = _db.Incomes.Where(i => i.Id == id).FirstOrDefault();
                return income;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdateIncomeById(int id, int count = 0, DateTime dayFrom = default, DateTime dayTo = default)
        {
            var income = _db.Incomes.Where(i => i.Id == id).FirstOrDefault();
            if (income != null)
            {
                if (count != 0)
                    income.Count = count;
                if (dayFrom != default)
                    income.DayFrom = dayFrom;
                if (dayTo != default)
                    income.DayTo = dayTo;
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income with {id} id");
            }
        }

        public void DeleteIncomeById(int id)
        {
            var income = _db.Incomes.Where(i => i.Id == id).FirstOrDefault();
            if (income != null)
            {
                _db.Incomes.Remove(income);
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income with {id} id");
            }
        }

        //For income source
        public void AddIncomeSource(IncomeSource incomeSource)
        {
            if (_db.IncomeSources.Any(i => i.Name == incomeSource.Name))
            {
                System.Windows.Forms.MessageBox.Show("This income source already exists in the database");
            }
            else
            {
                _db.IncomeSources.Add(incomeSource);
                _db.SaveChanges();
            }
        }

        public IncomeSource? GetIncomeSourceByName(string name)
        {
            try
            {
                var incomeSource = _db.IncomeSources.Where(i => i.Name == name).FirstOrDefault();
                return incomeSource;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdateIncomeSourceById(int id, string name)
        {
            var incomeSource = _db.IncomeSources.Where(i => i.Id == id).FirstOrDefault();
            if (incomeSource != null)
            {
                incomeSource.Name = name;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income source with {id} id");
            }
        }

        public void DeleteIncomeSourceByName(string name)
        {
            var incomeSource = _db.IncomeSources.Where(i => i.Name == name).FirstOrDefault();
            if (incomeSource != null)
            {
                _db.IncomeSources.Remove(incomeSource);
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income source with {name} name");
            }
        }

        //For user
        public void AddUser(User user)
        {
            if (_db.Users.Any(u => u.Login == user.Login))
            {
                System.Windows.Forms.MessageBox.Show("This user already exists in the database");
            }
            else
            {
                _db.Users.Add(user);
                _db.SaveChanges();
            }
        }

        public User? GetUserByLogin(string login)
        {
            try
            {
                var user = _db.Users.Where(u => u.Login == login).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdateUserById(int id, string login = "", string password = "")
        {
            var user = _db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                if (login != "")
                    user.Login = login;
                if (password != "")
                    user.Password = password;
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no user with {id} id");
            }
        }

        public void DeleteUserByLogin(string login)
        {
            var user = _db.Users.Where(u => u.Login == login).FirstOrDefault();
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no user with {login} login");
            }
        }
    }
}

using Financik.Data;
using Financik.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Db
{
    public class PersonalFinanceDb
    {
        private readonly PersonalFinanceDbContext _db;
        public PersonalFinanceDb(PersonalFinanceDbContext db)
        {
            _db = db;
        }

        //For card
        public async Task AddCard(Card card)
        {
            if (_db.Cards.Any(c => c.Number == card.Number))
            {
                System.Windows.Forms.MessageBox.Show("This card already exists in the database");
            }
            else
            {
                await _db.Cards.AddAsync(card);
                await _db.SaveChangesAsync();
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

        public async Task DeleteCardByNumber(string number)
        {
            var card = _db.Cards.Where(c => c.Number == number).FirstOrDefault();
            if (card != null)
            {
                _db.Cards.Remove(card);
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no card with {number} number");
            }
        }

        public async Task UpdateCardByNumber(string number, int userId, DateTime date)
        {
            var card = _db.Cards.Where(c => c.Number == number).FirstOrDefault();
            if (card != null)
            {
                card.Date = date;
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no card with {number} number");
            }
        }

        //For category
        public async Task AddCategory(Category category)
        {
            if (_db.Categories.Any(c => c.Name == category.Name))
            {
                System.Windows.Forms.MessageBox.Show("This category already exists in the database");
            }
            else
            {
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
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

        public async Task UpdateCategoryById(int id, string name)
        {
            var category = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                category.Name = name;
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no category with {id} id");
            }
        }

        public async Task DeleteCategoryByName(string name)
        {
            var category = _db.Categories.Where(c => c.Name == name).FirstOrDefault();
            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no category with {name} name");
            }
        }

        //For cost
        public async Task AddCost(Cost cost)
        {
            if (_db.Costs.Any(c => c.Card == cost.Card && c.DayFrom == cost.DayFrom && c.DayTo == cost.DayTo))
            {
                System.Windows.Forms.MessageBox.Show("This cost already exists in the database");
            }
            else
            {
                await _db.Costs.AddAsync(cost);
                await _db.SaveChangesAsync();
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

        public async Task UpdateCostById(int id, int count = 0, DateTime dayFrom = default, DateTime dayTo = default)
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
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no cost with {id} id");
            }
        }

        public async Task DeleteCostById(int id)
        {
            var cost = _db.Costs.Where(c => c.Id == id).FirstOrDefault();
            if (cost != null)
            {
                _db.Costs.Remove(cost);
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no cost with {id} id");
            }
        }

        //For income
        public async Task AddIncome(Income income)
        {
            if (_db.Incomes.Any(i => i.Card == income.Card && i.DayFrom == income.DayFrom && i.DayTo == income.DayTo))
            {
                System.Windows.Forms.MessageBox.Show("This income already exists in the database");
            }
            else
            {
                await _db.Incomes.AddAsync(income);
                await _db.SaveChangesAsync();
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

        public async Task UpdateIncomeById(int id, int count = 0, DateTime dayFrom = default, DateTime dayTo = default)
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
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income with {id} id");
            }
        }

        public async Task DeleteIncomeById(int id)
        {
            var income = _db.Incomes.Where(i => i.Id == id).FirstOrDefault();
            if (income != null)
            {
                _db.Incomes.Remove(income);
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income with {id} id");
            }
        }

        //For income source
        public async Task AddIncomeSource(IncomeSource incomeSource)
        {
            if (_db.IncomeSources.Any(i => i.Name == incomeSource.Name))
            {
                System.Windows.Forms.MessageBox.Show("This income source already exists in the database");
            }
            else
            {
                await _db.IncomeSources.AddAsync(incomeSource);
                await _db.SaveChangesAsync();
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

        public async Task UpdateIncomeSourceById(int id, string name)
        {
            var incomeSource = _db.IncomeSources.Where(i => i.Id == id).FirstOrDefault();
            if (incomeSource != null)
            {
                incomeSource.Name = name;
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income source with {id} id");
            }
        }

        public async Task DeleteIncomeSourceByName(string name)
        {
            var incomeSource = _db.IncomeSources.Where(i => i.Name == name).FirstOrDefault();
            if (incomeSource != null)
            {
                _db.IncomeSources.Remove(incomeSource);
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no income source with {name} name");
            }
        }

        //For user
        public async Task AddUser(User user)
        {
            if (await _db.Users.AnyAsync(u => u.Login == user.Login))
            {
                System.Windows.Forms.MessageBox.Show("This user already exists in the database");
            }
            else
            {
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
            }
        }

        public User? GetUserByLoginAndPassword(string login, string password)
        {
            try
            {
                var user = _db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task UpdateUserById(int id, string login = "", string password = "")
        {
            var user = _db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                if (login != "")
                    user.Login = login;
                if (password != "")
                    user.Password = password;
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no user with {id} id");
            }
        }

        public async Task DeleteUserByLogin(string login)
        {
            var user = _db.Users.Where(u => u.Login == login).FirstOrDefault();
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"There is no user with {login} login");
            }
        }
    }
}

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
        public void AddCard(Card card)
        {
            if(_db.Cards.Any(c=>c.Number==card.Number && c.User==card.User))
            {
                System.Windows.Forms.MessageBox.Show("This card already exists in the database");
            }
            else
            {
                _db.Cards.Add(card);
                _db.SaveChanges();
            }
        }

    }
}

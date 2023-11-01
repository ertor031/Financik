using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Models
{
    public class Card
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Number { get; set; } = null!;
        //Дата коли була створена карточка
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Category> Categories { get; set; } = new();
        public List<IncomeSource> IncomeSources { get; set; } = new();
        public List<Cost> Costs { get; set; } = new();
        public List<Income> Incomes { get; set; } = new();
    }
}

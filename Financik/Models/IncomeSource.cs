using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Models
{
    //Джерело доходу
    public class IncomeSource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CardId { get; set; }
        public Card? Card { get; set; }
    }
}

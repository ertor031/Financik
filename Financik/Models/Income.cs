using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Models
{
    public class Income
    {
        public int Id { get; set; }
        //Кількість грошей зароблених за певний період
        [Column(TypeName = "money")]
        public decimal Count { get; set; }
        //Дата з якої починається рахунок доходу
        public DateTime DayFrom { get; set; }
        //Дата до якої ведеться рахунок доходу
        public DateTime DayTo { get; set; }
        public int CardId { get; set; }
        public Card? Card { get; set; }
    }
}

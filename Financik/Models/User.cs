using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Login { get; set; } = null!;
        [MaxLength(100)]
        public string Password { get; set; } = null!;
        public List<Card> Cards { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Account")]
    public class Account
    {
        [Key] public int Id { get; set; }
        public string Description { get; set; }

        // required: account belongs to a card
        public int CardId { get; set; }
        public Card Card { get; set; }

        // required: account has a currency
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}

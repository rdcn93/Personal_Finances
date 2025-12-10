using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Card")]
    public class Card
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public int BankId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public string Number { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CardTypeId { get; set; }

        public decimal CreditLine { get; set; }

        // Navigation
        public Bank Bank { get; set; }
        public Person Owner { get; set; }
        public CardType CardType { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<CardPeriod> CardPeriods { get; set; }
        public ICollection<CardCreditLineHistory> CreditLineHistory { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

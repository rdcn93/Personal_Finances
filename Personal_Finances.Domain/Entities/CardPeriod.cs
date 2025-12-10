using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_CardPeriod")]
    public class CardPeriod
    {
        [Key] public int Id { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime CutoffDate { get; set; }
        public DateTime MinPaymentDate { get; set; }
        public DateTime MaxPaymentDate { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<CardPeriodPayment> Payments { get; set; } = new List<CardPeriodPayment>();
    }
}

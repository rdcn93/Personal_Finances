using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_CardPeriodPayment")]
    public class CardPeriodPayment
    {
        // composite key configured in DbContext
        public int CardPeriodId { get; set; }
        public CardPeriod CardPeriod { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public decimal? Amount { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    }
}

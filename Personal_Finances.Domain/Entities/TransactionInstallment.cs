using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_TransactionInstallment")]
    public class TransactionInstallment
    {
        [Key] public int Id { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public int InstallmentNumber { get; set; }
        public int InstallmentCount { get; set; }
        public int InstallmentsRemaining { get; set; }

        public decimal TEA { get; set; }

        public decimal Amount { get; set; }
        
        public decimal InstallmentAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public decimal Principal { get; set; }

        public decimal Interest { get; set; }

        // periodo de tarjeta (idPeriodoCuota)
        public int? CardPeriodId { get; set; }
        public CardPeriod CardPeriod { get; set; }
    }
}

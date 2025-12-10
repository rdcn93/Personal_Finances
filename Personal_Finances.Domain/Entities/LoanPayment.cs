using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_LoanPayment")]
    public class LoanPayment
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public int? Status { get; set; }
    }
}

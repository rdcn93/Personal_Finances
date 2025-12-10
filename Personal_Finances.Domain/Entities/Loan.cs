using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Loan")]
    public class Loan
    {
        [Key] public int Id { get; set; }

        public DateTime? Date { get; set; }
        public string Description { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int BeneficiaryPersonId { get; set; }
        public Person BeneficiaryPerson { get; set; }

        public int? Status { get; set; }

        public ICollection<LoanDetail> Details { get; set; } = new List<LoanDetail>();
        public ICollection<LoanPayment> Payments { get; set; } = new List<LoanPayment>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Person")]
    public class Person
    {
        [Key] public int Id { get; set; }

        public string FirstName1 { get; set; }
        public string FirstName2 { get; set; }

        public string LastNameFather { get; set; }
        public string LastNameMother { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }

        public string Address { get; set; }

        public ICollection<Card> OwnedCards { get; set; } = new List<Card>();
        public ICollection<Transaction> BeneficiaryTransactions { get; set; } = new List<Transaction>();
        public ICollection<Loan> LoansAsBeneficiary { get; set; } = new List<Loan>();
    }
}

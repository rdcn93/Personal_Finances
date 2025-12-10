using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Transaction")]
    public class Transaction
    {
        [Key] public int Id { get; set; }

        public string Description { get; set; }
        public string OriginalDescription { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        // Installment info
        public bool InInstallments { get; set; }
        public int? InstallmentCount { get; set; }

        // Origin: either Card (credit) or Account (bank). Both nullable.
        public int? CardId { get; set; }
        public Card Card { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        // Currency: required (business rule)
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        // Country (optional)
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        // Category required
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Beneficiary = Person who benefited from the purchase (nullable)
        public int? BeneficiaryPersonId { get; set; }
        public Person BeneficiaryPerson { get; set; }

        // Billing cycle (card period) if applicable
        public int? CardPeriodId { get; set; }
        public CardPeriod CardPeriod { get; set; }

        // Transaction type
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }

        // Status: keep as int or enum later
        public int Status { get; set; }

        // Relationships
        public ICollection<TransactionDetail> Details { get; set; } = new List<TransactionDetail>();
        public ICollection<TransactionInstallment> Installments { get; set; } = new List<TransactionInstallment>();
        public ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();
        public ICollection<LoanPayment> LoanPayments { get; set; } = new List<LoanPayment>();
        public ICollection<CardPeriodPayment> CardPeriodPayments { get; set; } = new List<CardPeriodPayment>();
    }
}

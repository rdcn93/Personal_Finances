using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Personal_Finances.Domain.Common;
using Personal_Finances.Domain.Entities;
using Personal_Finances.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Infrastructure.Persistance
{
    public class FinancesDbContext : IdentityDbContext<ApplicationUser>
    {
        public FinancesDbContext(DbContextOptions<FinancesDbContext> options) : base(options)
        {
        }

        public FinancesDbContext()
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardCreditLineHistory> CardCreditLineHistories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CardPeriod> CardPeriods { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<TransactionInstallment> TransactionInstallments { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<LoanPayment> LoanPayments { get; set; }
        public DbSet<CardPeriodPayment> CardPeriodPayments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------------------
            // Composite Keys
            // ----------------------
            modelBuilder.Entity<LoanDetail>()
                .HasKey(ld => new { ld.LoanId, ld.TransactionId });

            modelBuilder.Entity<LoanPayment>()
                .HasKey(lp => new { lp.LoanId, lp.TransactionId });

            modelBuilder.Entity<CardPeriodPayment>()
                .HasKey(cp => new { cp.CardPeriodId, cp.TransactionId });

            // ----------------------
            // Category Self Reference
            // ----------------------
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // ----------------------
            // Bank -> Country
            // ----------------------
            modelBuilder.Entity<Bank>()
                .HasOne(b => b.Country)
                .WithMany(c => c.Banks)
                .HasForeignKey(b => b.CountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // ----------------------
            // Card Relationships
            // ----------------------
            modelBuilder.Entity<Card>()
                .HasOne(c => c.Bank)
                .WithMany(b => b.Cards)
                .HasForeignKey(c => c.BankId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.CardType)
                .WithMany(ct => ct.Cards)
                .HasForeignKey(c => c.CardTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.Owner)
                .WithMany(p => p.OwnedCards)
                .HasForeignKey(c => c.OwnerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CardCreditLineHistory>()
                .HasOne(h => h.Card)
                .WithMany(c => c.CreditLineHistory)
                .HasForeignKey(h => h.CardId)
                .OnDelete(DeleteBehavior.Cascade);

            // ----------------------
            // Account Relationships
            // ----------------------
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Card)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CardId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Currency)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CurrencyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // ----------------------
            // CardPeriod Relationships
            // ----------------------
            modelBuilder.Entity<CardPeriod>()
                .HasOne(cp => cp.Card)
                .WithMany(c => c.CardPeriods)
                .HasForeignKey(cp => cp.CardId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // ----------------------
            // Transaction Relationships
            // ----------------------
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Card)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Currency)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CurrencyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Country)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.BeneficiaryPerson)
                .WithMany(p => p.BeneficiaryTransactions)
                .HasForeignKey(t => t.BeneficiaryPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.CardPeriod)
                .WithMany(cp => cp.Transactions)
                .HasForeignKey(t => t.CardPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.TransactionType)
                .WithMany(tt => tt.Transactions)
                .HasForeignKey(t => t.TransactionTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.Details)
                .WithOne(d => d.Transaction)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.Installments)
                .WithOne(i => i.Transaction)
                .HasForeignKey(i => i.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // ----------------------
            // Loan Relationships
            // ----------------------
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Account)
                .WithMany(a => a.Loans)
                .HasForeignKey(l => l.AccountId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.BeneficiaryPerson)
                .WithMany()
                .HasForeignKey(l => l.BeneficiaryPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanDetail>()
                .HasOne(ld => ld.Loan)
                .WithMany(l => l.Details)
                .HasForeignKey(ld => ld.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanDetail>()
                .HasOne(ld => ld.Transaction)
                .WithMany(t => t.LoanDetails)
                .HasForeignKey(ld => ld.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanPayment>()
                .HasOne(lp => lp.Loan)
                .WithMany(l => l.Payments)
                .HasForeignKey(lp => lp.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanPayment>()
                .HasOne(lp => lp.Transaction)
                .WithMany(t => t.LoanPayments)
                .HasForeignKey(lp => lp.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // ----------------------
            // CardPeriodPayment Relationships
            // ----------------------
            modelBuilder.Entity<CardPeriodPayment>()
                .HasOne(cp => cp.CardPeriod)
                .WithMany(p => p.Payments)
                .HasForeignKey(cp => cp.CardPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CardPeriodPayment>()
                .HasOne(cp => cp.Transaction)
                .WithMany(t => t.CardPeriodPayments)
                .HasForeignKey(cp => cp.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // ----------------------
            // Precision for Decimal Fields
            // ----------------------
            modelBuilder.Entity<CardPeriodPayment>()
                .Property(t => t.Amount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionDetail>()
                .Property(d => d.Amount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionDetail>()
                .Property(d => d.Total)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionDetail>()
                .Property(d => d.Tax)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionDetail>()
                .Property(d => d.Discount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionInstallment>()
                .Property(i => i.Amount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionInstallment>()
                .Property(i => i.Principal)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionInstallment>()
                .Property(i => i.Interest)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionInstallment>()
                .Property(i => i.TEA)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionInstallment>()
                .Property(i => i.RemainingAmount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TransactionInstallment>()
                .Property(i => i.InstallmentAmount)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Card>()
                .Property(c => c.CreditLine)
                .HasPrecision(18, 3);

            modelBuilder.Entity<CardCreditLineHistory>()
                .Property(c => c.PreviousLine)
                .HasPrecision(18, 3);

            modelBuilder.Entity<CardCreditLineHistory>()
                .Property(c => c.NewLine)
                .HasPrecision(18, 3);
        }
    }
}

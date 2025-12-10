using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal_Finances.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_CardType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Category_tb_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "tb_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameFather = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameMother = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Bank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Bank_tb_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "tb_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardTypeId = table.Column<int>(type: "int", nullable: false),
                    CreditLine = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Card_tb_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "tb_Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Card_tb_CardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "tb_CardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Card_tb_Person_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "tb_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Account_tb_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "tb_Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Account_tb_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "tb_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_CardCreditLineHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PreviousLine = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    NewLine = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CardCreditLineHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_CardCreditLineHistory_tb_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "tb_Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_CardPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CutoffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CardPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_CardPeriod_tb_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "tb_Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryPersonId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Loan_tb_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tb_Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Loan_tb_Person_BeneficiaryPersonId",
                        column: x => x.BeneficiaryPersonId,
                        principalTable: "tb_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Loan_tb_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "tb_Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    InInstallments = table.Column<bool>(type: "bit", nullable: false),
                    InstallmentCount = table.Column<int>(type: "int", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryPersonId = table.Column<int>(type: "int", nullable: true),
                    CardPeriodId = table.Column<int>(type: "int", nullable: true),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tb_Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_CardPeriod_CardPeriodId",
                        column: x => x.CardPeriodId,
                        principalTable: "tb_CardPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "tb_Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tb_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "tb_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "tb_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_Person_BeneficiaryPersonId",
                        column: x => x.BeneficiaryPersonId,
                        principalTable: "tb_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Transaction_tb_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "tb_TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_CardPeriodPayment",
                columns: table => new
                {
                    CardPeriodId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CardPeriodPayment", x => new { x.CardPeriodId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_tb_CardPeriodPayment_tb_CardPeriod_CardPeriodId",
                        column: x => x.CardPeriodId,
                        principalTable: "tb_CardPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_CardPeriodPayment_tb_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "tb_Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_LoanDetail",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_LoanDetail", x => new { x.LoanId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_tb_LoanDetail_tb_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "tb_Loan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_LoanDetail_tb_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "tb_Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_LoanPayment",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_LoanPayment", x => new { x.LoanId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_tb_LoanPayment_tb_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "tb_Loan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_LoanPayment_tb_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "tb_Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_TransactionDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_TransactionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_TransactionDetail_tb_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "tb_Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_TransactionInstallment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    InstallmentNumber = table.Column<int>(type: "int", nullable: false),
                    InstallmentCount = table.Column<int>(type: "int", nullable: false),
                    InstallmentsRemaining = table.Column<int>(type: "int", nullable: false),
                    TEA = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    InstallmentAmount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Principal = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Interest = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    CardPeriodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_TransactionInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_TransactionInstallment_tb_CardPeriod_CardPeriodId",
                        column: x => x.CardPeriodId,
                        principalTable: "tb_CardPeriod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_TransactionInstallment_tb_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "tb_Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Account_CardId",
                table: "tb_Account",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Account_CurrencyId",
                table: "tb_Account",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Bank_CountryId",
                table: "tb_Bank",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Card_BankId",
                table: "tb_Card",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Card_CardTypeId",
                table: "tb_Card",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Card_OwnerId",
                table: "tb_Card",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_CardCreditLineHistory_CardId",
                table: "tb_CardCreditLineHistory",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_CardPeriod_CardId",
                table: "tb_CardPeriod",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_CardPeriodPayment_TransactionId",
                table: "tb_CardPeriodPayment",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Category_ParentCategoryId",
                table: "tb_Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Loan_AccountId",
                table: "tb_Loan",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Loan_BeneficiaryPersonId",
                table: "tb_Loan",
                column: "BeneficiaryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Loan_PersonId",
                table: "tb_Loan",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_LoanDetail_TransactionId",
                table: "tb_LoanDetail",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_LoanPayment_TransactionId",
                table: "tb_LoanPayment",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_AccountId",
                table: "tb_Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_BeneficiaryPersonId",
                table: "tb_Transaction",
                column: "BeneficiaryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_CardId",
                table: "tb_Transaction",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_CardPeriodId",
                table: "tb_Transaction",
                column: "CardPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_CategoryId",
                table: "tb_Transaction",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_CountryId",
                table: "tb_Transaction",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_CurrencyId",
                table: "tb_Transaction",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Transaction_TransactionTypeId",
                table: "tb_Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_TransactionDetail_TransactionId",
                table: "tb_TransactionDetail",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_TransactionInstallment_CardPeriodId",
                table: "tb_TransactionInstallment",
                column: "CardPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_TransactionInstallment_TransactionId",
                table: "tb_TransactionInstallment",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_CardCreditLineHistory");

            migrationBuilder.DropTable(
                name: "tb_CardPeriodPayment");

            migrationBuilder.DropTable(
                name: "tb_LoanDetail");

            migrationBuilder.DropTable(
                name: "tb_LoanPayment");

            migrationBuilder.DropTable(
                name: "tb_TransactionDetail");

            migrationBuilder.DropTable(
                name: "tb_TransactionInstallment");

            migrationBuilder.DropTable(
                name: "tb_Loan");

            migrationBuilder.DropTable(
                name: "tb_Transaction");

            migrationBuilder.DropTable(
                name: "tb_Account");

            migrationBuilder.DropTable(
                name: "tb_CardPeriod");

            migrationBuilder.DropTable(
                name: "tb_Category");

            migrationBuilder.DropTable(
                name: "tb_TransactionType");

            migrationBuilder.DropTable(
                name: "tb_Currency");

            migrationBuilder.DropTable(
                name: "tb_Card");

            migrationBuilder.DropTable(
                name: "tb_Bank");

            migrationBuilder.DropTable(
                name: "tb_CardType");

            migrationBuilder.DropTable(
                name: "tb_Person");

            migrationBuilder.DropTable(
                name: "tb_Country");
        }
    }
}

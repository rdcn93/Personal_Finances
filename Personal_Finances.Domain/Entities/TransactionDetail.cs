using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_TransactionDetail")]
    public class TransactionDetail
    {
        [Key] public int Id { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int? Quantity { get; set; }

        public decimal? Tax { get; set; }

        public decimal? Total { get; set; }

        public decimal? Discount { get; set; }

        public int? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Currency")]
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}

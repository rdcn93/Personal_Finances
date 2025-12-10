using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_TransactionType")]
    public class TransactionType
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

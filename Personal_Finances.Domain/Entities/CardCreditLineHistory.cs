using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_CardCreditLineHistory")]
    public class CardCreditLineHistory
    {
        [Key]
        public int Id { get; set; }

        public int CardId { get; set; }

        public decimal PreviousLine { get; set; }

        public decimal NewLine { get; set; }

        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;

        public string ChangeReason { get; set; } // opcional
        public string ChangedBy { get; set; }    // opcional (si quieres registrar usuario)

        // Navigation
        public Card Card { get; set; }
    }
}

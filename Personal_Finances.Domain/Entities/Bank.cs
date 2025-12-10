using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Bank")]
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int CountryId { get; set; }

        public string Abbreviation { get; set; }

        public Country Country { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}

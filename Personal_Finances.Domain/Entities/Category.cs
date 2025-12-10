using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace Personal_Finances.Domain.Entities
{
    [Table("tb_Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}

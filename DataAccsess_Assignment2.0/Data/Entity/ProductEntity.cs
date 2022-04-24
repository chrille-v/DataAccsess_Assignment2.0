using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccsess_Assignment2._0.Data.Entity
{
    public class ProductEntity
    {
        [Key]
        public int ProductId { get; set; }
        public int ArticleNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public virtual OrderEntity Order { get; set; }
    }
}

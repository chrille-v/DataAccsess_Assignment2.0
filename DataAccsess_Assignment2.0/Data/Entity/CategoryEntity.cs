using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccsess_Assignment2._0.Data.Entity
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { get; set; } = null!;

        [ForeignKey("ProductEntity")]
        public int ProductId { get; set; }

        public ProductEntity Product { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccsess_Assignment2._0.Data.Entity
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerEntity")]
        public int CustomerId { get; set; }

        [ForeignKey("ProductEntity")]
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        [Column(TypeName = "decimal")]

        public decimal OrderQuantity { get; set; }


        public ProductEntity Product { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}

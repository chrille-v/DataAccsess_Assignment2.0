using System.ComponentModel.DataAnnotations;

namespace DataAccsess_Assignment2._0.Data.Entity
{
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        public virtual AddressEntity Address { get; set; }
        public virtual OrderEntity Order { get; set; }
    }
}

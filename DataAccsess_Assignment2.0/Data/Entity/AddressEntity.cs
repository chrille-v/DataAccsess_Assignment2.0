using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccsess_Assignment2._0.Data.Entity
{
    public class AddressEntity
    {
        [Key]
        public int AddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }

        [ForeignKey("StudentId")]
        public int CustomerId { get; set; }
        public virtual CustomerEntity Customer { get; set; }
    }
}

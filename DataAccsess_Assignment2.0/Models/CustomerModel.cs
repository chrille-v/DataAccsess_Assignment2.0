namespace DataAccsess_Assignment2._0.Models
{
    public class CustomerModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public AddressModel Address { get; set; }
    }
}

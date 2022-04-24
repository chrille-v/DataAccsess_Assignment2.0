namespace DataAccsess_Assignment2._0.Models
{
    public class OrderModel
    {
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = null!;
        public decimal OrderQuantity { get; set; }

        public ProductModel Product { get; set; } = null!;
        public CustomerModel Customer { get; set; } = null!;
    }
}

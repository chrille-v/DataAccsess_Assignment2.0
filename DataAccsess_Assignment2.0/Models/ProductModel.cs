namespace DataAccsess_Assignment2._0.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; } = null!;
        public int ArticleNumber { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public CategoryModel Category { get; set; }
    }
}

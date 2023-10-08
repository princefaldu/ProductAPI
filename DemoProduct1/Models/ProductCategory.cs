namespace ProductApplication.Models
{
    public class ProductCategory
    {
        public int ProductId { get; set; }

        public string CategoryName { get; set; }
        public bool ProductStatus { get; set; }
        public string ProductDescription { get; set; }

        public ICollection<Product> Products { get; set; }
        public int Id { get; internal set; }
    }
}

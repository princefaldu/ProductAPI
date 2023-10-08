namespace ProductApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }
    }
}

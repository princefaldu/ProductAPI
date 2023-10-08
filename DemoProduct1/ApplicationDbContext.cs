using ProductApplication.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductApplication
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        internal object SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal void Update(Product product)
        {
            throw new NotImplementedException();
        }

        internal void Update(ProductCategory category)
        {
            throw new NotImplementedException();
        }
    }
}

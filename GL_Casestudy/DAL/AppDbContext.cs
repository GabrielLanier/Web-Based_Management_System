using Microsoft.EntityFrameworkCore;
using GL_Casestudy.DAL.DomainClasses;

namespace GL_Casestudy.DAL 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Product>? Products { get; set; }

        public virtual DbSet<Customer>? Customers { get; set; }
    }
}

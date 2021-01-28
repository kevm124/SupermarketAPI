using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Models;

namespace SupermarketAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p._id);
            builder.Entity<Category>().Property(p => p._id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Products>().ToTable("Products");
            builder.Entity<Products>().HasKey(p => p._id);
            builder.Entity<Products>().Property(p => p._id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Products>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Products>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Products>().Property(p => p.UnitOfMeasurement).IsRequired();
        }
    }
}

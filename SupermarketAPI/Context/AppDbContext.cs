﻿using Microsoft.EntityFrameworkCore;
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

            //to test endpoints later
            builder.Entity<Category>().HasData
            (
                new Category { _id = 100, Name = "Fruits and Vegetables" },
                new Category { _id = 101, Name = "Dairy" }
            );

            builder.Entity<Products>().ToTable("Products");
            builder.Entity<Products>().HasKey(p => p._id);
            builder.Entity<Products>().Property(p => p._id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Products>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Products>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Products>().Property(p => p.UnitOfMeasurement).IsRequired();

            //to test endpoints later
            builder.Entity<Products>().HasData
            (
                new Products
                {
                    _id = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Products
                {
                    _id = 101,
                    Name = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101
                }
            );
        }
    }
}

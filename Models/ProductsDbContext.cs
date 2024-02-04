using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models
{
    public class ProductsDbContext: IdentityDbContext<AppUser, AppRole, int>
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 1, ProductName = "Iphone 13", Price = 50000,IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 2, ProductName = "Iphone 14", Price = 60000,IsActive=false});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 3, ProductName = "Iphone 15", Price = 70000,IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 4, ProductName = "Iphone 16", Price = 80000,IsActive=false});
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId = 5, ProductName = "Iphone 17", Price = 90000,IsActive=true});
        }

        public DbSet<Product> Products {get;set;}
    }
}
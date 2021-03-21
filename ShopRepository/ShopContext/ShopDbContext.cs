using Microsoft.EntityFrameworkCore;
using ShopCore.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace ShopRepository.ShopContext
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<OrderSalesHeader> OrderSalesHeaders { set; get; }

        public DbSet<OrderSalesDetail> OrderSalesDetails { set; get; }

        public DbSet<ProductsDto> Products { set; get; }

        public DbSet<TaxTypes> TaxTypes { set; get; }

        public DbSet<OrderDiscountTypes> OrderDiscountTypes { set; get; }

        public DbSet<UnitOfMeasure> UnitOfMeasure { set; get; }

        public DbSet<Category> Category { set; get; }

    }
}

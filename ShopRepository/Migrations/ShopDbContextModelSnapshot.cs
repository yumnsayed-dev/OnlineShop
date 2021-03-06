// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopRepository.ShopContext;

namespace ShopRepository.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopCore.Entities.Category", b =>
                {
                    b.Property<int>("BaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BaseId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ShopCore.Entities.OrderDiscountTypes", b =>
                {
                    b.Property<int>("BaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPerc")
                        .HasColumnType("int");

                    b.HasKey("BaseId");

                    b.ToTable("OrderDiscountTypes");
                });

            modelBuilder.Entity("ShopCore.Entities.OrderSalesDetail", b =>
                {
                    b.Property<int>("BaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DiscountVal")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProducDiscountPerc")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TaxId")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxVal")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("TotalNetVal")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("TotalVal")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("UomId")
                        .HasColumnType("int");

                    b.HasKey("BaseId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderSalesDetails");
                });

            modelBuilder.Entity("ShopCore.Entities.OrderSalesHeader", b =>
                {
                    b.Property<int>("BaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountVal")
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderNetVal")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("OrderTotalVal")
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StandingOrderStatus")
                        .HasColumnType("bit");

                    b.Property<int>("TaxId")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxVal")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("BaseId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("TaxId");

                    b.ToTable("OrderSalesHeaders");
                });

            modelBuilder.Entity("ShopCore.Entities.Product", b =>
                {
                    b.Property<int>("BaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailablelQuantity")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiscountPerc")
                        .HasColumnType("int");

                    b.Property<string>("ProductImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("UomId")
                        .HasColumnType("int");

                    b.HasKey("BaseId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UomId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopCore.Entities.TaxTypes", b =>
                {
                    b.Property<int>("BaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaxName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxPerc")
                        .HasColumnType("int");

                    b.HasKey("BaseId");

                    b.ToTable("TaxTypes");
                });

            modelBuilder.Entity("ShopCore.Entities.UnitOfMeasure", b =>
                {
                    b.Property<int>("BaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UnitDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BaseId");

                    b.ToTable("UnitOfMeasure");
                });

            modelBuilder.Entity("ShopCore.Entities.OrderSalesDetail", b =>
                {
                    b.HasOne("ShopCore.Entities.OrderSalesHeader", "OrderSalesHeader")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopCore.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderSalesHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopCore.Entities.OrderSalesHeader", b =>
                {
                    b.HasOne("ShopCore.Entities.OrderDiscountTypes", "OrderDiscountTypes")
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopCore.Entities.TaxTypes", "TaxTypes")
                        .WithMany()
                        .HasForeignKey("TaxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderDiscountTypes");

                    b.Navigation("TaxTypes");
                });

            modelBuilder.Entity("ShopCore.Entities.Product", b =>
                {
                    b.HasOne("ShopCore.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopCore.Entities.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("UomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("UnitOfMeasure");
                });
#pragma warning restore 612, 618
        }
    }
}

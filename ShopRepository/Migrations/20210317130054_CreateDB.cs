using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopRepository.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.BaseId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDiscountTypes",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPerc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDiscountTypes", x => x.BaseId);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxPerc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.BaseId);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.BaseId);
                });

            migrationBuilder.CreateTable(
                name: "OrderSalesHeaders",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StandingOrderStatus = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: false),
                    TaxVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    DiscountVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    OrderNetVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    OrderTotalVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSalesHeaders", x => x.BaseId);
                    table.ForeignKey(
                        name: "FK_OrderSalesHeaders_OrderDiscountTypes_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "OrderDiscountTypes",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSalesHeaders_TaxTypes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "TaxTypes",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailablelQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DiscountPerc = table.Column<int>(type: "int", nullable: true),
                    UomId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.BaseId);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_UnitOfMeasure_UomId",
                        column: x => x.UomId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderSalesDetails",
                columns: table => new
                {
                    BaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UomId = table.Column<int>(type: "int", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: false),
                    TaxVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ProducDiscountPerc = table.Column<int>(type: "int", nullable: false),
                    DiscountVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TotalNetVal = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSalesDetails", x => x.BaseId);
                    table.ForeignKey(
                        name: "FK_OrderSalesDetails_OrderSalesHeaders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderSalesHeaders",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSalesDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSalesDetails_OrderId",
                table: "OrderSalesDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSalesDetails_ProductId",
                table: "OrderSalesDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSalesHeaders_DiscountId",
                table: "OrderSalesHeaders",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSalesHeaders_TaxId",
                table: "OrderSalesHeaders",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UomId",
                table: "Products",
                column: "UomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSalesDetails");

            migrationBuilder.DropTable(
                name: "OrderSalesHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderDiscountTypes");

            migrationBuilder.DropTable(
                name: "TaxTypes");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");
        }
    }
}

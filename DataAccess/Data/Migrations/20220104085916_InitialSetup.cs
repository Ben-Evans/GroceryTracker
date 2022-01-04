using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Data.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroceryDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductsMostlyRefrigerated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandStore",
                columns: table => new
                {
                    AvailableBrandsId = table.Column<int>(type: "int", nullable: false),
                    AvailableStoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandStore", x => new { x.AvailableBrandsId, x.AvailableStoresId });
                    table.ForeignKey(
                        name: "FK_BrandStore_Brands_AvailableBrandsId",
                        column: x => x.AvailableBrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandStore_Stores_AvailableStoresId",
                        column: x => x.AvailableStoresId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityToAddWhenDisposed = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Bardcode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    IsRefrigerated = table.Column<bool>(type: "bit", nullable: true),
                    Measurement = table.Column<double>(type: "float", nullable: true),
                    MeasurementTypeId = table.Column<int>(type: "int", nullable: true),
                    GroceryDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_GroceryDepartments_GroceryDepartmentId",
                        column: x => x.GroceryDepartmentId,
                        principalTable: "GroceryDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_MeasurementTypes_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GroceryDepartments",
                columns: new[] { "Id", "Name", "ProductsMostlyRefrigerated" },
                values: new object[,]
                {
                    { 1, "Produce", true },
                    { 2, "Dry Goods", false },
                    { 3, "Beverages", false },
                    { 4, "Baking", false },
                    { 5, "Frozen", true },
                    { 6, "Dairy", true },
                    { 7, "Bakery", false },
                    { 8, "Meat", true },
                    { 9, "Deli", true },
                    { 10, "Seafood", true },
                    { 11, "Household", false },
                    { 12, "Health & Beauty", false },
                    { 13, "Pet", false },
                    { 14, "Alcohol", false },
                    { 15, "Other", false },
                    { 16, "Unknown", false }
                });

            migrationBuilder.InsertData(
                table: "MeasurementTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Item" },
                    { 2, "Teaspoon" },
                    { 3, "Tablespoon" },
                    { 4, "FluidOunce" },
                    { 5, "Cup" },
                    { 6, "Millilitre" },
                    { 7, "Litre" },
                    { 8, "Gallon" },
                    { 9, "Pound" },
                    { 10, "Ounce" },
                    { 11, "Milligram" },
                    { 12, "Gram" },
                    { 13, "Kilogram" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Costco", "https://www.costco.ca/" },
                    { 2, "Super Store", "https://www.realcanadiansuperstore.ca/" },
                    { 3, "Amazon", "https://www.amazon.ca/" },
                    { 4, "Best Buy", "https://www.bestbuy.ca/en-ca" },
                    { 5, "Canadian Tire", "https://www.canadiantire.ca/en.html" },
                    { 6, "Home Depot", "https://www.homedepot.ca/en/home.html" },
                    { 7, "American Eagle", "https://www.ae.com/ca/en" },
                    { 8, "Marks", "https://www.sportchek.ca/" },
                    { 9, "Sport Chek", "https://www.sportchek.ca/" },
                    { 10, "Shoppers Drug Mart", "https://www1.shoppersdrugmart.ca/en/home" },
                    { 11, "Petland", "https://www.petland.ca/" },
                    { 12, "PetSmart", "https://www.petsmart.ca/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandStore_AvailableStoresId",
                table: "BrandStore",
                column: "AvailableStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroceryDepartmentId",
                table: "Products",
                column: "GroceryDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeasurementTypeId",
                table: "Products",
                column: "MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandStore");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "GroceryDepartments");

            migrationBuilder.DropTable(
                name: "MeasurementTypes");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}

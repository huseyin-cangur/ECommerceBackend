using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "This is a sample product description.", "https://example.com/sample-product-1.jpg", true, "Sample Product 1", 19.99m, 100 },
                    { 2, "This is another sample product description.", "https://example.com/sample-product-2.jpg", true, "Sample Product 2", 29.99m, 50 },
                    { 3, "This is yet another sample product description.", "https://example.com/sample-product-3.jpg", true, "Sample Product 3", 9.99m, 200 },
                    { 4, "This is a fourth sample product description.", "https://example.com/sample-product-4.jpg", true, "Sample Product 4", 49.99m, 30 },
                    { 5, "This is a fifth sample product description.", "https://example.com/sample-product-5.jpg", false, "Sample Product 5", 15.99m, 150 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

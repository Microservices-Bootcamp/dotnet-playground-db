using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    /// <inheritdoc />
    public partial class seed_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ef_example_db");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "ef_example_db");

            migrationBuilder.InsertData(
                schema: "ef_example_db",
                table: "Products",
                columns: new[] { "sku", "name", "price" },
                values: new object[] { "PA", "Product A", 100m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ef_example_db",
                table: "Products",
                keyColumn: "sku",
                keyValue: "PA");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "ef_example_db",
                newName: "Products");
        }
    }
}

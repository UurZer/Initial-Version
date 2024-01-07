using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Int.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandCode",
                schema: "Int",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                schema: "Int",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "Int",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Offer",
                schema: "Int",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OfferUnitPrice",
                schema: "Int",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                schema: "Int",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandCode",
                schema: "Int",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandName",
                schema: "Int",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Int",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Offer",
                schema: "Int",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OfferUnitPrice",
                schema: "Int",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "Int",
                table: "Product");
        }
    }
}

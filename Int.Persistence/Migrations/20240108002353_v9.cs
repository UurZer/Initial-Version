using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Int.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                schema: "Int",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "OrderTransaction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                schema: "Int",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "OrderTransaction");
        }
    }
}

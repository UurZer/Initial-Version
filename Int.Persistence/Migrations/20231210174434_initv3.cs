using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Int.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Int");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Int",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                schema: "Int",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelUType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentLabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Label_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Int",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Label_ProductId",
                schema: "Int",
                table: "Label",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "UK_Label_Code",
                schema: "Int",
                table: "Label",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Products_Code",
                schema: "Int",
                table: "Product",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Label",
                schema: "Int");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Int");
        }
    }
}

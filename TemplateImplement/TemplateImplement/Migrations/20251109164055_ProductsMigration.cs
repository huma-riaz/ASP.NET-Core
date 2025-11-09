using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateImplement.Migrations
{
    /// <inheritdoc />
    public partial class ProductsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prod_name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    prod_desc = table.Column<string>(type: "Text", nullable: false),
                    prod_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    prod_stock = table.Column<int>(type: "int", nullable: false),
                    prod_image = table.Column<string>(type: "Varchar(300)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_products", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_products");
        }
    }
}

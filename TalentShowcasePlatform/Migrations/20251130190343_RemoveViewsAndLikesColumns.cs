using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentShowcasePlatform.Migrations
{
    /// <inheritdoc />
    public partial class RemoveViewsAndLikesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Videos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

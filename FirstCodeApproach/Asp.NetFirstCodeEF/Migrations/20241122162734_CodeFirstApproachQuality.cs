using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetFirstCodeEF.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstApproachQuality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quality",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quality",
                table: "products");
        }
    }
}

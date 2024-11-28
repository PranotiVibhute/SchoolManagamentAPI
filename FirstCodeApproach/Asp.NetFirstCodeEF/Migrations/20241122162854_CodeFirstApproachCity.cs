using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetFirstCodeEF.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstApproachCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "City",
               table: "Customers",
                type: "nvarchar(max)",
              nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");
        }
    }
}

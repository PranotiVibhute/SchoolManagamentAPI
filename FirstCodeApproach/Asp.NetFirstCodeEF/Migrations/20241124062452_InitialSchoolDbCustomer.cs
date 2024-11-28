using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetFirstCodeEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchoolDbCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerID");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "Id");
        }
    }
}

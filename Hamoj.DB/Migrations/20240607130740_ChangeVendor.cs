using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hamoj.DB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVendor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact_Phone",
                table: "Vendor");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Vendor",
                newName: "MobileNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "Vendor",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Phone",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

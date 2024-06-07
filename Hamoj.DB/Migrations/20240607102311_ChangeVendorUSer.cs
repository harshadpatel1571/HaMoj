using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hamoj.DB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVendorUSer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VendorUsers_VendorId",
                table: "VendorUsers",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorUsers_Vendor_VendorId",
                table: "VendorUsers",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorUsers_Vendor_VendorId",
                table: "VendorUsers");

            migrationBuilder.DropIndex(
                name: "IX_VendorUsers_VendorId",
                table: "VendorUsers");
        }
    }
}

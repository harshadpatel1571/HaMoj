using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hamoj.DB.Migrations
{
    /// <inheritdoc />
    public partial class VendorUSerIdAddOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_VendorUsers_VendorUserId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_VendorUserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "VendorUserId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "VendorUserId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_VendorUserId",
                table: "Order",
                column: "VendorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_VendorUsers_VendorUserId",
                table: "Order",
                column: "VendorUserId",
                principalTable: "VendorUsers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_VendorUsers_VendorUserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_VendorUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "VendorUserId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "VendorUserId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_VendorUserId",
                table: "OrderDetails",
                column: "VendorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_VendorUsers_VendorUserId",
                table: "OrderDetails",
                column: "VendorUserId",
                principalTable: "VendorUsers",
                principalColumn: "id");
        }
    }
}

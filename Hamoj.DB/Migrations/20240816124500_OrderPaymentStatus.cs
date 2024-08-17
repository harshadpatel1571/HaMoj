using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hamoj.DB.Migrations
{
    /// <inheritdoc />
    public partial class OrderPaymentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderPaymentStatus",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPaymentStatus",
                table: "Order");
        }
    }
}

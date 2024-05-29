using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hamoj.DB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cust_Address",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Cust_City",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Cust_Name",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Order_Status",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Prod_Image",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Prod_Name",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Prod_Price",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Prod_Id",
                table: "OrderDetails",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "Create_Pincode",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "Order",
                newName: "VendorID");

            migrationBuilder.RenameColumn(
                name: "Cust_Id",
                table: "Order",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Order",
                newName: "CustomerId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmounnt",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Gst",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "GrandTotal",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VendorID",
                table: "Order",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Vendor_VendorID",
                table: "Order",
                column: "VendorID",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Vendor_VendorID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_VendorID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalAmounnt",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetails",
                newName: "Prod_Price");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "OrderDetails",
                newName: "Prod_Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetails",
                newName: "Create_Pincode");

            migrationBuilder.RenameColumn(
                name: "VendorID",
                table: "Order",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Order",
                newName: "Cust_Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Order",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Cust_Address",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cust_City",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cust_Name",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Order_Status",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prod_Image",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prod_Name",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Gst",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

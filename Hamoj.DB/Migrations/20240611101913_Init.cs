using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hamoj.DB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office_No = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorProduct",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorProduct", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Gst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Vendor_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_VendorUsers_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VendorUserId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmounnt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Create_by = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_by = table.Column<int>(type: "int", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_VendorUsers_VendorUserId",
                        column: x => x.VendorUserId,
                        principalTable: "VendorUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VendorID",
                table: "Order",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_VendorUserId",
                table: "OrderDetails",
                column: "VendorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorUsers_VendorId",
                table: "VendorUsers",
                column: "VendorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRights");

            migrationBuilder.DropTable(
                name: "VendorProduct");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "VendorUsers");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}

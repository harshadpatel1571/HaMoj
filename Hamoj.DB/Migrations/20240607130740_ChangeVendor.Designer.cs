﻿// <auto-generated />
using System;
using Hamoj.DB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hamoj.DB.Migrations
{
    [DbContext(typeof(HamojDBContext))]
    [Migration("20240607130740_ChangeVendor")]
    partial class ChangeVendor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hamoj.DB.Datamodel.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Office_No")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pincode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Gst")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("VendorID")
                        .HasColumnType("int");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VendorID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmounnt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.UserRights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserRights");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.VendorProduct", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorID"));

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("VendorID");

                    b.ToTable("VendorProduct");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.VendorUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.Property<bool>("is_Delete")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("VendorId");

                    b.ToTable("VendorUsers");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Order", b =>
                {
                    b.HasOne("Hamoj.DB.Datamodel.Customer", "Customer")
                        .WithMany("orderList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hamoj.DB.Datamodel.Vendor", "vendor")
                        .WithMany("orderList")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("vendor");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.OrderDetails", b =>
                {
                    b.HasOne("Hamoj.DB.Datamodel.Order", "order")
                        .WithMany("orderDetailsList")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hamoj.DB.Datamodel.Product", "product")
                        .WithMany("orderDetailsList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Product", b =>
                {
                    b.HasOne("Hamoj.DB.Datamodel.Category", "Category")
                        .WithMany("ProductList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.VendorUser", b =>
                {
                    b.HasOne("Hamoj.DB.Datamodel.Vendor", "vendor")
                        .WithMany("vendorUsers")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("vendor");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Category", b =>
                {
                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Customer", b =>
                {
                    b.Navigation("orderList");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Order", b =>
                {
                    b.Navigation("orderDetailsList");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Product", b =>
                {
                    b.Navigation("orderDetailsList");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Vendor", b =>
                {
                    b.Navigation("orderList");

                    b.Navigation("vendorUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

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
    [Migration("20240517095531_order")]
    partial class order
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("is_Active")
                        .HasColumnType("tinyint");

                    b.Property<byte>("is_Delete")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Amout")
                        .HasColumnType("int");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<int>("Cust_Id")
                        .HasColumnType("int");

                    b.Property<int>("Gst")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<byte>("is_Active")
                        .HasColumnType("tinyint");

                    b.Property<byte>("is_Delete")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Hamoj.DB.Datamodel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<byte>("is_Active")
                        .HasColumnType("tinyint");

                    b.Property<byte>("is_Delete")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

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

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<byte>("is_Active")
                        .HasColumnType("tinyint");

                    b.Property<byte>("is_Delete")
                        .HasColumnType("tinyint");

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

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("is_Active")
                        .HasColumnType("tinyint");

                    b.Property<byte>("is_Delete")
                        .HasColumnType("tinyint");

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

                    b.Property<string>("Contact_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Create_by")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modified_by")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("is_Active")
                        .HasColumnType("tinyint");

                    b.Property<byte>("is_Delete")
                        .HasColumnType("tinyint");

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

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modified_by")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<byte>("is_Active")
                        .HasColumnType("tinyint");

                    b.Property<byte>("is_Delete")
                        .HasColumnType("tinyint");

                    b.HasKey("VendorID");

                    b.ToTable("Vendor_Product");
                });
#pragma warning restore 612, 618
        }
    }
}

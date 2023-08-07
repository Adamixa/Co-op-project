﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityResturantInformation.Models;

namespace UniversityResturantInformation.Migrations
{
    [DbContext(typeof(RestaurantDB))]
    [Migration("20230807070805_databaseUpdateLocal")]
    partial class databaseUpdateLocal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityResturantInformation.Models.Compliant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cal")
                        .HasColumnType("int");

                    b.Property<int>("ItemCode")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.List_Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LId")
                        .HasColumnType("int");

                    b.Property<int>("MId")
                        .HasColumnType("int");

                    b.Property<int?>("listId")
                        .HasColumnType("int");

                    b.Property<int?>("menuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("listId");

                    b.HasIndex("menuId");

                    b.ToTable("List_Menus");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Menu_Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IId")
                        .HasColumnType("int");

                    b.Property<int>("MId")
                        .HasColumnType("int");

                    b.Property<int?>("itemId")
                        .HasColumnType("int");

                    b.Property<int?>("menuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("itemId");

                    b.HasIndex("menuId");

                    b.ToTable("Menu_Items");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("UId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UniId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<int>("LMId")
                        .HasColumnType("int");

                    b.Property<int>("UId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("list_MenuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("list_MenuId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Compliant", b =>
                {
                    b.HasOne("UniversityResturantInformation.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.List_Menu", b =>
                {
                    b.HasOne("UniversityResturantInformation.Models.List", "list")
                        .WithMany()
                        .HasForeignKey("listId");

                    b.HasOne("UniversityResturantInformation.Models.Menu", "menu")
                        .WithMany()
                        .HasForeignKey("menuId");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Menu_Item", b =>
                {
                    b.HasOne("UniversityResturantInformation.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("itemId");

                    b.HasOne("UniversityResturantInformation.Models.Menu", "menu")
                        .WithMany()
                        .HasForeignKey("menuId");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Rating", b =>
                {
                    b.HasOne("UniversityResturantInformation.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("UniversityResturantInformation.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.User", b =>
                {
                    b.HasOne("UniversityResturantInformation.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("UniversityResturantInformation.Models.Vote", b =>
                {
                    b.HasOne("UniversityResturantInformation.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("UniversityResturantInformation.Models.List_Menu", "list_Menu")
                        .WithMany()
                        .HasForeignKey("list_MenuId");
                });
#pragma warning restore 612, 618
        }
    }
}

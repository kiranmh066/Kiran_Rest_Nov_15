﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantDAL;

namespace RestaurantDAL.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RestaurantEntity.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdminEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("tbl_Admin");
                });

            modelBuilder.Entity("RestaurantEntity.AssignWork", b =>
                {
                    b.Property<int>("AssignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("AssignId");

                    b.HasIndex("EmpId");

                    b.HasIndex("OrderId");

                    b.ToTable("tbl_AssignWork");
                });

            modelBuilder.Entity("RestaurantEntity.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("BillStatus")
                        .HasColumnType("bit");

                    b.Property<int>("HallTableId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId1")
                        .HasColumnType("int");

                    b.HasKey("BillId");

                    b.HasIndex("HallTableId");

                    b.HasIndex("OrderId1");

                    b.ToTable("tbl_Bill");
                });

            modelBuilder.Entity("RestaurantEntity.Cook", b =>
                {
                    b.Property<int>("CookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("CookStatus")
                        .HasColumnType("bit");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CookId");

                    b.HasIndex("EmpId");

                    b.HasIndex("FoodId");

                    b.ToTable("tbl_Cook");
                });

            modelBuilder.Entity("RestaurantEntity.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EmpDesignation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EmpPhone")
                        .HasColumnType("float");

                    b.Property<string>("EmpSpeciality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.ToTable("tbl_Employee");
                });

            modelBuilder.Entity("RestaurantEntity.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FeedbackStatus")
                        .HasColumnType("bit");

                    b.Property<int>("HallTableId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("HallTableId");

                    b.ToTable("tbl_Feedback");
                });

            modelBuilder.Entity("RestaurantEntity.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("FoodCost")
                        .HasColumnType("float");

                    b.Property<string>("FoodCuisine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodId");

                    b.ToTable("tbl_Food");
                });

            modelBuilder.Entity("RestaurantEntity.HallTable", b =>
                {
                    b.Property<int>("HallTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HallTableSize")
                        .HasColumnType("int");

                    b.Property<bool>("HallTableStatus")
                        .HasColumnType("bit");

                    b.HasKey("HallTableId");

                    b.ToTable("tbl_HallTable");
                });

            modelBuilder.Entity("RestaurantEntity.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("HallTableId")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("OrderStatus")
                        .HasColumnType("bit");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("FoodId");

                    b.HasIndex("HallTableId");

                    b.HasIndex("Order");

                    b.ToTable("tbl_Order");
                });

            modelBuilder.Entity("RestaurantEntity.AssignWork", b =>
                {
                    b.HasOne("RestaurantEntity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantEntity.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantEntity.Bill", b =>
                {
                    b.HasOne("RestaurantEntity.HallTable", "HallTable")
                        .WithMany()
                        .HasForeignKey("HallTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantEntity.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId1");

                    b.Navigation("HallTable");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantEntity.Cook", b =>
                {
                    b.HasOne("RestaurantEntity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantEntity.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("RestaurantEntity.Feedback", b =>
                {
                    b.HasOne("RestaurantEntity.HallTable", "HallTable")
                        .WithMany()
                        .HasForeignKey("HallTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HallTable");
                });

            modelBuilder.Entity("RestaurantEntity.Order", b =>
                {
                    b.HasOne("RestaurantEntity.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantEntity.HallTable", "HallTable")
                        .WithMany()
                        .HasForeignKey("HallTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantEntity.Bill", null)
                        .WithMany("OrderId")
                        .HasForeignKey("Order");

                    b.Navigation("Food");

                    b.Navigation("HallTable");
                });

            modelBuilder.Entity("RestaurantEntity.Bill", b =>
                {
                    b.Navigation("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}

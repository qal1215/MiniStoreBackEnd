﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniStore.Context;

#nullable disable

namespace MiniStore.Migrations
{
    [DbContext(typeof(MiniStoreContext))]
    [Migration("20230823020353_AddReferent_Workshift")]
    partial class AddReferent_Workshift
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniStore.Models.ApprovalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApprovalStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Approve"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Reject"
                        });
                });

            modelBuilder.Entity("MiniStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Home and Kitchen"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Beauty and Personal Care"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Meat"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Soft drinks"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pork"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Toys"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Fruits"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Vegetables"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Dairy Products"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Meat and Poultry"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Frozen Foods"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Snacks"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Beverages"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Canned Goods"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Personal Care"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Pork"
                        });
                });

            modelBuilder.Entity("MiniStore.Models.CheckinCheckout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckinTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageCheckin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageCheckout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkshiftId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkshiftId")
                        .IsUnique();

                    b.ToTable("CheckinCheckouts");
                });

            modelBuilder.Entity("MiniStore.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("BaseSalaryPerHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MiniStore.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountPrice")
                        .HasColumnType("float");

                    b.Property<string>("SalerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TotalItems")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SalerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MiniStore.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails", t =>
                        {
                            t.HasTrigger("UpdateProductQuantity");
                        });
                });

            modelBuilder.Entity("MiniStore.Models.OrderStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Title = "Processing"
                        },
                        new
                        {
                            StatusId = 2,
                            Title = "Done"
                        });
                });

            modelBuilder.Entity("MiniStore.Models.Payslip", b =>
                {
                    b.Property<string>("PayslipId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("BaseSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BaseSalaryPerHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Bonuses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Deductions")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalWorkHours")
                        .HasColumnType("int");

                    b.Property<int>("TotalWorkLate")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("PayslipId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Payslips");
                });

            modelBuilder.Entity("MiniStore.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Guard"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Saler"
                        });
                });

            modelBuilder.Entity("MiniStore.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("Stock")
                        .HasColumnType("bigint");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = "product11",
                            CategoryId = 1,
                            Description = "Fresh juicy orange",
                            ImageUrl = "orange.jpg",
                            Name = "Orange",
                            Price = 15000m,
                            Stock = 110L,
                            Unit = "pieces"
                        },
                        new
                        {
                            Id = "product12",
                            CategoryId = 1,
                            Description = "Sweet seedless grapes",
                            ImageUrl = "grapes.jpg",
                            Name = "Grapes",
                            Price = 30000m,
                            Stock = 78L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product13",
                            CategoryId = 2,
                            Description = "Greek yogurt",
                            ImageUrl = "yogurt.jpg",
                            Name = "Yogurt",
                            Price = 25000m,
                            Stock = 60L,
                            Unit = "cups"
                        },
                        new
                        {
                            Id = "product14",
                            CategoryId = 2,
                            Description = "French baguette",
                            ImageUrl = "baguette.jpg",
                            Name = "Baguette",
                            Price = 20000m,
                            Stock = 90L,
                            Unit = "pieces"
                        },
                        new
                        {
                            Id = "product15",
                            CategoryId = 3,
                            Description = "Lean ground beef",
                            ImageUrl = "beef.jpg",
                            Name = "Beef",
                            Price = 70000m,
                            Stock = 40L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product16",
                            CategoryId = 3,
                            Description = "Spaghetti pasta",
                            ImageUrl = "pasta.jpg",
                            Name = "Pasta",
                            Price = 30000m,
                            Stock = 120L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product17",
                            CategoryId = 4,
                            Description = "Chocolate chip cookies",
                            ImageUrl = "cookies.jpg",
                            Name = "Cookies",
                            Price = 50000m,
                            Stock = 179L,
                            Unit = "packs"
                        },
                        new
                        {
                            Id = "product18",
                            CategoryId = 4,
                            Description = "Carbonated soft drink",
                            ImageUrl = "soda.jpg",
                            Name = "Soda",
                            Price = 20000m,
                            Stock = 240L,
                            Unit = "cans"
                        },
                        new
                        {
                            Id = "product19",
                            CategoryId = 5,
                            Description = "Mint-flavored toothpaste",
                            ImageUrl = "toothpaste.jpg",
                            Name = "Toothpaste",
                            Price = 5000m,
                            Stock = 100L,
                            Unit = "tubes"
                        },
                        new
                        {
                            Id = "product20",
                            CategoryId = 5,
                            Description = "Hair conditioner",
                            ImageUrl = "conditioner.jpg",
                            Name = "Conditioner",
                            Price = 7000m,
                            Stock = 120L,
                            Unit = "bottles"
                        },
                        new
                        {
                            Id = "product21",
                            CategoryId = 1,
                            Description = "Fresh green lettuce",
                            ImageUrl = "lettuce.jpg",
                            Name = "Lettuce",
                            Price = 8000m,
                            Stock = 90L,
                            Unit = "pieces"
                        },
                        new
                        {
                            Id = "product22",
                            CategoryId = 1,
                            Description = "Sweet blueberries",
                            ImageUrl = "blueberries.jpg",
                            Name = "Blueberries",
                            Price = 45000m,
                            Stock = 60L,
                            Unit = "pints"
                        },
                        new
                        {
                            Id = "product23",
                            CategoryId = 2,
                            Description = "Cheddar cheese",
                            ImageUrl = "cheese.jpg",
                            Name = "Cheese",
                            Price = 55000m,
                            Stock = 50L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product24",
                            CategoryId = 2,
                            Description = "Plain bagels",
                            ImageUrl = "bagels.jpg",
                            Name = "Bagels",
                            Price = 25000m,
                            Stock = 100L,
                            Unit = "pieces"
                        },
                        new
                        {
                            Id = "product25",
                            CategoryId = 3,
                            Description = "Fresh salmon fillet",
                            ImageUrl = "salmon.jpg",
                            Name = "Salmon",
                            Price = 899000m,
                            Stock = 20L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product26",
                            CategoryId = 1,
                            Description = "Sweet tropical pineapple",
                            ImageUrl = "pineapple.jpg",
                            Name = "Pineapple",
                            Price = 30000m,
                            Stock = 70L,
                            Unit = "pieces"
                        },
                        new
                        {
                            Id = "product27",
                            CategoryId = 1,
                            Description = "Juicy red strawberries",
                            ImageUrl = "strawberries.jpg",
                            Name = "Strawberries",
                            Price = 40000m,
                            Stock = 50L,
                            Unit = "pints"
                        },
                        new
                        {
                            Id = "product28",
                            CategoryId = 2,
                            Description = "Fresh cow milk",
                            ImageUrl = "milk.jpg",
                            Name = "Milk",
                            Price = 20000m,
                            Stock = 30L,
                            Unit = "liters"
                        },
                        new
                        {
                            Id = "product29",
                            CategoryId = 2,
                            Description = "Farm-fresh eggs",
                            ImageUrl = "eggs.jpg",
                            Name = "Eggs",
                            Price = 15000m,
                            Stock = 100L,
                            Unit = "dozens"
                        },
                        new
                        {
                            Id = "product30",
                            CategoryId = 3,
                            Description = "Lean pork chops",
                            ImageUrl = "pork.jpg",
                            Name = "Pork",
                            Price = 55000m,
                            Stock = 35L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product31",
                            CategoryId = 1,
                            Description = "Fresh orange carrots",
                            ImageUrl = "carrots.jpg",
                            Name = "Carrots",
                            Price = 12000m,
                            Stock = 90L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product32",
                            CategoryId = 1,
                            Description = "Vine-ripened tomatoes",
                            ImageUrl = "tomatoes.jpg",
                            Name = "Tomatoes",
                            Price = 18000m,
                            Stock = 70L,
                            Unit = "pounds"
                        },
                        new
                        {
                            Id = "product33",
                            CategoryId = 2,
                            Description = "Creamy butter",
                            ImageUrl = "butter.jpg",
                            Name = "Butter",
                            Price = 28000m,
                            Stock = 40L,
                            Unit = "blocks"
                        },
                        new
                        {
                            Id = "product34",
                            CategoryId = 4,
                            Description = "Fruit juice",
                            ImageUrl = "juice.jpg",
                            Name = "Juice",
                            Price = 25000m,
                            Stock = 60L,
                            Unit = "bottles"
                        },
                        new
                        {
                            Id = "product35",
                            CategoryId = 5,
                            Description = "Hair shampoo",
                            ImageUrl = "shampoo.jpg",
                            Name = "Shampoo",
                            Price = 8500m,
                            Stock = 100L,
                            Unit = "bottles"
                        });
                });

            modelBuilder.Entity("MiniStore.Models.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ActualEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpectedEndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RemainingProducts")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("MiniStore.Models.Workshift", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ApprovalStatusId")
                        .HasColumnType("int");

                    b.Property<int>("CheckinCheckoutId")
                        .HasColumnType("int");

                    b.Property<decimal>("CoefficientsSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsHoliday")
                        .HasColumnType("bit");

                    b.Property<string>("PayslipId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkshiftTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalStatusId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PayslipId");

                    b.HasIndex("WorkshiftTypeId");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("MiniStore.Models.WorkshiftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("WorkshiftsType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "saler-shift-1",
                            PositionId = 3
                        },
                        new
                        {
                            Id = 2,
                            Name = "saler-shift-2",
                            PositionId = 3
                        },
                        new
                        {
                            Id = 3,
                            Name = "saler-shift-3",
                            PositionId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "guard-shift-1",
                            PositionId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "guard-shift-2",
                            PositionId = 2
                        });
                });

            modelBuilder.Entity("MiniStore.Models.CheckinCheckout", b =>
                {
                    b.HasOne("MiniStore.Models.Workshift", "Workshift")
                        .WithOne("CheckinCheckout")
                        .HasForeignKey("MiniStore.Models.CheckinCheckout", "WorkshiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshift");
                });

            modelBuilder.Entity("MiniStore.Models.Employee", b =>
                {
                    b.HasOne("MiniStore.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("MiniStore.Models.Order", b =>
                {
                    b.HasOne("MiniStore.Models.Employee", "Saler")
                        .WithMany()
                        .HasForeignKey("SalerId");

                    b.HasOne("MiniStore.Models.OrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Saler");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MiniStore.Models.OrderDetail", b =>
                {
                    b.HasOne("MiniStore.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiniStore.Models.Payslip", b =>
                {
                    b.HasOne("MiniStore.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MiniStore.Models.Product", b =>
                {
                    b.HasOne("MiniStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MiniStore.Models.Voucher", b =>
                {
                    b.HasOne("MiniStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MiniStore.Models.Workshift", b =>
                {
                    b.HasOne("MiniStore.Models.ApprovalStatus", "ApprovalStatus")
                        .WithMany()
                        .HasForeignKey("ApprovalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniStore.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniStore.Models.Payslip", null)
                        .WithMany("WorkShifts")
                        .HasForeignKey("PayslipId");

                    b.HasOne("MiniStore.Models.WorkshiftType", "WorkshiftType")
                        .WithMany()
                        .HasForeignKey("WorkshiftTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovalStatus");

                    b.Navigation("Employee");

                    b.Navigation("WorkshiftType");
                });

            modelBuilder.Entity("MiniStore.Models.WorkshiftType", b =>
                {
                    b.HasOne("MiniStore.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("MiniStore.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MiniStore.Models.Payslip", b =>
                {
                    b.Navigation("WorkShifts");
                });

            modelBuilder.Entity("MiniStore.Models.Workshift", b =>
                {
                    b.Navigation("CheckinCheckout");
                });
#pragma warning restore 612, 618
        }
    }
}

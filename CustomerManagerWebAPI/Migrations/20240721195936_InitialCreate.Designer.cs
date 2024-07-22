﻿// <auto-generated />
using System;
using CustomerManagerWebApiByAlp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerManagerWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240721195936_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerManagerWebApiByAlp.Models.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Up to 50% off on all items",
                            EndDate = new DateTime(2024, 8, 10, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7250),
                            Name = "Winter Sale",
                            StartDate = new DateTime(2024, 7, 11, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7217)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Buy one, get one free",
                            EndDate = new DateTime(2024, 8, 30, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7253),
                            Name = "Spring Sale",
                            StartDate = new DateTime(2024, 7, 31, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7252)
                        });
                });

            modelBuilder.Entity("CustomerManagerWebApiByAlp.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            DateOfBirth = new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith"
                        });
                });

            modelBuilder.Entity("CustomerManagerWebApiByAlp.Models.LoyaltyProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Benefits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("LoyaltyPrograms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Benefits = "Free shipping, exclusive discounts",
                            CustomerId = 1,
                            EnrollmentDate = new DateTime(2024, 1, 21, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7302),
                            ProgramName = "Gold Member"
                        },
                        new
                        {
                            Id = 2,
                            Benefits = "Exclusive discounts",
                            CustomerId = 2,
                            EnrollmentDate = new DateTime(2024, 4, 21, 22, 59, 35, 671, DateTimeKind.Local).AddTicks(7315),
                            ProgramName = "Silver Member"
                        });
                });

            modelBuilder.Entity("CustomerManagerWebApiByAlp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            FirstName = "Admin",
                            LastName = "User",
                            Password = "password123",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@example.com",
                            FirstName = "Regular",
                            LastName = "User",
                            Password = "password123",
                            Role = "User",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("CustomerManagerWebApiByAlp.Models.LoyaltyProgram", b =>
                {
                    b.HasOne("CustomerManagerWebApiByAlp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}

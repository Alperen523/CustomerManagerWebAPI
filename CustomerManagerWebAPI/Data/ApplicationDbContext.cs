using Microsoft.EntityFrameworkCore;
using CustomerManagerWebApiByAlp.Models;
using System;

namespace CustomerManagerWebApiByAlp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com", DateOfBirth = new DateTime(1980, 1, 1), Address = "123 Main St" },
                new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", DateOfBirth = new DateTime(1990, 2, 2), Address = "456 Elm St" }
            );

            modelBuilder.Entity<Campaign>().HasData(
                new Campaign { Id = 1, Name = "Winter Sale", Description = "Up to 50% off on all items", StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(20) },
                new Campaign { Id = 2, Name = "Spring Sale", Description = "Buy one, get one free", StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(40) }
            );

            modelBuilder.Entity<LoyaltyProgram>().HasData(
                new LoyaltyProgram { Id = 1, ProgramName = "Gold Member", Benefits = "Free shipping, exclusive discounts", EnrollmentDate = DateTime.Now.AddMonths(-6), CustomerId = 1 },
                new LoyaltyProgram { Id = 2, ProgramName = "Silver Member", Benefits = "Exclusive discounts", EnrollmentDate = DateTime.Now.AddMonths(-3), CustomerId = 2 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "password123", Email = "admin@example.com", Role = "admin", FirstName = "Admin", LastName = "User" },
                new User { Id = 2, Username = "user", Password = "password123", Email = "user@example.com", Role = "User", FirstName = "Regular", LastName = "User" }
            );
        }
    }
}

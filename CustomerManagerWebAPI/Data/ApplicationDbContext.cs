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
        public DbSet<Email> Emails { get; set; }
        public DbSet<MobilePhone> MobilePhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1), Address = "123 Main St" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1990, 2, 2), Address = "456 Elm St" }
            );

            // Seed data for Campaigns
            modelBuilder.Entity<Campaign>().HasData(
                new Campaign { Id = 1, Name = "Winter Sale", Description = "Up to 50% off on all items", StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(20) },
                new Campaign { Id = 2, Name = "Spring Sale", Description = "Buy one, get one free", StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(40) }
            );

            // Seed data for LoyaltyPrograms
            modelBuilder.Entity<LoyaltyProgram>().HasData(
                new LoyaltyProgram { Id = 1, ProgramName = "Gold Member", Benefits = "Free shipping, exclusive discounts", EnrollmentDate = DateTime.Now.AddMonths(-6), CustomerId = 1 },
                new LoyaltyProgram { Id = 2, ProgramName = "Silver Member", Benefits = "Exclusive discounts", EnrollmentDate = DateTime.Now.AddMonths(-3), CustomerId = 2 }
            );

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "password123", Email = "admin@example.com", Role = "admin", FirstName = "Admin", LastName = "User" },
                new User { Id = 2, Username = "user", Password = "password123", Email = "user@example.com", Role = "User", FirstName = "Regular", LastName = "User" }
            );

            // Seed data for Emails
            modelBuilder.Entity<Email>().HasData(
                new Email { Id = 1, EmailAddress = "email1@example.com", CustomerId = 1 },
                new Email { Id = 2, EmailAddress = "email2@example.com", CustomerId = 2 },
                new Email { Id = 3, EmailAddress = "email3@example.com", CustomerId = 1 }
            );

            // Seed data for MobilePhones
            modelBuilder.Entity<MobilePhone>().HasData(
                new MobilePhone { Id = 1, PhoneNumber = "123-456-7890", CustomerId = 1 },
                new MobilePhone { Id = 2, PhoneNumber = "987-654-3210", CustomerId = 2 },
                new MobilePhone { Id = 3, PhoneNumber = "555-555-5555", CustomerId = 1 }
            );

            // Customer - Email relationship
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Emails)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            // Customer - MobilePhone relationship
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.MobilePhones)
                .WithOne(m => m.Customer)
                .HasForeignKey(m => m.CustomerId);
        }
    }
}

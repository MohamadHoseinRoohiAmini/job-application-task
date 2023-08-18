using Mc2.CrudTest.Domain.Customer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mc2.CrudTest.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);

            modelBuilder.Entity<Customer>()
                    .HasKey(x => x.Id);            

            modelBuilder.Entity<Customer>().HasIndex(p => new { p.FirstName, p.LastName, p.DateOfBirth }).IsUnique();
        }

        public DbSet<Customer> Customer { get; set; }
    }
}

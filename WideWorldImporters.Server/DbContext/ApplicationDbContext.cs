using Microsoft.EntityFrameworkCore;
using System;
using WideWorldImporters.Server.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet declarations
    public DbSet<Country> Countries { get; set; }
    //public DbSet<City> Cities { get; set; }
    //public DbSet<StateProvince> StateProvinces { get; set; }
    //public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Use schema "Application"
        modelBuilder.Entity<Country>().ToTable("Countries", "Application");
        //modelBuilder.Entity<City>().ToTable("Cities", "Application");
        //modelBuilder.Entity<StateProvince>().ToTable("StateProvinces", "Application");
        //modelBuilder.Entity<Person>().ToTable("People", "Application");

        // Optionally configure primary keys or relationships here
    }
}

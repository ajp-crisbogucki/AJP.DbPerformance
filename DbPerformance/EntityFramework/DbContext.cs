using DbPerformance.Models;
using DbPerformance.Services;
using Microsoft.EntityFrameworkCore;

namespace DbPerformance.EntityFramework;

public class EfDbContext : DbContext
{
    
    public DbSet<RowModel> Kody { get; set; }  
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbServices.connconnString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RowModel>(builder =>
        {
            builder.HasKey(x => new { x.Adres, x.Miejscowosc, x.Powiat, x.Wojewodztwo, x.KodPocztowy });
            builder.ToTable("KODY");
        });
    }
}  
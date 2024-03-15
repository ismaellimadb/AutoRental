using AutoRental.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Manufacturer> Manufacturer { get; set; }
	public DbSet<Auto> Auto { get; set; }
	public DbSet<Year> Year { get; set; }
}

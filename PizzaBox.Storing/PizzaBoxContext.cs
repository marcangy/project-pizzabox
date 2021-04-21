using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<AStore> Stores { get; set; } //Implicit Serialization
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Size> Sizes { get; set; }

    private readonly IConfiguration _configuration;


    public PizzaBoxContext()
    {

      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)

    {
      builder.UseSqlServer(_configuration["msql"]);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityID);
      builder.Entity<APizza>().HasKey(e => e.EntityID);
      builder.Entity<Topping>().HasKey(e => e.EntityID);
      builder.Entity<Crust>().HasKey(e => e.EntityID);
      builder.Entity<Size>().HasKey(e => e.EntityID);
    }
  }
}
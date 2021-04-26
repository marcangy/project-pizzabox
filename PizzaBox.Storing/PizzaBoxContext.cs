using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
namespace PizzaBox.Storing.Repositories
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<AStore> Stores { get; set; } //Implicit Serialization
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<ACustomer> Customers { get; set; }
    public DbSet<AOrder> Orders { get; set; }
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
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();
      builder.Entity<AStore>().HasMany<AOrder>(s => s.Orders).WithOne(o => o.Store);



      builder.Entity<AOrder>().HasKey(e => e.EntityID);
      builder.Entity<RegOrder>().HasBaseType<AOrder>();
      builder.Entity<AOrder>().HasMany<APizza>(o => o.Pizzas).WithOne();

      builder.Entity<ACustomer>().HasKey(e => e.EntityID);
      builder.Entity<ACustomer>().HasMany<AOrder>().WithOne();

      builder.Entity<APizza>().HasKey(e => e.EntityID);
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatLoversPizza>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();
      builder.Entity<CheesePizza>().HasBaseType<APizza>();


      builder.Entity<Topping>().HasKey(e => e.EntityID);
      builder.Entity<Topping>().HasMany<APizza>();
      builder.Entity<APizza>().HasMany<Topping>();


      builder.Entity<Crust>().HasKey(e => e.EntityID);
      builder.Entity<Crust>().HasMany<APizza>().WithOne(p => p.Crust);

      builder.Entity<Size>().HasKey(e => e.EntityID);
      builder.Entity<Size>().HasMany<APizza>().WithOne(p => p.Size);
      OnDataSeeding(builder);

    }
    private void OnDataSeeding(ModelBuilder builder)
    {

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[] { new NewYorkStore() { Name = "Da Best NY Pizza", EntityID = 1 } });
      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[] { new ChicagoStore() { Name = "Chitown Pizzeria", EntityID = 2 } });


      builder.Entity<RegCustomer>().HasData(new RegCustomer[] { new RegCustomer() { Name = "Samual Adams", EntityID = 1 } });
    }
  }
}
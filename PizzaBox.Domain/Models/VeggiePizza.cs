using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class VeggiePizza : APizza
  {
    protected override void AddCrust()
    {
      Crust = new Crust() { Name = "Original" };
    }

    protected override void AddSize()
    {
      Size = new Size() { Name = "Large", Price = 11.5 };
    }

    protected override void AddToppings()
    {
      Toppings = new List<Topping> { new Topping() { Name = "Spinach" }, new Topping() { Name = "Mushroom" }, new Topping() { Name = "Olives" }, new Topping() { Name = "Cheese" }, new Topping() { Name = "Sauce" } };

    }

    public VeggiePizza()
    {
      Name = "Veggie Pizza";
      Factory();
    }
  }
}
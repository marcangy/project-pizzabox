using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class CheesePizza : APizza
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
      Toppings = new List<Topping> { new Topping() { Name = "Cheese" }, new Topping() { Name = "Cheese" }, new Topping() { Name = "Cheese" }, new Topping() { Name = "Cheese" }, new Topping() { Name = "Sauce" } };

    }




    public CheesePizza()
    {
      Name = "Cheese Pizza";
      Factory();

    }
  }
}
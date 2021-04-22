using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class CheesePizza : APizza
  {

    public override void AddCrust()
    {
      Crust = new Crust() { Name = "Original" };
    }

    public override void AddSize()
    {
      Size = new Size() { Name = "Large", Price = 11.5 };
    }

    public override void AddToppings()
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
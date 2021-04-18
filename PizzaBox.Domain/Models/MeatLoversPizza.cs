using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class MeatLoversPizza : APizza
  {

    protected override void AddCrust()
    {
      Crust = new Crust() { Name = "Original" };
    }

    protected override void AddSize()
    {
      Size = new Size() { Name = "Large" };
    }

    protected override void AddToppings()
    {
      Toppings = new List<Topping> { new Topping() { Name = "Pepperoni" }, new Topping() { Name = "Bacon" }, new Topping() { Name = "Beef" }, new Topping() { Name = "Cheese" }, new Topping() { Name = "Sauce" } };
    }


    public MeatLoversPizza()
    {
      Name = "Meat Lover's Pizza";
      Factory();
    }

  }
}
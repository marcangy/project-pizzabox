using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
  {

    public override void AddCrust()
    {
      Crust = new Crust() { Name = "Original" };
    }

    public override void AddSize()
    {
      Size = new Size() { Name = "Large" };
    }

    public override void AddToppings()
    {
      Toppings = new List<Topping> { new Topping() { Name = "Cheese" }, new Topping() { Name = "Sauce" } };
    }
    public CustomPizza()
    {
      Name = "Custom Pizza";
      Factory();

    }


  }
}
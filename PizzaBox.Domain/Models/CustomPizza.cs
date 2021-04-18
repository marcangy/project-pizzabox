using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
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
      Toppings = new List<Topping> { new Topping() { Name = "Cheese" }, new Topping() { Name = "Sauce" } };
    }
    public CustomPizza()
    {
      Name = "Custom Pizza";
      Factory();

    }


  }
}
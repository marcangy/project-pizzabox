using System.Collections.Generic;
using PizzaBox.Domain.Models;
using System.Xml.Serialization;
namespace PizzaBox.Domain.Abstracts
{

  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatLoversPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  [XmlInclude(typeof(CheesePizza))]

  public abstract class APizza
  {
    public string Name { get; set; }
    public List<Topping> Toppings { get; set; }
    public Size Size { get; set; }
    public Crust Crust { get; set; }
    public double TotalPrice { get; set; }


    protected virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
      CalculatePrice();
    }

    protected abstract void AddCrust();

    protected abstract void AddSize();

    protected abstract void AddToppings();

    protected virtual double CalculatePrice()
    {
      var totalToppingPrice = new double();
      //var x = new int();
      foreach (var item in Toppings)
      {
        totalToppingPrice += item.Price;
      }
      TotalPrice = Crust.Price + Size.Price + totalToppingPrice;
      return TotalPrice;

    }


  }
}
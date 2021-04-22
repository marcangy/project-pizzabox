using System.Collections.Generic;
using PizzaBox.Domain.Models;
using System.Xml.Serialization;
namespace PizzaBox.Domain.Abstracts
{

  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatLoversPizza))]
  [XmlInclude(typeof(VeggiePizza))]
  [XmlInclude(typeof(CheesePizza))]

  public abstract class APizza : AModel
  {
    public string Name { get; set; }
    public List<Topping> Toppings { get; set; }
    public Size Size { get; set; }
    public Crust Crust { get; set; }
    public double TotalPrice { get; set; }

    public APizza()
    {
      Factory();
    }
    public virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
      CalculatePrice();
    }

    public abstract void AddCrust();

    public abstract void AddSize();

    public abstract void AddToppings();

    public virtual double CalculatePrice()
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
using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;


namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(RegCustomer))]
  public abstract class AOrder : AModel
  {
    public int ID { get; set; }
    public AStore Store { get; set; }
    public ACustomer Customer { get; set; }
    public List<APizza> Pizzas { get; set; }


    public double TotalCost
    {
      get
      {

        var TotalPrice = new double();
        foreach (var item in Pizzas)
        {
          TotalPrice += item.TotalPrice;
        }
        return TotalPrice;


      }
    }


  }
}
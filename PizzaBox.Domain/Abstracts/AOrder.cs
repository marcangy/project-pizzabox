using System.Collections.Generic;
using PizzaBox.Domain.Models;


namespace PizzaBox.Domain.Abstracts
{
  public abstract class AOrder : AModel
  {
    public int ID { get; set; }
    public AStore Store { get; set; }
    public RegCustomer Customer { get; set; }
    public List<APizza> Pizzas { get; set; }


  }
}
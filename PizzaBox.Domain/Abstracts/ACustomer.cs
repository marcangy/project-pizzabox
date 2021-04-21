using System;
namespace PizzaBox.Domain.Abstracts
{
  public abstract class ACustomer : AModel
  {
    public string Name { get; set; }
    public int ID { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
using System;
namespace PizzaBox.Domain.Abstracts
{
  public abstract class AComponent : AModel
  {
    public string Name { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
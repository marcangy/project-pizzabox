using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class ACustomer : AModel
  {
    public string Name { get; set; }
    public List<AOrder> Orders { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
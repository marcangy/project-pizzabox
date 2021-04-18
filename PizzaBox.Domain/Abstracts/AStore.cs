using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public abstract class AStore : Object
  {
    public string Name { get; set; }
    public List<RegOrder> Orders { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
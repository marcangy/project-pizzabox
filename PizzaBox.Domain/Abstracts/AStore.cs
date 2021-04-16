using System;
using System.Collections.Generic;
namespace PizzaBox.Domain.Abstracts
{
    public abstract class AStore
    {
        public string Name { get; protected set; }
        public List<RegOrder> Orders { get; protected set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
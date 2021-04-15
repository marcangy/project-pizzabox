using System;
namespace PizzaBox.Domain.Abstracts
{
public abstract class AStore
    {
        public string Name {get; protected set;}

        public override string ToString()
        {
            return Name;
        }
    }
}
using System;
namespace PizzaBox.Domain.Abstracts
{
public abstract class AComponent
    {
        public string Name {get; protected set;}
        public double Price {get; protected set;}

        public override string ToString()
        {
            return Name;
        }
    }
}
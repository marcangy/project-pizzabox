using System;
namespace PizzaBox.Domain.Abstracts
{
public abstract class APizza
    {
        public string Name {get; protected set;}
        public string[] Toppings {get; protected set;}
        public string Size {get; protected set;}
        public string Crust {get; protected set;}
        public double TotalPrice {get; protected set;}

        public override string ToString()
        {
            return Name;

        }

    }
}
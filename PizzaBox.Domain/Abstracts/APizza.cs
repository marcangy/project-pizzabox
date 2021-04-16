using System.Collections.Generic;
using PizzaBox.Domain.Models;
namespace PizzaBox.Domain.Abstracts
{
public abstract class APizza
    {
        public string Name {get; protected set;}
        public List<Topping> Toppings {get; protected set;}
        public Size Size {get; protected set;}
        public Crust Crust {get; protected set;}
        public double TotalPrice {get; protected set;}



    }
}
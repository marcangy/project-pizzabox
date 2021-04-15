using System;
namespace PizzaBox.Domain.Abstracts
{
public abstract class ACustomer
    {
        public string Name {get; protected set;}
        public int ID {get; protected set;}

        public override string ToString()
        {
            return Name;
        }
    }
}
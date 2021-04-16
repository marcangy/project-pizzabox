using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AOrder
    {
        public int ID { get; protected set; }
        public RegCustomer Customer { get; protected set; }
        public List<APizza> Pizzas { get; protected set; }
        public int TotalPrice { get; protected set; }

    }
}
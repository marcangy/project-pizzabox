using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
// using sc = System.Console;

namespace PizzaBox.Client
{
    public class Program
    {
        private static void Main()
        {
            var stores = new List<AStore>{new ChicagoStore(), new NewYorkStore()}; //explicit
          
            var customers = new List<ACustomer>{new RegCustomer()};

            var specialpizzas = new List<APizza>{new PresetPizza()};
            var regpizza = new List<APizza>{new CustomPizza()};
            
            v

            for (var x=0; x < stores.Count; x += 1)
            {
                   Console.WriteLine($"{x} {stores[x]}");
            }

            Console.WriteLine("make a selection");
            string input = Console.ReadLine();
            int entry = int.Parse(input);

            Console.WriteLine(stores[entry]);

        }
    }
}
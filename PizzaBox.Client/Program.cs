using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singleton;
using PizzaBox.Storing.Repositories;
// using sc = System.Console;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly ToppingsSingleton _toppingsSingleton = ToppingsSingleton.Instance;
    private static readonly CrustSingleton _crustsSingleton = CrustSingleton.Instance;
    private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

    private static void Main()
    {

      Run();

    }

    private static void Run()
    {

      var order = new RegOrder();
      order.Customer = new RegCustomer();
      Console.WriteLine("Welcome to PizzaBox" + " " + order.Customer.Name);
      PrintStoreList();
      Console.WriteLine("Please Select a Store");
      order.Store = SelectStore();
      Console.WriteLine("Please Select your Pizza");
      PrintPizzaList();
      order.Pizzas = SelectPizza();
      Console.WriteLine("Here is your Order and Total");
      PrintOrder(order.Pizzas, order);
      order.Store.Orders.Add(order);
      Console.WriteLine("Would you like to place another order?");
    }
    private static void PrintOrder(List<APizza> pizzas, RegOrder order)
    {


      foreach (var item in pizzas)
      {
        Console.WriteLine($"{"1"} {item.Size} {item.Name} {item.TotalPrice}");


      }
      Console.WriteLine($"{"Order Total"} {order.TotalCost}");


    }

    private static APizza ModifyPizza(APizza pizza)
    {
      Console.WriteLine("Please Select your Size");
      //
      Console.WriteLine("Please Select your Crust");
      //

      if (pizza.GetType().Equals(typeof(CustomPizza)))
      {
        do
        {
          Console.WriteLine("Please Select your Toppings");
          PrintToppingsList();
          var valid = int.TryParse(Console.ReadLine(), out int value);
          if (!valid)
          {
            return null;
          }
          pizza.Toppings.Add(_toppingsSingleton.Toppings[value - 1]);


        } while (pizza.Toppings.Count <= 5);


      }
      return pizza;
    }
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int value);
      if (!valid)
      {
        return null;
      }

      return _storeSingleton.Stores[value - 1];

    }
    private static List<APizza> SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int value);
      if (!valid || value > _pizzaSingleton.Pizzas.Count)
      {
        return null;
      }
      List<APizza> selectedPizzas = new List<APizza>() { _pizzaSingleton.Pizzas[value - 1] };
      do
      {
        PrintPizzaList();
        Console.WriteLine("Would You like to add another Pizza?");
        valid = int.TryParse(Console.ReadLine(), out value);

        if (!valid)
        {
          return selectedPizzas;
        }
        if (value == _pizzaSingleton.Pizzas.Count + 1)
        {
          return selectedPizzas;
        }
        selectedPizzas.Add(_pizzaSingleton.Pizzas[value - 1]);

        {

        }

      } while (selectedPizzas.Count < 50);





      return selectedPizzas;

    }
    private static void PrintStoreList()
    {
      var index = 0;
      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{index += 1} {item.Name}");
      }


    }

    private static void PrintPizzaList()
    {
      var index = 0;
      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{index += 1} {item.Name}");

      }
      Console.WriteLine($"{index += 1} {"Print Order"}");

    }
    private static void PrintToppingsList()
    {
      var index = 0;
      foreach (var item in _toppingsSingleton.Toppings)
      {
        Console.WriteLine($"{index += 1} {item.Name}");

      }
      Console.WriteLine($"{index += 1} {"Exit"}");

    }

  }
}
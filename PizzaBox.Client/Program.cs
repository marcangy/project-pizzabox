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
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance(_context);
    //private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private static readonly OrderRepository _orderRepository = new OrderRepository(_context);



    private static void Main()
    {

      Run();

    }

    private static void Run()
    {
      List<AOrder> vieworderlist = new List<AOrder>();
      int option = new int();
      var order = new RegOrder();
      string customername = "";
      do
      {
        Console.WriteLine($"{0}{"-"} {"New Customer"}");
        Console.WriteLine($"{1}{"-"} {"Returning Customer"}");
        Console.WriteLine($"{2}{"-"} {"Store Login"}");
        var valid = int.TryParse(Console.ReadLine(), out int customerselect);
        if (!valid || customerselect > 2)
        {
          continue;
        }

        if (customerselect == 0)
        {
          Console.WriteLine($"{"Please type in your name"}");
          customername = Console.ReadLine();
          order.Customer = new RegCustomer() { Name = customername };
        }
        else
        {
          Console.WriteLine("Please Select a Customer");
          PrintCustomerList();
          order.Customer = SelectCustomer();
        }
      } while (order.Customer == null);

      Console.WriteLine("Welcome to PizzaBox" + " " + order.Customer.Name);
      PrintStoreList();
      Console.WriteLine("Please Select a Store");
      order.Store = SelectStore();
      Console.WriteLine("Please Select your Pizzas");
      PrintPizzaList();
      order.Pizzas = SelectPizza();
      PrintOrder(order);

      do
      {
        PrintOptionsList();
        var valid = int.TryParse(Console.ReadLine(), out option);
        if (option == 0)
        {
          Console.WriteLine("Please select the Pizza you would like to modify");
          PrintOrder(order);
          valid = int.TryParse(Console.ReadLine(), out int value);
          PrintCurrentToppingsList(order.Pizzas[value]);
          ModifyPizza(order.Pizzas[value]);
          PrintCurrentToppingsList(order.Pizzas[value]);
        }

        if (option == 1)
        {
          PrintPizzaList();
          valid = int.TryParse(Console.ReadLine(), out int value);
          if (!valid)
          {
            continue;
          }
          if (value >= _pizzaSingleton.Pizzas.Count)
          {
            continue;
          }
          order.Pizzas.Add(_pizzaSingleton.Pizzas[value]);
        }

        if (option == 2)
        {
          Console.WriteLine("Which Pizza would you like to remove");
          PrintOrder(order);
          valid = int.TryParse(Console.ReadLine(), out int value);
          order.Pizzas.Remove(order.Pizzas[value]);
          PrintOrder(order);
        }

        if (option == 3)
        {
          //Cashout - Add Order to the Database
          _orderRepository.Create(order);

        }

        if (option == 4)
        {
          //View Current Order
          PrintOrder(order);
        }

        if (option == 5)
        {
          //View All Orders
          PrintAllOrder(_storeSingleton.ViewOrders(order.Store), order.Customer);
        }

        if (option == 6)
        {
          break;
        }
      } while (option != 6);



    }
    private static void PrintOrder(RegOrder order)
    {
      List<APizza> pizzas = order.Pizzas;
      Console.WriteLine("Here is your Order and Total");
      var index = -1;
      foreach (var item in pizzas)
      {
        item.CalculatePrice();
        Console.WriteLine($"{"1"} {index += 1} {item.ToString()} {item.TotalPrice}");


      }
      Console.WriteLine($"{"Order Total"} {order.TotalCost}");


    }

    private static void PrintAllOrder(AStore store, ACustomer customer)
    {

      Console.WriteLine("Here are all your past orders for your current store");
      var orderindex = -1;
      var orderent = new long();
      foreach (var orderitem in store.Orders)
      {
        orderindex++;
        if (store.Orders[orderindex].Customer.Name == customer.Name)
        {
          List<APizza> pizzas = store.Orders[orderindex].Pizzas;
          orderent = store.Orders[orderindex].EntityID;
          int Pizzaindex = -1;
          Console.WriteLine($"{"-------"} {"Order Number:"} {orderent} {"-------"}");
          foreach (var item in pizzas)
          {
            Pizzaindex++;
            Console.WriteLine($" {Pizzaindex} {item.ToString()} {item.TotalPrice}");

          }
          Console.WriteLine($"{"Order Total"} {store.Orders[orderindex].TotalCost}");
        }

      }

    }

    private static APizza ModifyPizza(APizza pizza)
    {
      int choice = new int();
      do
      {
        Console.WriteLine("What would you like to change");

        Console.WriteLine($"{0} {"-"} {"Change Size"}");
        Console.WriteLine($"{1} {"-"} {"Change Crust"}");
        Console.WriteLine($"{2} {"-"} {"Add Toppings"}");
        Console.WriteLine($"{3} {"-"} {"Remove Toppings"}");
        Console.WriteLine($"{4} {"-"} {"Exit"}");


        var valid = int.TryParse(Console.ReadLine(), out choice);
        if (!valid)
        {
          return pizza;
        }

        if (choice == 0)
        {
          Console.WriteLine("Please Select your Size");
          PrintSizeList();
          valid = int.TryParse(Console.ReadLine(), out int value);
          if (!valid || value >= _sizeSingleton.Sizes.Count)
          {
            continue;
          }
          pizza.Size = _sizeSingleton.Sizes[value];
          continue;

        }

        if (choice == 1)
        {
          Console.WriteLine("Please Select your Crust");
          PrintCrustList();
          valid = int.TryParse(Console.ReadLine(), out int value);
          if (!valid || value >= _crustsSingleton.Crusts.Count)
          {
            continue;
          }
          pizza.Size = _sizeSingleton.Sizes[value];
          continue;
        }


        if (choice == 2)
        {
          if (pizza.Name == "Custom Pizza")
          {
            do
            {
              Console.WriteLine("Please Select your Toppings");
              PrintToppingsList();
              valid = int.TryParse(Console.ReadLine(), out int value);
              if (!valid || value >= _toppingsSingleton.Toppings.Count)
              {
                break;
              }
              pizza.Toppings.Add(_toppingsSingleton.Toppings[value]);


            } while (pizza.Toppings.Count < 5);

          }
          else
          {
            Console.WriteLine("Selected Pizza is not a Custom Pizza");
          }
        }

        if (choice == 3)
        {
          if (pizza.GetType().Equals(typeof(CustomPizza)))
          {
            do
            {
              Console.WriteLine("Please Select the Toppings you would like to remove");
              PrintCurrentToppingsList(pizza);

              valid = int.TryParse(Console.ReadLine(), out int value);
              if (!valid || value >= pizza.Toppings.Count)
              {
                break;
              }
              pizza.Toppings.Remove(pizza.Toppings[value]);


            } while (pizza.Toppings.Count > 3);

          }
          else
          {
            Console.WriteLine("Selected Pizza is not a Custom Pizza");
          }
        }

        if (choice == 4)
        {
          break;
        }
      } while (choice != 4);
      pizza.CalculatePrice();
      return pizza;

    }
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int value);
      if (!valid)
      {
        return null;
      }

      return _storeSingleton.Stores[value];

    }

    private static ACustomer SelectCustomer()
    {
      var valid = int.TryParse(Console.ReadLine(), out int value);
      if (!valid)
      {
        return null;
      }

      return _customerSingleton.Customers[value];

    }
    private static List<APizza> SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int value);
      if (!valid || value > _pizzaSingleton.Pizzas.Count)
      {
        return null;
      }
      List<APizza> selectedPizzas = new List<APizza>() { _pizzaSingleton.Pizzas[value] };
      double TotalPizzaCost = new double();
      do
      {
        Console.WriteLine("Would You like to add another Pizza?");
        PrintPizzaList();
        valid = int.TryParse(Console.ReadLine(), out value);

        if (!valid)
        {
          return selectedPizzas;
        }
        if (value >= _pizzaSingleton.Pizzas.Count)
        {
          return selectedPizzas;
        }

        selectedPizzas.Add(_pizzaSingleton.Pizzas[value]);
        TotalPizzaCost += _pizzaSingleton.Pizzas[value].TotalPrice;

        {

        }

      } while (selectedPizzas.Count < 50 & TotalPizzaCost < 250.0);





      return selectedPizzas;

    }
    private static void PrintStoreList()
    {
      var index = -1;
      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{index += 1}{"-"} {item.Name}");
      }


    }

    private static void PrintPizzaList()
    {
      var index = -1;
      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{index += 1}{"-"} {item.ToString()}");

      }
      Console.WriteLine($"{index += 1}{"-"} {"Print Order"}");

    }
    private static void PrintToppingsList()
    {
      var index = -1;
      foreach (var item in _toppingsSingleton.Toppings)
      {
        Console.WriteLine($"{index += 1} {"-"} {item.ToFormat()}");

      }
      Console.WriteLine($"{index += 1} {"-"} {"Exit"}");

    }

    private static void PrintCurrentToppingsList(APizza Pizza)
    {
      var index = -1;
      foreach (var item in Pizza.Toppings)
      {
        Console.WriteLine($"{index += 1}{"-"} {item.ToFormat()}");

      }
      Console.WriteLine($"{index += 1}{"-"} {"Exit"}");

    }

    private static void PrintSizeList()
    {
      var index = -1;
      foreach (var item in _sizeSingleton.Sizes)
      {
        Console.WriteLine($"{index += 1}{"-"} {item.ToFormat()}");

      }
      Console.WriteLine($"{index += 1}{"-"} {"Exit"}");

    }


    private static void PrintCrustList()
    {
      var index = -1;
      foreach (var item in _crustsSingleton.Crusts)
      {
        Console.WriteLine($"{index += 1} {"-"} {item.ToFormat()}");

      }
      Console.WriteLine($"{index += 1} {"-"} {"Exit"}");

    }
    private static void PrintCustomerList()
    {
      var index = -1;
      foreach (var item in _customerSingleton.Customers)
      {
        Console.WriteLine($"{index += 1} {"-"} {item.ToString()}");

      }
      Console.WriteLine($"{index += 1} {"-"} {"Exit"}");

    }

    private static void PrintOptionsList()
    {
      Console.WriteLine("Options");
      Console.WriteLine($"{0}{"-"} {"Modify Pizza"}");
      Console.WriteLine($"{1}{"-"} {"Add Pizza"}");
      Console.WriteLine($"{2}{"-"} {"Remove Pizza"}");
      Console.WriteLine($"{3}{"-"} {"Cash Out"}");
      Console.WriteLine($"{4}{"-"} {"View Order"}");
      Console.WriteLine($"{5}{"-"} {"View All Orders"}");
      Console.WriteLine($"{6}{"-"} {"Exit"}");
    }


  }
}
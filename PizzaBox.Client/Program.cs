using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singleton;
// using sc = System.Console;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static void Main()
    {
      PrintStoreList();
      // for (var x = 0; x < stores.Count; x += 1)
      // {
      //     Console.WriteLine($"{x} {stores[x]}");
      // }

      // Console.WriteLine("make a selection");
      // string input = Console.ReadLine();
      // int entry = int.Parse(input);

      // Console.WriteLine(stores[entry]);

    }
    private static void PrintStoreList()
    {
      var index = 0;
      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{index += 1} {item}");
      }


    }

  }
}
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singleton
{

  public class ToppingsSingleton
  {
    private static ToppingsSingleton _instance;
    private const string _path = @"data/toppings.xml";
    private static FileRepository _filerepository = new FileRepository();
    List<Topping> ToppingsTest = new List<Topping> { new Topping() { Name = "Cheese" }, new Topping() { Name = "Bacon" }, new Topping() { Name = "Ham" }, new Topping() { Name = "Mushroom" }, new Topping() { Name = "Beef" }, new Topping() { Name = "Beef" }, new Topping() { Name = "Spinach" }, new Topping() { Name = "Spinach" }, new Topping() { Name = "Olives" } };
    public static ToppingsSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ToppingsSingleton();
        }

        return _instance;

      }

    }
    public List<Topping> Toppings
    {
      get
      {
        return ToppingsTest;
      }

    }



    private ToppingsSingleton()
    {
      _filerepository.WriteFromFile<List<Topping>>(_path, ToppingsTest);

      ToppingsTest = _filerepository.ReadFromFile<List<Topping>>(_path);


    }


  }
}
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using System.Linq;
namespace PizzaBox.Client.Singleton
{

  public class ToppingsSingleton
  {
    private static ToppingsSingleton _instance;
    private const string _path = @"data/toppings.xml";
    private static FileRepository _filerepository = new FileRepository();
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    public List<Topping> ToppingsTest { get; set; }
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
      //_filerepository.WriteFromFile<List<Topping>>(_path, ToppingsTest);
      ToppingsTest = _filerepository.ReadFromFile<List<Topping>>(_path);
      // _context.Toppings.AddRange(ToppingsTest);
      // _context.SaveChanges();
      // ToppingsTest = _context.Toppings.ToList();





    }


  }
}
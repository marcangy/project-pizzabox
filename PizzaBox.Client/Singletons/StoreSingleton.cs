using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singleton
{

  public class StoreSingleton
  {
    private static StoreSingleton _instance;
    private const string _path = @"data/stores.xml";
    private static FileRepository _filerepository = new FileRepository();
    private static PizzaBoxContext _context = new PizzaBoxContext();
    List<AStore> StoreTest = new List<AStore> { };

    public List<AStore> Stores
    {

      get
      {

        return StoreTest;

      }

    }
    public static StoreSingleton Instance(PizzaBoxContext context)
    {

      if (_instance == null)
      {
        _instance = new StoreSingleton(context);
      }

      return _instance;


    }

    private StoreSingleton(PizzaBoxContext context)
    {
      _context = context;
      // StoreTest = _filerepository.ReadFromFile<List<AStore>>(_path);
      // _context.Stores.AddRange(StoreTest);
      // _context.SaveChanges();
      StoreTest = _context.Stores.ToList();
      // _filerepository.WriteFromFile<List<AStore>>(_path, StoreTest);

    }


    public AStore ViewOrders(AStore store)
    {
      // lambda - lINQ (linq to objects)
      // EF Loading = Eager Loading
      var orders = _context.Stores //load all stores
                    .Include(s => s.Orders) // load all orders for all stores
                    .ThenInclude(o => o.Pizzas) // load all pizzas for all orders
                    .Where(s => s.Name == store.Name); // LINQ = lang integrated query
      var pizzas = _context.Pizzas
                    .Include(p => p.Toppings)
                    .Include(p => p.Crust)
                    .Include(p => p.Size);

      foreach (var item in orders)
      {
        var index = 0;
        //_context.Orders.FirstOrDefault(o => o.Pizzas == store.Orders[index].Pizzas);

        for (int i = 0; i < store.Orders[index].Pizzas.Count; i++)
        {



          //_context.Entry<AOrder>(store.Orders[index]).Collection<APizza>(o => o.Pizzas).Load();
          // _context.Pizzas.FirstOrDefault(p => p.Name == store.Orders[index].Pizzas[i].Name);
          // _context.Entry<APizza>(store.Orders[index].Pizzas[i]).Collection<Topping>(p => p.Toppings).Load();
          // _context.Entry<Crust>(store.Orders[index].Pizzas[i].Crust).

        }
        index++;

      }

      // EF Explicit Loading
      return store;


      // // sql - LINQ (ling to sql)
      // // EF Lazy Loading
      // var orders2 = from r in _context.Stores
      //                 //join ro in _context.Orders on r.EntityId == ro.StoreEntityId
      //               where r.Name == store.Name
      //               select r;


    }


  }
}
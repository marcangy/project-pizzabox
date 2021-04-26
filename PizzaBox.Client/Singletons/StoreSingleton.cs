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

      // EF Explicit Loading
      var st = _context.Stores.FirstOrDefault(s => s.Name == store.Name);
      _context.Entry<AStore>(store).Collection<AOrder>(s => s.Orders).Load(); // load all orders+ properties for 1 store

      // sql - LINQ (ling to sql)
      // EF Lazy Loading
      var orders2 = from r in _context.Stores
                      //join ro in _context.Orders on r.EntityId == ro.StoreEntityId
                    where r.Name == store.Name
                    select r;

      return st;
    }


  }
}
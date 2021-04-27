using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using System.Linq;
namespace PizzaBox.Client.Singleton
{

  public class PizzaSingleton
  {
    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";
    private static FileRepository _filerepository = new FileRepository();
    private static PizzaBoxContext _context = new PizzaBoxContext();
    public List<APizza> PizzaTest { get; set; }

    public List<APizza> Pizzas
    {
      get
      {
        return PizzaTest;
      }

    }
    public static PizzaSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new PizzaSingleton(context);
      }

      return _instance;



    }


    private PizzaSingleton(PizzaBoxContext context)
    {
      _context = context;
      // _filerepository.WriteFromFile<List<APizza>>(_path, PizzaTest);

      // PizzaTest = _filerepository.ReadFromFile<List<APizza>>(_path);
      //_context.Pizzas.AddRange(PizzaTest);
      // _context.SaveChanges();
      PizzaTest = _context.Pizzas.ToList();


    }


  }
}
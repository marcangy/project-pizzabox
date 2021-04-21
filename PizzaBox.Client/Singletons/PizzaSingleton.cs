using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singleton
{

  public class PizzaSingleton
  {
    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";
    private static FileRepository _filerepository = new FileRepository();
    List<APizza> PizzaTest = new List<APizza> { new CustomPizza(), new MeatLoversPizza(), new VeggiePizza(), new CheesePizza() };
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;

      }

    }
    public List<APizza> Pizzas
    {
      get
      {
        return PizzaTest;
      }

    }



    private PizzaSingleton()
    {
      _filerepository.WriteFromFile<List<APizza>>(_path, PizzaTest);

      PizzaTest = _filerepository.ReadFromFile<List<APizza>>(_path);


    }


  }
}
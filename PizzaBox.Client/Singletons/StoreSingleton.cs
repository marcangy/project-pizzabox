using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
namespace PizzaBox.Client.Singleton
{
  public class StoreSingleton
  {
    private static readonly StoreSingleton _instance;
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new StoreSingleton();
        }

        return _instance;

      }

    }
    public List<AStore> Stores
    {

      get
      {
        List<AStore> storetest = new List<AStore> { new NewYorkStore(), new ChicagoStore() };
        return storetest;

      }

    }

    private StoreSingleton()
    {

    }


  }
}
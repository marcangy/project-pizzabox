using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singleton
{

  public class StoreSingleton
  {
    private static StoreSingleton _instance;
    private const string _path = @"data/stores.xml";
    private static FileRepository _filerepository = new FileRepository();
    List<AStore> StoreTest = new List<AStore> { };
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;

      }

    }
    public List<AStore> Stores
    {

      get
      {

        return StoreTest;

      }

    }

    private StoreSingleton()
    {

      StoreTest = _filerepository.ReadFromFile<List<AStore>>(_path);

      _filerepository.WriteFromFile<List<AStore>>(_path, StoreTest);

    }


  }
}
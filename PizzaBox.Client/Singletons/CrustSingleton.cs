using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singleton
{

  public class CrustSingleton
  {
    private static CrustSingleton _instance;
    private const string _path = @"data/crusts.xml";
    private static FileRepository _filerepository = new FileRepository();
    List<Crust> CrustTest = new List<Crust> { new Crust() { Name = "Original" }, new Crust() { Name = "Deep Dish" }, new Crust() { Name = "Thin" } };
    public static CrustSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CrustSingleton();
        }

        return _instance;

      }

    }
    public List<Crust> Crusts
    {
      get
      {
        return CrustTest;
      }

    }



    private CrustSingleton()
    {
      _filerepository.WriteFromFile<List<Crust>>(_path, CrustTest);

      CrustTest = _filerepository.ReadFromFile<List<Crust>>(_path);


    }


  }
}
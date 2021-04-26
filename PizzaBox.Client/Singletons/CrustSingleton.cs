using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using System.Linq;
namespace PizzaBox.Client.Singleton
{

  public class CrustSingleton
  {
    private static CrustSingleton _instance;
    private const string _path = @"data/crusts.xml";
    private static FileRepository _filerepository = new FileRepository();
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();

    List<Crust> CrustTest = new List<Crust> { new Crust() { Name = "Original" }, new Crust() { Name = "Deep Dish", Price = 1 }, new Crust() { Name = "Thin", Price = 1 } };
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
      // _filerepository.WriteFromFile<List<Crust>>(_path, CrustTest);

      CrustTest = _filerepository.ReadFromFile<List<Crust>>(_path);
      // _context.Crusts.AddRange(CrustTest);
      // _context.SaveChanges();
      // CrustTest = _context.Crusts.ToList();


    }


  }
}
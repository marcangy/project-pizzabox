using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singleton
{

  public class SizeSingleton
  {
    private static SizeSingleton _instance;
    private const string _path = @"data/sizes.xml";
    private static FileRepository _filerepository = new FileRepository();
    List<Size> sizetest = new List<Size> { new Size().SizeLarge(), new Size() { Name = "Medium", Price = 9.5 }, new Size() { Name = "Large", Price = 11.5 } };
    public static SizeSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new SizeSingleton();
        }

        return _instance;

      }

    }
    public List<Size> crusts
    {

      get
      {

        return sizetest;

      }

    }

    private SizeSingleton()
    {
      _filerepository.WriteFromFile<List<Size>>(_path, sizetest);

      sizetest = _filerepository.ReadFromFile<List<Size>>(_path);


    }


  }
}
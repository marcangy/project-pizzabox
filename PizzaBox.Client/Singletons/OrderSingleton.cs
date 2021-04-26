using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using System.Linq;
namespace PizzaBox.Client.Singleton
{

  public class OrderSingleton
  {
    private static OrderSingleton _instance;
    private const string _path = @"data/orders.xml";
    private static FileRepository _filerepository = new FileRepository();
    public List<AOrder> ordertest { get; set; }

    private static readonly PizzaBoxContext _context = new PizzaBoxContext();

    public static OrderSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new OrderSingleton();
        }

        return _instance;

      }

    }
    public List<AOrder> Orders
    {

      get
      {

        return ordertest;

      }

    }
    public void SaveOrder(AOrder order)
    {
      //_filerepository.WriteFromFile<List<AOrder>>(_path, ordertest);
      //Saves to Database
      _context.Orders.Add(order);
      _context.SaveChanges();

    }

    private OrderSingleton()
    {



    }


  }
}
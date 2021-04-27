using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singleton
{

  public class CustomerSingleton
  {
    private static CustomerSingleton _instance;
    private readonly PizzaBoxContext _context;

    public List<ACustomer> Customers { get; set; }

    public static CustomerSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new CustomerSingleton(context);
      }

      return _instance;

    }

    private CustomerSingleton(PizzaBoxContext context)
    {
      _context = context;
      Customers = _context.Customers.ToList();
    }



  }
}
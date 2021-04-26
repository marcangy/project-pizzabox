using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private readonly PizzaBoxContext _context;

    public OrderRepository(PizzaBoxContext context)
    {
      _context = context;
    }
    public void Create(RegOrder order)
    {
      //order.Store = _context.Stores.FirstOrDefault(s => s.Name == order.Store.Name);
      //order.Pizzas = _context.Stores.FirstOrDefault(s => s.Name == order.Store.Name).Orders.FirstOrDefault(o => o.EntityID == order.EntityID).Pizzas.FirstOrDefault(p => p == order.Pizzas);
      _context.Orders.Add(order);
      _context.SaveChanges();
    }
  }
}
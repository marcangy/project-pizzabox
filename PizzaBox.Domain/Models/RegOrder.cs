using PizzaBox.Domain.Abstracts;

public class RegOrder : AOrder
{

  public double TotalCost
  {
    get
    {

      var TotalPrice = new double();
      foreach (var item in Pizzas)
      {
        TotalPrice += item.TotalPrice;
      }
      return TotalPrice;
    }
  }

}
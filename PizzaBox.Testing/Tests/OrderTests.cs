using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderTest
  {

    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[]{new RegOrder(){Pizzas = new List<APizza>{new MeatLoversPizza()}, Store = new NewYorkStore(), Customer = new RegCustomer{Name = "Marcangy Cange"} }},

    };

    [Theory]
    [MemberData(nameof(values))]
    public void Test_OrderContents(RegOrder order)
    {
      Assert.NotNull(order.Pizzas);
      Assert.NotNull(order.Customer);
      Assert.NotNull(order.Store);


    }
    [Theory]
    [MemberData(nameof(values))]
    public void Test_OrderContentstype(RegOrder order)
    {
      Assert.IsType<string>(order.Customer.Name);
      Assert.IsType<RegCustomer>(order.Customer);
      Assert.IsType<List<APizza>>(order.Pizzas);
      Assert.IsType<NewYorkStore>(order.Store);

    }
    [Theory]
    [MemberData(nameof(values))]
    public void Test_PizzaCalc(RegOrder order)
    {
      var TotalPrice = new double();
      foreach (var item in order.Pizzas)
      {
        TotalPrice += item.TotalPrice;
      }

      Assert.Equal(order.TotalCost, TotalPrice);

    }


  }

}
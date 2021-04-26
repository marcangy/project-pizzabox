using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTest
  {

    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[]{new MeatLoversPizza()},
      new object[]{new VeggiePizza()},
      new object[]{new CheesePizza()},
      new object[]{new CustomPizza()}
    };

    [Theory]
    [MemberData(nameof(values))]
    public void Test_PizzaContents(APizza pizza)
    {
      Assert.NotNull(pizza.Name);
      Assert.NotNull(pizza.Size);
      Assert.NotNull(pizza.Toppings);
      Assert.NotNull(pizza.Crust);
      Assert.NotNull(pizza.Size);
      Assert.Equal(pizza.TotalPrice, pizza.CalculatePrice());

    }
  }

}
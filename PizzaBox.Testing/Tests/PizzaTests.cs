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
      Assert.NotNull(pizza.Size.Price);
      Assert.NotNull(pizza.Toppings);
      Assert.NotNull(pizza.Crust);
      Assert.NotNull(pizza.Crust.Name);
      Assert.NotNull(pizza.Size);
      Assert.True(pizza.Toppings.Count >= 2);


    }
    [Theory]
    [MemberData(nameof(values))]
    public void Test_PizzaContentstype(APizza pizza)
    {
      Assert.IsType<string>(pizza.Name);
      Assert.IsType<Size>(pizza.Size);
      Assert.IsType<double>(pizza.Size.Price);
      Assert.IsType<List<Topping>>(pizza.Toppings);
      Assert.IsType<Crust>(pizza.Crust);
      Assert.IsType<string>(pizza.Name);

    }
    [Theory]
    [MemberData(nameof(values))]
    public void Test_PizzaCalc(APizza pizza)
    {

      Assert.Equal(pizza.TotalPrice, pizza.CalculatePrice());

    }


  }

}
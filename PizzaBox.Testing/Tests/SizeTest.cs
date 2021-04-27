using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class SizeTest
  {

    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[]{new Size(){Name ="Large"}},
      new object[]{new Size(){Name ="Medium"}},
      new object[]{new Size(){Name= "Small"}}
    };


    [Theory]
    [MemberData(nameof(values))]
    public void Test_SizeContents(Size size)
    {

      Assert.NotNull(size.Name);
      Assert.Equal(size.Price, 0);
      Assert.IsType<string>(size.Name);
      Assert.IsType<double>(size.Price);

    }
  }

}
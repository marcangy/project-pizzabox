
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing.Tests
{

  public class StoreTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[]{new NewYorkStore()},
      new object[]{new ChicagoStore()}
    };

    [Fact]
    public void Test_ChicagoStore()
    {
      // arrange 
      var sut = new ChicagoStore();

      //act
      var actual = sut.Name;

      //actual ="dotnet"; // This should not happen

      //assert
      Assert.True(actual == "ChicagoStore");
      Assert.True(sut.ToString() == actual);
    }

    [Fact]
    public void Test_NewYorkStore()
    {

      var sut = new NewYorkStore();

      var actual = sut.Name;

      Assert.True(actual.Equals("NewYorkStore"));
    }
    [Theory]
    [MemberData(nameof(values))]
    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.Name);
      //Making sure ToString returns the correct name
      Assert.Equal(store.Name, store.ToString());
    }



  }

}
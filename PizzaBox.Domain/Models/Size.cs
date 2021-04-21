using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{

  public class Size : AComponent
  {
    public Size SizeLarge()
    {
      Size size = new Size()
      {
        Name = "Large",
        Price = 11.5
      };
      return size;

    }
    public void SizeMedium()
    {
      Name = "Medium";
      Price = 9.5;
    }
    public void SizeSmall()
    {
      Name = "Small";
      Price = 7.5;
    }
    public Size()
    {


    }
  }

}
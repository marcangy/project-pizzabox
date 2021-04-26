using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{

  public class Size : AComponent
  {
    public void SizeLarge()
    {

      Name = "Large";
      Price = 11.5;




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
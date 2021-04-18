using System.IO;
using System.Xml.Serialization;
using System;

namespace PizzaBox.Storing.Repositories
{
  public class FileRepository
  {
    public T ReadFromFile<T>(string path) where T : class
    {

      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(T));

      return xml.Deserialize(reader) as T;

    }
    public void WriteFromFile<T>(string path, T items) where T : class
    {
      //try
      //{

      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(T));

      xml.Serialize(writer, items);
      // return true;
      // }

      // catch
      // {
      //   return false;
      // }

    }


  }
}
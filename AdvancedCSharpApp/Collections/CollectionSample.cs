using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.Collections
{
  public static class CollectionSample
  {
    public record Location
    {
      public double Latitude { get; init; } // enlem
      public double Longitude { get; init; } // boylam

      public Location(double latitude,double longitude)
      {
        Latitude = latitude;
        Longitude = longitude;
      }
    }

    public class Money
    {
      public string Currency { get; private set; }
      public decimal Amount { get; private set; }

      public Money(decimal amount, string currency = "TL")
      {
        Amount = amount;
        Currency = currency;
      }

    }

    // HashSet
    
    public static void HashSetSample()
    {
      // hashset nesnelerin referance eşitliğine bakar.
      HashSet<Money> monies = new HashSet<Money>();
      var m1 = new Money(100, "$");
      var m2 = m1;

      m2.Equals(m1); // true referance value equal

      monies.Add(m1);
      monies.Add(m2);
      monies.Add(new Money(100, "Euro"));

      Console.WriteLine(monies.Count);

      HashSet<Location> locations = new HashSet<Location>();
      var l1 = new Location(latitude: 10, longitude: 25); // farklı referanslar
      var l2 = new Location(latitude: 10, longitude: 25);
      var l3 = new Location(latitude: 24, longitude: 35);

      l1.Equals(l2); // value eşitliği true
      l1.Equals(l3); // false;

      locations.Add(l1);
      locations.Add(l2);
      locations.Add(l3);

      Console.WriteLine("locations :" + locations.Count);

    }
    
    // Dictionary

    public static void DictionarySample()
    {
      IDictionary<string, int> scores = new Dictionary<string, int>();
      // key unique
      scores["ahmet"] = 78;
      scores["mustafa"] = 56;
      // scores["ahmet"] = 15; hata alırız.

      scores.ContainsKey("ahmet"); // key kontrolü.

      foreach (KeyValuePair<string,int> item in scores)
      {
        Console.WriteLine($"key:{item.Key} value:{item.Value}");
      }

      //ICollection<string> lst = new Collection<string>();
      //lst.

    }


  }
}

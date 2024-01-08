using AdvancedCSharpApp.Converter;
using AdvancedCSharpApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.Serializations
{
  public static class SerializationsSample
  {

    public static void Sample()
    {
      var p = new Product("P-1", 10.785M, 20);
      // WhenWritingNull null değeri
      var options = new JsonSerializerOptions {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        IncludeFields = false,
        NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
        
      };

      // datetime serialization işleminde servis üzerinden işlem yap.
      options.Converters.Add(new DateTimeConverterUsingDateTimeParseAsFallback());
 

      // ProductName, productName, product_name
      // {
      //  "productName":"Tan",
      //  "price":10
      //  }

      var productString = System.Text.Json.JsonSerializer.Serialize<Product>(p, options);

      var product = JsonSerializer.Deserialize<Product>(productString, options);

    }


  }
}

using AdvancedCSharpApp.SeedWork;
using Akedas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.Entities
{
  // api/products/1
  // api/products/32432-zczxc-324324-xccxcxc
  // api/products/324324-324324-xczcx-32432-zxcxzc

  // event gerçekleştiğinde taşınacak olan değerler args
  public class PriceChangeEventArgs:EventArgs
  {
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public Guid ProductId { get; set; }

  }

  public delegate void PriceHandler(PriceChangeEventArgs args);

  
  public class Product:AuditableEntity<Guid>
  {
    public Product()
    {

    }
    // setter init olarak tanımladığğında sadece constructor içinden set edilebilir.

    [JsonConstructor] // deserialize ederken bu contructor kullansın
    public Product(string name,decimal price, short stock)
    {
      Id = Guid.NewGuid();
      CreatedAt = DateTime.Now;
      Name = name.Trim();
      Price = price;
      Stock = stock;
      //PriceChanged += Product_PriceChanged;
    }

    private void Product_PriceChanged(object? sender, EventArgs e)
    {
      var args = (PriceChangeEventArgs)e;

      Console.WriteLine($"Fiyat Değişimi oldu.Önceki fiyat {args.OldPrice}, güncel fiyat {args.NewPrice}");
    }

    [JsonPropertyName("productName")]
    [JsonPropertyOrder(0)]
    public string Name { get; private set; }

    

    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public decimal Price { get; private set; }

    [JsonIgnore]
    public short Stock { get; private set; }

    public string? Description { get; set; }

    private bool discontinued; // ürünün devamı var mı

    // Fiyat değişimi olduğunda
    // public event EventHandler PriceChanged;
    public event PriceHandler PriceChanged;

    // encapsulation yapmış olduk.

    public void SetName(string name)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new Exception("Name boş geçildi");
      }

      Name = name.Trim();
    }

    public void SetStock(short stock)
    {
      if(stock < 10)
      {
        throw new Exception("Minimum stock 10 adet aldında olmaz");
      }

      Stock = stock;
    }

    public void SetPrice(decimal price)
    {
      if(price <= 0)
      {
        throw new Exception("Fiyat bilgisi 0 dan küçük veya eşit olamaz");
      }

     
      var args = new PriceChangeEventArgs();
      args.OldPrice = Price;
      args.NewPrice = price;
      args.ProductId = this.Id;

       Price = price;
      //PriceChanged.Invoke(this, args);
      PriceChanged.Invoke(args);
    }

  }
}

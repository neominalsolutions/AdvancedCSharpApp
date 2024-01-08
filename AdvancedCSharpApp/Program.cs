//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


// Encapsulation, Inheritance, Abstraction, Polymorphism
// SOLID (Single Responsibity,Open Closed, Liskov,Interface Seggragation,Dependency Inversion)
// Design Patterns (DI,Repository Pattern, Mediator, Adapter, Facade, Factory Method Pattern, Unit Of Work, IOC)




using AdvancedCSharpApp.Collections;
using AdvancedCSharpApp.Entities;
using AdvancedCSharpApp.Extentions;
using AdvancedCSharpApp.Regexx;
using AdvancedCSharpApp.Repositories;
using AdvancedCSharpApp.SeedWork;
using AdvancedCSharpApp.Serializations;
using Akedas.Common.Datetime;
using Akedas.Common.Entities;
using System.Reflection;

// Bir işlemi handle ettikleri için suffix olarak Handler son eki ile tanımladık
public delegate void MessageHandler(string message);

public class MessageService
{
  public static void ShowMessage(string message)
  {
    Console.WriteLine(message);
  }

  public void ShowMessage2(int number)
  {
    Console.WriteLine(number);
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    // DelegateSample();
    // Collections();
    // ExtensionsSample();
    // Regexx();
    Serialization();
  }

  public static void OOPSample()
  {
    Product p = new Product("P-1", 10, 10);
    //p.Id = "2e324324";
    //p.Name = "asdsad";
    //p.Stock = 10;


    p.SetName("P-2");
    p.SetStock(20);

    Category c = new Category("Kategori-1");
    c.Description = "Açıklama";
    c.DeletedAt = DateTime.Now;

    c.SetDeleted("Artık bu kategoride ürünle çalışmıyoruz", "ahmet");

    //List<Product> plist = new List<Product>();
    //plist.Where(x => x.Name.Contains('a'));


    var c1 = new Category("dsadsa");
    var p1 = new Product("32432432", 23, 45);

    // var cRepo = new CategoryRepo();
    // cRepo.crate(c);
    // cRepo.save();

    // var pRepo = new ProductRepo();
    // pRepo.create(p);
    // pRepo.save();

    // Repository Sample
    var productRepo = new ProductRepository();
    productRepo.Create(p);
    var plist = productRepo.Find();
    var plistWhere = productRepo.Find(x => x.Name.Contains("ch"));
    productRepo.Delete(p.Id);
    plist = productRepo.Find();
    productRepo.Create(p1);
    productRepo.Update(new Product("P-1 Güncel", 15, 34));
    var pGuncel = productRepo.FindById(p1.Id);
    var pByName = productRepo.FindByName("P-1 Güncel"); // Inteface Repo
  }


  public static void DelegateSample()
  {
    //MessageHandler m1 = ShowMessage1;
    //MessageHandler m2 = ShowMessage2;

    //m1.Invoke("Mesaj1");
    //m2.Invoke("Message2");

    var programClass = new MessageService();
    MethodInfo[] methods = programClass.GetType().GetMethods();

    foreach (var item in methods)
    {
      Console.WriteLine("Type", item.GetType());

      if (item.IsStatic)
      {
        var dg = item.CreateDelegate<MessageHandler>();
        dg.Invoke("Messege");
      }
    }


    // 2.örnek
    Product p1 = new Product("P-1", 10, 25);
    p1.PriceChanged += P1_PriceChanged; ;
    p1.SetPrice(100); // Event Invoke edildiği method

  }

  // Event Driven Programing.
  private static void P1_PriceChanged(PriceChangeEventArgs args)
  {
    Console.WriteLine("Veri tabanına kaydet");
  }

  //private static void P1_PriceChanged(object? sender, EventArgs e)
  //{
  //  Console.WriteLine("Veri tabanına kaydet");
  //}

  public static void ShowMessage2(string message)
  {
    Console.WriteLine(message);
  }

  public static void Collections()
  {
    // CollectionSample.HashSetSample();
    CollectionSample.DictionarySample();
  }

  public static void ExtensionsSample()
  {
    var dt = DateTime.Now;
    Console.WriteLine(dt.GetFormatedDate()); // Tüm uygulamalarda helper yada util olarak kullanılacak örnek

    // Supplier Extension (Uygulama Spesific)
    var supplier = new Supplier();
    supplier.Country = "Türkiye";
    supplier.City = "İstanbul";
    supplier.Company = "Akedaş";

    Console.WriteLine(supplier.GetSupplierInfo());


  }

  public static void TuppleSample()
  {
    // 1.yöntem
    var product = new Product("P-1", 10, 20);
    var category = new Category("C-1");
    var vm = Tuple.Create<Product, Category>(product, category);
    string pName = vm.Item1.Name;
    vm.Item2.Description = "C-1";

    // 2.yöntem deconstruction yönetmi
    var vm2 = (product, category);
    vm2.category.Description = "C-3";

    string fname = GetNameInfo("Ali","Can").firstName;
    string lsName = GetNameInfo("Ali", "Can").lastName;

  }

  // Tupple Method kullanımı
  public static (string firstName, string lastName) GetNameInfo(string firstName, string lastName)
  {
    return (firstName, lastName);
  }

  public static void Regexx()
  {
    RegexSample.RegexExample();
  }

  public static void Serialization()
  {
    SerializationsSample.Sample();
  }
}








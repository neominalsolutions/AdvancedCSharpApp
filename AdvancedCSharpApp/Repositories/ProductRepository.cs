using AdvancedCSharpApp.Entities;
using AdvancedCSharpApp.SeedWork;
using Akedas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.Repositories
{
  public class ProductRepository : CrudRepository<Product, Guid>, IProductRepository
  {
    public IEnumerable<Product> FindByName(string name)
    {
      return Find().Where(x => x.Name == name).ToList();
    }

    public override void Create(Product entity)
    {
      Console.WriteLine("Product Repository Create");
      // Loglama işlemi yap.
      // Proxy Pattern benzer bir yapı kurduk.
      base.Create(entity);
    }
  }
}

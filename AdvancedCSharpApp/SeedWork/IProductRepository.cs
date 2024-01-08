using AdvancedCSharpApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.SeedWork
{
  public interface IProductRepository
  {
    IEnumerable<Product> FindByName(string name);
  }
}

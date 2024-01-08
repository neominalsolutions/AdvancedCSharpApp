using Akedas.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpApp.Extentions
{
  public static class SupplierExtentions
  {
    public static string GetSupplierInfo(this Supplier supplier)
    {
      return $"{supplier.Company}-{supplier.City}/{supplier.Country}";
    }
  }
}

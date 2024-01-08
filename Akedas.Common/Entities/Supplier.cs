using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Common.Entities
{
  public class Supplier
  {
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    [RegularExpression(@"^[A-Z]")]
    public string? Company { get; set; }


  }
}

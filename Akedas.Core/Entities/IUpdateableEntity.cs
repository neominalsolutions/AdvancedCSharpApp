using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
  public interface IUpdateableEntity
  {
    DateTime? UpdatedAt { get; set; }
    string? UpdatedBy { get; set; }
  }
}

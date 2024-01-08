using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
  public class UpdatableEntity<TKey> : EntityBase<TKey>, IUpdateableEntity
    where TKey : IComparable
  {
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
  }
}

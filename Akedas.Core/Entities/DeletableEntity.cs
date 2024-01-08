using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
  public abstract class DeletableEntity<TKey> : EntityBase<TKey>,IDeletableEntity where TKey : IComparable
  {
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
  }
}

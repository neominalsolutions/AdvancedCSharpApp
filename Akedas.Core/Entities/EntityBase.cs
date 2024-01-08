using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
  public abstract class EntityBase<TKey> where TKey:IComparable
  {
    public TKey Id { get; init; }
    public DateTime CreatedAt { get; init; }

  }
}

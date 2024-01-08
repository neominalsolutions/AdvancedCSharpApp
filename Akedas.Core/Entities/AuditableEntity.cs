using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
  public abstract class AuditableEntity<TKey> : EntityBase<TKey>, IDeletableEntity, IUpdateableEntity
    where TKey : IComparable
  {
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
  }
}

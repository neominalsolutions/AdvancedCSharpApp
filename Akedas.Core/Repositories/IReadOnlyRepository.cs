using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
    // TEntity:EntityBase<TKey>,new() Entity türesin ve abstract class olmasın
    public interface IReadOnlyRepository<TEntity, TKey>
      where TEntity : EntityBase<TKey>
      where TKey : IComparable
    {
        TEntity FindById(TKey key);
        IEnumerable<TEntity> Find();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

    }
}

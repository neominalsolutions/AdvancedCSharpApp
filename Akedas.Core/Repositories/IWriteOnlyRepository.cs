using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Core
{
    // stateless durum dçöndürmezler
    public interface IWriteOnlyRepository<TEntity, TKey>
      where TEntity : EntityBase<TKey>
      where TKey : IComparable
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey key);

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Akedas.Core
{
  public abstract class CrudRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>, 
    IWriteOnlyRepository<TEntity, TKey>
    where TEntity : EntityBase<TKey>
    where TKey : IComparable
  {
    private List<TEntity> entities;

    public CrudRepository()
    {
      entities = new List<TEntity>();
    }
    public virtual void Create(TEntity entity)
    {
      entities.Add(entity);
      Console.WriteLine("CrudRepository Create");
    }

    public virtual void Delete(TKey key)
    {
      var entity = FindById(key);
      entities.Remove(entity);
      Console.WriteLine("CrudRepository Delete");
    }

    public virtual IEnumerable<TEntity> Find()
    {
      Console.WriteLine("CrudRepository Find");
      return entities;
    }

    public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
    {
      Console.WriteLine("CrudRepository FindWhere");
      return entities.Where(predicate);
    }

    public virtual TEntity FindById(TKey key)
    {
      Console.WriteLine("CrudRepository FindById");
      return entities.Find(x=> x.Id.Equals(key));
    }

    public virtual void Update(TEntity entity)
    {

      var _findEntity = FindById(entity.Id);
      _findEntity = entity; // güncel nesne olarak referansı eşitlensin.

      var entityJsonString = JsonSerializer.Serialize<TEntity>(_findEntity);

      Console.WriteLine($"CrudRepository Update: {entityJsonString}");
    }
  }
}

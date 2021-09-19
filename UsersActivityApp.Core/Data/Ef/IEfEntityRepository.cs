using UsersActivityApp.Core.Data.Abstract;
using UsersActivityApp.Core.Entities;

namespace UsersActivityApp.Core.Data.Ef
{
  public interface IEfEntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
  {
  }
}

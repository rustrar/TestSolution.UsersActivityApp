using UsersActivityApp.Core.Data.Abstract;
using UsersActivityApp.Core.Entities;

namespace UsersActivityApp.Core.Data.Ef
{
  /// <summary>
  /// Интерфейс Entity Framework репозитория
  /// </summary>
  /// <typeparam name="TEntity">Тип сущности.</typeparam>
  public interface IEfEntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
  {
  }
}

using UsersActivityApp.Core.Data.Abstract;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.DataAccess.Abstract
{
  /// <summary>
  /// Интерфейс репозитория для работы с активностями пользователй.
  /// </summary>
  public interface IUserActivityRepository : IEntityRepository<UserActivity>
  {
  }
}

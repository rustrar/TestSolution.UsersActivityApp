using System.Collections.Generic;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.Business.Abstract
{
  /// <summary>
  /// Интерфейс сервиса для CRUD-операций с действиями пользователей.
  /// </summary>
  public interface IUserActivityService
  {
    /// <summary>
    /// Получить активность пользователя по ИД.
    /// </summary>
    /// <param name="id">ИД активности пользователя.</param>
    /// <returns>Активность пользователя.</returns>
    UserActivity Get(int id);

    /// <summary>
    /// Получить все активности пользователей.
    /// </summary>
    /// <returns>Список активностей пользователей.</returns>
    List<UserActivity> GetAll();

    /// <summary>
    /// Сохранить активность пользователя.
    /// </summary>
    /// <param name="userActivity">Активность пользователя.</param>
    void Add(UserActivity userActivity);

    /// <summary>
    /// Сохранить список активностей пользователей.
    /// </summary>
    /// <param name="userActivities">Список активностей пользователей.</param>
    void AddList(List<UserActivity> userActivities);

    /// <summary>
    /// Удалить активность пользователя по ИД.
    /// </summary>
    /// <param name="id">ИД активности пользователя.</param>
    void Delete(int id);
  }
}

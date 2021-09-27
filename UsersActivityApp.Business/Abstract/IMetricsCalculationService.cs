using System.Collections.Generic;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.Business.Abstract
{
  /// <summary>
  /// Интерфейс сервиса для расчета метрик.
  /// </summary>
  public interface IMetricsCalculationService
  {
    /// <summary>
    /// Рассчитать длительности жизни пользователей.
    /// </summary>
    /// <param name="userActivities">Список действий пользователей.</param>
    /// <returns>Список с длительностями жизни пользователей.</returns>
    decimal CalculateRR(IEnumerable<UserActivity> userActivities = null);

    /// <summary>
    /// Рассчитать Rolling Retention.
    /// </summary>
    /// <param name="userActivities">Список действий пользователей.</param>
    /// <returns>Rolling Retention в процентах.</returns>
    List<int> CalculateLT(IEnumerable<UserActivity> userActivities = null);
  }
}

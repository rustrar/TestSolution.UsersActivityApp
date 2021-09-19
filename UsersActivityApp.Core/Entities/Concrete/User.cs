using System;

namespace UsersActivityApp.Core.Entities.Concrete
{
  /// <summary>
  /// Пользователь системы.
  /// </summary>
  public class User : IEntity
  {
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Дата регистрации пользователя в системе.
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Дата последней активности пользователя в системе.
    /// </summary>
    public DateTime LastActivity { get; set; }
  }
}

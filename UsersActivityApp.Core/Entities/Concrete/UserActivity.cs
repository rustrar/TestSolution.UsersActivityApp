using System;
using System.ComponentModel.DataAnnotations;

namespace UsersActivityApp.Core.Entities.Concrete
{
  /// <summary>
  /// Активность пользователя системы.
  /// </summary>
  public class UserActivity : IEntity
  {
    #region Поля и свойства

    /// <summary>
    /// ИД активности пользователя.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    /// <summary>
    /// Дата регистрации пользователя в системе.
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Дата последней активности пользователя в системе.
    /// </summary>
    public DateTime? LastActivity { get; set; }

    #endregion

    #region Конструкторы

    public UserActivity(int userId, DateTime registrationDate, DateTime? lastActivity = null)
    {
      Id = userId;
      RegistrationDate = registrationDate;
      LastActivity = lastActivity;
    }

    public UserActivity()
    {
    }

    #endregion
  }
}

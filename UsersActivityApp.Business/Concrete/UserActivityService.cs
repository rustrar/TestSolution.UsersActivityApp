using System.Collections.Generic;
using UsersActivityApp.Business.Abstract;
using UsersActivityApp.Core.Entities.Concrete;
using UsersActivityApp.DataAccess.Abstract;

namespace UsersActivityApp.Business.Concrete
{
  /// <summary>
  /// Сервис для CRUD-операций с действиями пользователей.
  /// </summary>
  public class UserActivityService : IUserActivityService
  {
    #region Поля и свойства

    private readonly IUserActivityRepository _userRepository;

    #endregion

    #region Констукторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="userRepository">Репозиторий.</param>
    public UserActivityService(IUserActivityRepository userRepository)
    {
      _userRepository = userRepository;
    }

    #endregion

    #region Методы

    public void Add(UserActivity userActivity)
    {
      _userRepository.Add(userActivity);
    }

    public void AddList(List<UserActivity> userActivitiess)
    {
      _userRepository.AddList(userActivitiess);
    }

    public UserActivity Get(int id)
    {
      return _userRepository.Get(u => u.Id == id);
    }

    public List<UserActivity> GetAll()
    {
      return _userRepository.GetList();
    }

    public void Delete(int id)
    {
      _userRepository.Delete(id);
    }

    #endregion
  }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UsersActivityApp.Business.Abstract;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.WebApi.Controllers
{
  /// <summary>
  /// Контроллер для работы с активностями пользователей.
  /// </summary>
  [Route("api")]
  [ApiController]
  public class UserActivitiesController : ControllerBase
  {
    #region Поля и свойства

    private readonly IUserActivityService _service;

    #endregion

    #region Конструкторы

    /// <summary>
    /// Констуктор.
    /// </summary>
    /// <param name="service">Сервис для работы с активностями пользователей.</param>
    public UserActivitiesController(IUserActivityService service)
    {
        _service = service;
    }

    #endregion

    #region Методы

    /// <summary>
    /// Получить все активности пользователей.
    /// </summary>
    /// <returns>Список активностей пользователей.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<UserActivity>> GetUserActivities()
    {
      return _service.GetAll();
    }

    /// <summary>
    /// Добавить активности пользователей.
    /// </summary>
    /// <param name="userActivities">Список активностей пользователей для добавления.</param>
    /// <returns>OkResult.</returns>
    [HttpPost("useractivities")]
    public ActionResult PostUserActivities(List<UserActivity> userActivities)
    {
      _service.AddList(userActivities);
      return Ok();
    }

    /// <summary>
    /// Добавить активность пользователя.
    /// </summary>
    /// <param name="userActivities">Активность пользователя для добавления.</param>
    /// <returns>OkResult.</returns>
    [HttpPost("useractivity")]
    public ActionResult PostUserActivity(UserActivity userActivity)
    {
      _service.Add(userActivity);
      return Ok();
    }

    /// <summary>
    /// Удалить активность пользователя по ИД.
    /// </summary>
    /// <param name="id">ИД активности пользователя.</param>
    /// <returns>OkResult.</returns>
    [HttpDelete("useractivity/{id}")]
    public ActionResult DeleteUserActivity(int id)
    {
      _service.Delete(id);
      return Ok();
    }

    #endregion
  }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UsersActivityApp.Business.Abstract;

namespace UsersActivityApp.WebApi.Controllers
{
  /// <summary>
  /// Контроллер для расчета метрик.
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class CalculateMetricsController : ControllerBase
  {
    #region Поля и свойства

    private readonly IMetricsCalculationService _service;

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="service">Сервис для расчета метрик.</param>
    public CalculateMetricsController(IMetricsCalculationService service)
    {
      _service = service;
    }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать Rolling Retention.
    /// </summary>
    /// <returns>Значение Rolling Retention в процентах.</returns>
    [HttpGet("rollingretention")]
    public ActionResult<decimal> CalculateRR()
    {
      return _service.CalculateRR();
    }

    /// <summary>
    /// Рассчитать длительность жизни пользователей.
    /// </summary>
    /// <returns>Список с длительностями жизни пользователей.</returns>
    [HttpGet("lifetime")]
    public ActionResult<List<int>> CalculateLT()
    {
      return _service.CalculateLT();
    }

    #endregion
  }
}

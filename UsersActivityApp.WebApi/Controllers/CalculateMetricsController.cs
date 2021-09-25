using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UsersActivityApp.Business.Abstract;

namespace UsersActivityApp.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CalculateMetricsController : ControllerBase
  {
    private readonly IMetricsCalculationService _service;

    public CalculateMetricsController(IMetricsCalculationService service)
    {
      _service = service;
    }

    //GET: api/Calculate
    [HttpGet("rollingretention")]
    public ActionResult<decimal> CalculateRR()
    {
      return _service.CalculateRR();
    }

    //GET: api/Calculate
    [HttpGet("lifetime")]
    public ActionResult<List<int>> CalculateLT()
    {
      return _service.CalculateLT();
    }
  }
}

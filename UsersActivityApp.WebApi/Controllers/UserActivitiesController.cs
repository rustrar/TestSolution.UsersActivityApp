using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UsersActivityApp.Business.Abstract;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserActivitiesController : ControllerBase
  {
    private readonly IUserActivityService _service;

    public UserActivitiesController(IUserActivityService service)
    {
        _service = service;
    }

    //GET: api/UserActivities
    [HttpGet]
    public ActionResult<IEnumerable<UserActivity>> GetUserActivities()
    {
      return _service.GetAll();
    }

    // POST: api/UserActivities
    [HttpPost]
    public ActionResult<bool> PostUserActivities(List<UserActivity> userActivities)
    {
      _service.AddList(userActivities);
      return true;
    }
  }
}

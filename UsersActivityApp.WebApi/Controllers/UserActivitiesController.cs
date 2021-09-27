using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UsersActivityApp.Business.Abstract;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.WebApi.Controllers
{
  [Route("api")]
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
    [HttpPost("useractivities")]
    public ActionResult PostUserActivities(List<UserActivity> userActivities)
    {
      _service.AddList(userActivities);
      return Ok();
    }

    // POST: api/UserActivity
    [HttpPost("useractivity")]
    public ActionResult PostUserActivity(UserActivity userActivity)
    {
      _service.Add(userActivity);
      return Ok();
    }

    // DELETE: api/UserActivity
    [HttpDelete("useractivity/{id}")]
    public ActionResult DeleteUserActivity(int id)
    {
      _service.Delete(id);
      return Ok();
    }
  }
}

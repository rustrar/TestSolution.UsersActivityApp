using System.Collections.Generic;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.Business.Abstract
{
  public interface IUserActivityService
  {
    UserActivity Get(int userId);
    List<UserActivity> GetAll();
    void Add(UserActivity user);

    void AddList(List<UserActivity> users);
  }
}

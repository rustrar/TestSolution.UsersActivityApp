using UsersActivityApp.Core.Data.Abstract;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.DataAccess.Abstract
{
  public interface IUserActivityRepository : IEntityRepository<UserActivity>
  {
  }
}

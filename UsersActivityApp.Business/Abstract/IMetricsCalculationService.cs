using System.Collections.Generic;
using UsersActivityApp.Core.Entities.Concrete;

namespace UsersActivityApp.Business.Abstract
{
  public interface IMetricsCalculationService
  {
    decimal CalculateRR(IEnumerable<UserActivity> userActivities = null);

    List<int> CalculateLT(IEnumerable<UserActivity> userActivities = null);
  }
}

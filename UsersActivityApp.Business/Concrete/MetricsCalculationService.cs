using System;
using System.Collections.Generic;
using System.Linq;
using UsersActivityApp.Business.Abstract;
using UsersActivityApp.Core.Entities.Concrete;
using UsersActivityApp.DataAccess.Abstract;

namespace UsersActivityApp.Business.Concrete
{
  public class MetricsCalculationService : IMetricsCalculationService
  {
    private IEnumerable<UserActivity> _userActivities;
    private readonly IUserActivityRepository _userRepository;    
    private readonly int dayN = 7;
    private readonly int percent = 100;

    public MetricsCalculationService(IUserActivityRepository userRepository)
    {
      _userRepository = userRepository;
      _userActivities = new List<UserActivity>();
    }

    public List<int> CalculateLT(IEnumerable<UserActivity> userActivities = null)
    {
      InitUserActivities(userActivities);

      return _userActivities
        .Where(x => x.LastActivity != null)
        .Select(x => (x.LastActivity - x.RegistrationDate).Value.Days)
        .ToList();
    }

    public decimal CalculateRR(IEnumerable<UserActivity> userActivities = null)
    {
      InitUserActivities(userActivities);
            
      try
      {
        var percentage = ( GetLastLogFor() / GetRegisteredDaysAgo() ) * percent;
        return Math.Round(percentage);
      }
      catch (DivideByZeroException)
      {
        return 0;
      }
    }

    private decimal GetLastLogFor()
    {
      return (decimal)_userActivities.Where(x =>  
        x.LastActivity != null &&
        (x.LastActivity - x.RegistrationDate).Value.Days >= dayN)
        .Count();
    }

    private decimal GetRegisteredDaysAgo()
    {
      return (decimal)_userActivities.Where(x => 
        (DateTime.Now - x.RegistrationDate).Days >= dayN)
        .Count();
    }

    private void InitUserActivities(IEnumerable<UserActivity> userActivities = null)
    {
      if (userActivities == null || userActivities.Count() == 0)
        _userActivities = _userRepository.GetList();
      else
        _userActivities = userActivities;        
    }
  }
}

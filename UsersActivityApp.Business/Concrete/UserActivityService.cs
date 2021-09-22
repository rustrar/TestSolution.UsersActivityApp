using System;
using System.Collections.Generic;
using UsersActivityApp.Business.Abstract;
using UsersActivityApp.Core.Entities.Concrete;
using UsersActivityApp.DataAccess.Abstract;

namespace UsersActivityApp.Business.Concrete
{
  public class UserActivityService : IUserActivityService
  {
    private readonly IUserActivityRepository _userRepository;

    public UserActivityService(IUserActivityRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public void Add(UserActivity user)
    {
      _userRepository.Add(user);
    }

    public void AddList(List<UserActivity> users)
    {
      _userRepository.AddList(users);
    }

    public UserActivity Get(int userId)
    {
      return _userRepository.Get(u => u.Id == userId);
    }

    public List<UserActivity> GetAll()
    {
      return _userRepository.GetList();
    }
  }
}

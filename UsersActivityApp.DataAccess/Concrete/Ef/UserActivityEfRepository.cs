using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UsersActivityApp.Core.Data.Ef;
using UsersActivityApp.Core.Entities.Concrete;
using UsersActivityApp.DataAccess.Abstract;

namespace UsersActivityApp.DataAccess.Concrete.Ef
{
  public class UserActivityEfRepository : IEfEntityRepository<UserActivity>, IUserActivityRepository
  {
    private UsersActivityDbContext _context;
    public UserActivityEfRepository(UsersActivityDbContext context)
    {
      _context = context;
    }

    public void Add(UserActivity entity)
    {
      UserActivity dbEntry = Get(x => x.Id == entity.Id);
      if (dbEntry == null)
        _context.UserActivities.Add(entity);
      else
      {
        Update(entity);
      }
      
      _context.SaveChanges();
    }

    public void AddList(List<UserActivity> entities)
    {
      foreach (var entity in entities)
      {
        Add(entity);
      }
      //_context.UserActivities.AddRange(entities);
      //_context.SaveChanges();
    }

    public UserActivity Get(Expression<Func<UserActivity, bool>> filter)
    {
      return _context.UserActivities.SingleOrDefault(filter);
    }

    public List<UserActivity> GetList(Expression<Func<UserActivity, bool>> filter = null)
    {
      return _context.UserActivities.ToList();
    }

    public void Update(UserActivity entity)
    {
      _context.UserActivities.Update(entity);
      _context.SaveChanges();
    }
  }
}

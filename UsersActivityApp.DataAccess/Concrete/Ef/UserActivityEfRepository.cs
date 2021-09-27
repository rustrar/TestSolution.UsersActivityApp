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
  /// <summary>
  /// Репозиторий для работы с активностями пользователей.
  /// </summary>
  public class UserActivityEfRepository : IEfEntityRepository<UserActivity>, IUserActivityRepository
  {
    #region Поля и свойства

    private UsersActivityDbContext _context;

    #endregion

    #region Конструкторы

    public UserActivityEfRepository(UsersActivityDbContext context)
    {
      _context = context;
    }

    #endregion

    #region Методы

    public void Add(UserActivity entity)
    {
      var dbEntry = Get(x => x.Id == entity.Id);
      if (dbEntry == null)
        _context.UserActivities.Add(entity);
      else
      {
        _context.Entry(dbEntry).State = EntityState.Detached;
        Update(entity);
      }
      
      _context.SaveChanges();
    }

    public void AddList(List<UserActivity> entities)
    {
      foreach (var entity in entities)
        Add(entity);
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

    public void Delete(int id)
    {
      var dbEntry = _context.UserActivities.FirstOrDefault(x => x.Id == id);
      if (dbEntry == null)
        return;

      _context.UserActivities.Remove(dbEntry);
      _context.SaveChanges();
    }

    #endregion
  }
}

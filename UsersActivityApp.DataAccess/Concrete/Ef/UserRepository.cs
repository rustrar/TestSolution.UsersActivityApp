using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UsersActivityApp.Core.Data.Ef;
using UsersActivityApp.Core.Entities.Concrete;
using UsersActivityApp.DataAccess.Abstract;

namespace UsersActivityApp.DataAccess.Concrete.Ef
{
  public class UserRepository : IEfEntityRepository<User>, IUserRepository
  {
    public User Add(User entity)
    {
      throw new NotImplementedException();
    }

    public User AddList(List<User> entities)
    {
      throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
      throw new NotImplementedException();
    }

    public User Get(Expression<Func<User, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public List<User> GetList(Expression<Func<User, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public User Update(User entity)
    {
      throw new NotImplementedException();
    }
  }
}

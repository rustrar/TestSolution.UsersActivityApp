using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UsersActivityApp.Core.Entities;

namespace UsersActivityApp.Core.Data.Abstract
{
  public interface IEntityRepository<T> where T : class, IEntity, new()
  {
    T Get(Expression<Func<T, bool>> filter);

    List<T> GetList(Expression<Func<T, bool>> filter = null);

    T Add(T entity);

    T AddList(List<T> entities);

    T Update(T entity);

    void Delete(T entity);
  }
}
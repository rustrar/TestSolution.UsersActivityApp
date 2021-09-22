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

    void Add(T entity);

    void AddList(List<T> entities);

    void Update(T entity);
  }
}
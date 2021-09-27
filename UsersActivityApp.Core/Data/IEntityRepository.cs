using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UsersActivityApp.Core.Entities;

namespace UsersActivityApp.Core.Data.Abstract
{
  /// <summary>
  /// Generic репозиторий.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  public interface IEntityRepository<T> where T : class, IEntity, new()
  {
    /// <summary>
    /// Получить сущность.
    /// </summary>
    /// <param name="filter">Фильтр для получения сущности.</param>
    /// <returns>Сущность.</returns>
    T Get(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Получить список сущностей.
    /// </summary>
    /// <param name="filter">Фильтр для получения списка сущностей.</param>
    /// <returns>Список сущностей.</returns>
    List<T> GetList(Expression<Func<T, bool>> filter = null);

    /// <summary>
    /// Добавить сущность.
    /// </summary>
    /// <param name="entity">Сущность для добавления.</param>
    void Add(T entity);

    /// <summary>
    /// Добавить список сущностей.
    /// </summary>
    /// <param name="entities">Список сущностей для добавления.</param>
    void AddList(List<T> entities);

    /// <summary>
    /// Изменить сущность.
    /// </summary>
    /// <param name="entity">Сущность для изменения</param>
    void Update(T entity);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="id">ИД сущности для удаления.</param>
    void Delete(int id);
  }
}
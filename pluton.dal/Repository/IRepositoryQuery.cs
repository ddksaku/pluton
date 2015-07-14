using System;
using System.Linq;
using System.Linq.Expressions;
using Mars.Common.Repositories;

namespace pluton.dal.Repository
{
    public interface IRepositoryQuery<TEntity> where TEntity : class,IEntity
    {
        /// <summary>
        /// Количество сущностей
        /// </summary>
        /// <returns></returns>
        long Count();

        /// <summary>
        /// Установить фильтр
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IRepositoryQuery<TEntity> Filter(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Дополнительный фильтр с возможностью указания expressions
        /// </summary>
        /// <param name="whereFilter"></param>
        /// <returns></returns>
        IRepositoryQueryOrdered<TEntity> WhereFilter(Func<IQueryable<TEntity>, IQueryable<TEntity>> whereFilter);

        /// <summary>
        /// Установить порядок сортировки
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        IRepositoryQueryOrdered<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        /// <summary>
        /// Указать загрузку связанных сущностей
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IRepositoryQuery<TEntity> Include(Expression<Func<TEntity, object>> expression);

        /// <summary>
        /// Связанные сущности черезс троку
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IRepositoryQuery<TEntity> Include(string expression);

        /// <summary>
        /// Включать удаленные сущности в выборку
        /// </summary>
        /// <returns></returns>
        IRepositoryQuery<TEntity> WithDeleted();
        /// <summary>
        /// Запросить сущности
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Get();

        /// <summary>
        /// Запросить сущности
        /// </summary>
        /// <returns></returns>
        TEntity GetOne();

        /// <summary>
        /// SQL запрос
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pluton.dal.Repository;

namespace Mars.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : class,IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid InstanceId { get; }

        /// <summary>
        /// Поиск сущности по ключу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(object id);

        /// <summary>
        /// SQL запрос
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity"></param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Добавление коллекции сущностей
        /// </summary>
        /// <param name="entities"></param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновление сущности в хранилище
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="force"></param>
        void Delete(TEntity entity, bool force=false);

        /// <summary>
        /// QueryHelper
        /// </summary>
        /// <returns></returns>
        IRepositoryQuery<TEntity> Query();
    }
}

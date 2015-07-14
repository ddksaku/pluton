using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common.Repositories;

namespace Mars.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid InstanceId { get; }

        /// <summary>
        /// Получить репозиторий сущности
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class,IEntity;
        /// <summary>
        /// Репозиторий из инстанса
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        IRepository<TEntity> Repository<TEntity>(TEntity instance) where TEntity : class, IEntity;
        /// <summary>
        /// Завершить операцию
        /// </summary>
        void Commit();
    }
}

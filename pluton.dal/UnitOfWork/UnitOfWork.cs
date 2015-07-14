using System;
using System.Collections;
using System.Data.Entity;
using System.Transactions;
using Mars.Common;
using Mars.Common.Repositories;
using Mars.Common.UnitOfWork;
using pluton.dal.Repository;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace pluton.dal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly object _syncObject = new object();
        private readonly DbContext _context;
        private readonly Guid _instanceId;
        private bool _disposed;
        private Hashtable _repositories;
        private TransactionScope _transaction;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid InstanceId
        {
            get { return _instanceId; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DbContext context)
        {
            //context.Database.Log = x => Debug.Write(x);
            _context = context;
            _instanceId = IdentityGenerator.NewSequentialGuid();
        }

        /// <summary>
        /// Констурктор с транзакцией
        /// </summary>
        /// <param name="context"></param>
        /// <param name="isolationLevel"></param>
        public UnitOfWork(DbContext context, IsolationLevel isolationLevel)
            : this(context)
        {
            _transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = isolationLevel });
        }

        /// <summary>
        /// Завершить операцию
        /// </summary>
        public void Commit()
        {
            lock (_syncObject)
            {
                _context.SaveChanges();

                if (_transaction != null)
                    _transaction.Complete();
            }
        }

        /// <summary>
        /// Получить репозиторий сущности
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            lock (_syncObject)
            {
                if (_repositories == null)
                    _repositories = new Hashtable();

                string type = typeof(TEntity).Name;
                if (_repositories.ContainsKey(type))
                    return (IRepository<TEntity>)_repositories[type];

                _repositories.Add(type, new Repository<TEntity>(_context, _syncObject));

                return (IRepository<TEntity>)_repositories[type];
            }
        }

        public IRepository<TEntity> Repository<TEntity>(TEntity type) where TEntity : class, IEntity
        {
            return Repository<TEntity>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}

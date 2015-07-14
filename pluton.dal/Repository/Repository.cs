using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Mars.Common;
using Mars.Common.Repositories;

namespace pluton.dal.Repository
{
    /// <summary>
    /// Репозиторий сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class,IEntity
    {
        private readonly object _syncObject;
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly Guid _instanceId;

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="context"></param>
        /// <param name="syncObject"></param>
        public Repository(DbContext context, object syncObject = null)
        {
            _syncObject = syncObject ?? new object();
            _context = context;
            _dbSet = context.Set<TEntity>();
            _instanceId = IdentityGenerator.NewSequentialGuid();
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid InstanceId
        {
            get { return _instanceId; }
        }

        /// <summary>
        /// Поиск сущности по ключу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            TEntity result;
            lock (_syncObject)
            {
                result = _dbSet.Find(id);
            }
            return result;
        }

        /// <summary>
        /// Количество сущностей
        /// </summary>
        /// <returns></returns>
        internal long Count(
            Expression<Func<TEntity, bool>> filter = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => query = query.Include(i));

            return filter != null ? query.Count(filter) : query.Count();
        }

        /// <summary>
        /// SQL запрос
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> SqlQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity"></param>
        public virtual TEntity Insert(TEntity entity)
        {
            lock (_syncObject)
                return _dbSet.Add(entity);
        }

        /// <summary>
        /// Добавление коллекции сущностей
        /// </summary>
        /// <param name="entities"></param>
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.ValidateOnSaveEnabled = false;

            lock (_syncObject)
                _dbSet.AddRange(entities);

            _context.Configuration.AutoDetectChangesEnabled = true;
            _context.Configuration.ValidateOnSaveEnabled = true;
        }

        /// <summary>
        /// Обновление сущности в хранилище
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            lock (_syncObject)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="force"></param>
        public virtual void Delete(TEntity entity, bool force = false)
        {
            lock (_syncObject)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                if (!force)
                {
                    entity.IsDeleted = true;
                    Update(entity);
                }
                else
                {
                    _dbSet.Remove(entity);
                }
            }
        }


        /// <summary>
        /// QueryHelper
        /// </summary>
        /// <returns></returns>
        public virtual IRepositoryQuery<TEntity> Query()
        {
            var repositoryGetFluentHelper = new RepositoryQuery<TEntity>(this, _syncObject);
            return repositoryGetFluentHelper;
        }

        /// <summary>
        /// Получить сущности по запросу
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="whereFilter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="inclideStringParameters"></param>
        /// <param name="withDeleted"></param>
        /// <returns></returns>
        internal IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> whereFilter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null, List<string> inclideStringParameters = null, bool withDeleted = false)
        {

            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => query = query.Include(i));

            if (inclideStringParameters != null)
                inclideStringParameters.ForEach(i => query.Include(i));

            if (filter != null)
                query = query.Where(filter);

            if (whereFilter != null)
            {
                query = whereFilter(query);
            }

            if (!withDeleted)
                query = query.Where(x => !x.IsDeleted);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;

        }
    }
}

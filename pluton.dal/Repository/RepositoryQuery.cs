using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using pluton.dal.Repository;

namespace Mars.Common.Repositories
{
    public class RepositoryQuery<TEntity> : IRepositoryQuery<TEntity>, IRepositoryQueryOrdered<TEntity>
        where TEntity : class,IEntity
    {
        private readonly object _syncObject;
        private readonly List<Expression<Func<TEntity, object>>> _includeProperties;
        private readonly List<string> _includeStringProperties;
        private readonly Repository<TEntity> _repository;
        private Expression<Func<TEntity, bool>> _filter;
        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> _orderByQuerable;
        private Func<IQueryable<TEntity>, IQueryable<TEntity>> _whereFilter;
        private int? _page;
        private int? _pageSize;
        private bool _withDeleted;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="syncObject"></param>
        public RepositoryQuery(Repository<TEntity> repository, object syncObject)
        {
            _syncObject = syncObject;
            _repository = repository;
            _includeProperties = new List<Expression<Func<TEntity, object>>>();
            _includeStringProperties = new List<string>();
            _withDeleted = false;
        }

        /// <summary>
        /// Установить фильтр
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IRepositoryQuery<TEntity> Filter(Expression<Func<TEntity, bool>> filter)
        {
            _filter = filter;
            return this;
        }

        /// <summary>
        /// Установить порядок сортировки
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IRepositoryQueryOrdered<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            _orderByQuerable = orderBy;
            return this;
        }

        /// <summary>
        /// Дополнительный фильтр с возможностью указания expressions
        /// </summary>
        /// <param name="whereFilter"></param>
        /// <returns></returns>
        public IRepositoryQueryOrdered<TEntity> WhereFilter(Func<IQueryable<TEntity>, IQueryable<TEntity>> whereFilter)
        {
            _whereFilter = whereFilter;
            return this;
        }


        /// <summary>
        /// Указать загрузку связанных сущностей
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IRepositoryQuery<TEntity> Include(Expression<Func<TEntity, object>> expression)
        {
            _includeProperties.Add(expression);
            return this;
        }

        public IRepositoryQuery<TEntity> Include(string expression)
        {
            _includeStringProperties.Add(expression);
            return this;
        }

        public IRepositoryQuery<TEntity> WithDeleted()
        {
            _withDeleted = true;
            return this;
        }

        /// <summary>
        /// Количество сущностей
        /// </summary>
        /// <returns></returns>
        public long Count()
        {
            lock (_syncObject)
                return _repository.Count(_filter, _includeProperties);
        }

        /// <summary>
        /// Запросить страницу
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetPage(int page, int pageSize, out int totalCount)
        {
            _page = page;
            _pageSize = pageSize;
            totalCount = _repository.Get(_filter).Count();

            lock (_syncObject)
                return _repository.Get(_filter, _whereFilter, _orderByQuerable, _includeProperties, _page, _pageSize);
        }

        /// <summary>
        /// Запросить сущности
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> Get()
        {
            lock (_syncObject)
                return _repository.Get(_filter, _whereFilter, _orderByQuerable, _includeProperties, _page, _pageSize, _includeStringProperties, _withDeleted);
        }

        public TEntity GetOne()
        {
            lock (_syncObject)
                return _repository.Get(_filter, _whereFilter, _orderByQuerable, _includeProperties, _page, _pageSize, _includeStringProperties).FirstOrDefault();
        }

        /// <summary>
        /// SQL запрос
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<TEntity> SqlQuery(string query, params object[] parameters)
        {
            lock (_syncObject)
                return _repository.SqlQuery(query, parameters).AsQueryable();
        }
    }
}

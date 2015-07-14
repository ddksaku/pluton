using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pluton.dal.Repository;

namespace Mars.Common.Repositories
{
    public interface IRepositoryQueryOrdered<TEntity> : IRepositoryQuery<TEntity> where TEntity : class,IEntity
    {
        /// <summary>
        /// Запросить страницу
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetPage(int page, int pageSize, out int totalCount);
    }
}

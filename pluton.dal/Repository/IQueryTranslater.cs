using System.Linq;

namespace pluton.dal.Repository
{
    /// <summary>
    /// Query helper functions(for example translate order by nested property name to usual entity query)
    /// </summary>
    public interface IQueryTranslater
    {
        IOrderedQueryable<TModel> OrderByPropName<TModel>(IQueryable<TModel> q, string propertyName, bool ask);

        IQueryable<TModel> AlphaFilter<TModel>(IQueryable<TModel> q, string propertyName, string beginning);

        IQueryable<TModel> PropertyFilter<TModel>(IQueryable<TModel> q, string propertyName, object value);
    }
}
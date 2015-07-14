using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace pluton.dal.Repository
{
    /// <summary>
    /// Query helper functions(for example translate order by nested property name to usual entity query)
    /// </summary>
    public class QueryTranslater : IQueryTranslater
    {
        private Tuple<ParameterExpression, MemberExpression> GetNestedParameterExpr(Type rootType, string propName)
        {
            ParameterExpression pe = Expression.Parameter(rootType);

            MemberExpression currentProperty = propName.Split('.')
                .Aggregate<string, MemberExpression>(null, (current, prop) => current == null ? Expression.Property(pe, prop) : Expression.Property(current, prop));

            return new Tuple<ParameterExpression, MemberExpression>(pe, currentProperty);
        }

        public IOrderedQueryable<TModel> OrderByPropName<TModel>(IQueryable<TModel> q, string propertyName, bool ask)
        {
            var propExpr = GetNestedParameterExpr(typeof(TModel), propertyName);

            MethodInfo m = typeof(QueryTranslater).GetMethod("OrderByProperty", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(typeof(TModel), propExpr.Item2.Type);
            return (IOrderedQueryable<TModel>)m.Invoke(this, new object[] { q, propExpr, ask });
        }

        private IOrderedQueryable<TModel> OrderByProperty<TModel, TRet>(IQueryable<TModel> q, Tuple<ParameterExpression, MemberExpression> propertyExpr, bool ask)
        {
            Expression se = Expression.Convert(propertyExpr.Item2, propertyExpr.Item2.Type);
            var expr = Expression.Lambda<Func<TModel, TRet>>(se, propertyExpr.Item1);

            return ask
                       ? q.OrderBy(expr)
                       : q.OrderByDescending(expr);
        }

        public IQueryable<TModel> AlphaFilter<TModel>(IQueryable<TModel> q, string propertyName, string beginning)
        {
            var propExpr = GetNestedParameterExpr(typeof(TModel), propertyName);
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var beginFrom = Expression.Constant(beginning, typeof(string));

            var methodCall = Expression.Call(propExpr.Item2, containsMethod, new Expression[] { beginFrom });

            return q.Where(Expression.Lambda<Func<TModel, bool>>(methodCall, propExpr.Item1));
        }

        public IQueryable<TModel> PropertyFilter<TModel>(IQueryable<TModel> q, string propertyName, object value)
        {
            var propExpr = GetNestedParameterExpr(typeof(TModel), propertyName);

            var eqMethod = propExpr.Item2.Type.GetMethod("Equals", new[] { propExpr.Item2.Type });
            var val = Expression.Constant(value, propExpr.Item2.Type);
            
            var methodCall = Expression.Call(propExpr.Item2, eqMethod, new Expression[] { val });

            return q.Where(Expression.Lambda<Func<TModel, bool>>(methodCall, propExpr.Item1));
        }
    }
}
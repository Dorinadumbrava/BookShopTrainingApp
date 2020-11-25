using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookShopTrainingApp.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;
        }
    }
}
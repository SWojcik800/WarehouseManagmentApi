using System.Linq.Expressions;

namespace WarehouseManagment.Common.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> collection, bool condition, Expression<Func<T, bool>> predicate)
            => condition
            ? collection.Where(predicate)
            : collection;

        public static IQueryable<T> AddFilterIfNotNullOrEmpty<T>(this IQueryable<T> collection, string? property, Expression<Func<T, bool>> predicate)
            => !string.IsNullOrEmpty(property)
            ? collection.Where(predicate)
            : collection;
    }
}

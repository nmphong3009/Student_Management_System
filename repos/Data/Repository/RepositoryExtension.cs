using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Order by the IQueryable result
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="query">source query <c>IQueryable</c></param>
        /// <param name="propertyName">the column need order</param>
        /// <param name="direction">the order direction</param>
        /// <returns></returns>
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName, string direction = EFConstants.OrderDirection.ASC)
        {
            if (string.IsNullOrEmpty(propertyName)) propertyName = "Id";
            //var name = direction.ToLower() == "asc" ? "OrderBy" : "OrderByDescending";
            var entityType = typeof(TSource);
            var propertyInfo = entityType.GetProperty(propertyName);
            var arg = Expression.Parameter(entityType, "x");
            var property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            var enumerableType = typeof(Queryable);
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == direction && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();
                    return parameters.Count == 2;
                }).FirstOrDefault();

            var genericMethod = method?.MakeGenericMethod(entityType, propertyInfo?.PropertyType);
            var newQuery = (IOrderedQueryable<TSource>)genericMethod?.Invoke(genericMethod, new object[] { query, selector });

            return newQuery;
        }

        public static IOrderedQueryable<T> OrderByColumn<T>(this IQueryable<T> source, string columnPath)
        => source.OrderBy(columnPath, "OrderBy");

        public static IOrderedQueryable<T> OrderByColumnDescending<T>(this IQueryable<T> source, string columnPath)
            => source.OrderBy(columnPath, "OrderByDescending");

        public static IOrderedQueryable<T> ThenByColumn<T>(this IOrderedQueryable<T> source, string columnPath)
            => source.OrderBy(columnPath, "ThenBy");

        public static IOrderedQueryable<T> ThenByColumnDescending<T>(this IOrderedQueryable<T> source, string columnPath)
            => source.OrderBy(columnPath, "ThenByDescending");
    }
}
    

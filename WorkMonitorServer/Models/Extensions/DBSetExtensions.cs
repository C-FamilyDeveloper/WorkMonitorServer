using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace WorkMonitorServer.Models.Extensions
{
    public static class DBSetExtensions
    {
        public static T AddIfNotExist<T>(this DbSet<T> set, T entity, Expression<Func<T,bool>> predicate) where T : class
        {
            bool isinset = set.Any(predicate);
            if (!isinset)
            {
                set.Add(entity);
            }
            return set.Find(predicate)!;
        }
        public static async Task<T> AddIfNotExistAsync<T>(this DbSet<T> set, T entity, Expression<Func<T, bool>> predicate) where T : class
        {
            bool isinset = set.Any(predicate);
            if (!isinset)
            {
                await set.AddAsync(entity);
            }
            return await set.FindAsync(predicate)!;
        }
    }
}

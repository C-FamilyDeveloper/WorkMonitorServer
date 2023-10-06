using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.DAL.DataEntities;

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
            return set.Where(predicate).First();
        }
        public static async Task<T> AddIfNotExistAsync<T>(this DbSet<T> set, T entity, Expression<Func<T, bool>> predicate) where T : class
        {
            bool isinset = set.Any(predicate);
            if (!isinset)
            {
                await set.AddAsync(entity);
            }
            return await set.Where(predicate).FirstAsync();
        }
        public static async Task<bool> IsClientExistsAsync(this DbSet<Client> set, string clientName)
        {
            return await set.AsNoTracking().AnyAsync(i => i.Name == clientName);
        }

    }
}

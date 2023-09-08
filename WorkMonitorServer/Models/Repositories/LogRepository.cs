using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContexts;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;

namespace WorkMonitorServer.Models.Repositories
{
    public class LogRepository : IBaseRepository<Log>
    {
        private ApplicationContext context;
        public LogRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Add(Log entity)
        {
            await context.Logs.AddAsync(entity);
        }
        public void Update(Log entity)
        {
            context.Logs.Update(entity);
        }

        public void Delete(Log entity)
        {
            context.Logs.Remove(entity);
        }


        public async Task<List<Log>> Get()
        {
            return await context.Logs.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}

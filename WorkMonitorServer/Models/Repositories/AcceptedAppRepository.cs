using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContextes;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;

namespace WorkMonitorServer.Models.Repositories
{
    public class AcceptedAppRepository : IBaseRepository<AcceptedApp>
    {
        private ApplicationContext context;
        public AcceptedAppRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Add(AcceptedApp entity)
        {
            await context.AcceptedApps.AddAsync(entity);
        }
        public void Update(AcceptedApp entity)
        {
            context.AcceptedApps.Update(entity);
        }

        public void Delete(AcceptedApp entity)
        {
            context.AcceptedApps.Remove(entity);
        }


        public async Task<List<AcceptedApp>> Get()
        {
            return await context.AcceptedApps.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}

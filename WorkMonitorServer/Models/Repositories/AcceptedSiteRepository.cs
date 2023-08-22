using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContextes;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;

namespace WorkMonitorServer.Models.Repositories
{
    public class AcceptedSiteRepository : IBaseRepository<AcceptedSite>
    {
        private ApplicationContext context;
        public AcceptedSiteRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Add(AcceptedSite entity)
        {
            await context.AcceptedSites.AddAsync(entity);
        }
        public void Update(AcceptedSite entity)
        {
            context.AcceptedSites.Update(entity);
        }

        public void Delete(AcceptedSite entity)
        {
            context.AcceptedSites.Remove(entity);
        }


        public async Task<List<AcceptedSite>> Get()
        {
            return await context.AcceptedSites.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContextes;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;

namespace WorkMonitorServer.Models.Repositories
{
    public class ActivityRepository : IBaseRepository<Activity>
    {
        private ApplicationContext context;
        public ActivityRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Add(Activity entity)
        {
            await context.Activities.AddAsync(entity);
        }
        public void Update(Activity entity)
        {
            context.Activities.Update(entity);
        }

        public void Delete(Activity entity)
        {
            context.Activities.Remove(entity);
        }


        public async Task<List<Activity>> Get()
        {
            return await context.Activities.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}

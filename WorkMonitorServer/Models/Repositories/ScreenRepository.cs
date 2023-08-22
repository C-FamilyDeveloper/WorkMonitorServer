using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContextes;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;

namespace WorkMonitorServer.Models.Repositories
{
    public class ScreenRepository : IBaseRepository<Screen>
    {
        private ApplicationContext context;
        public ScreenRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Add(Screen entity)
        {
            await context.Screens.AddAsync(entity);  
        }
        public void Update(Screen entity)
        {
            context.Screens.Update(entity);
        }

        public void Delete(Screen entity)
        {
            context.Screens.Remove(entity);
        }


        public async Task<List<Screen>> Get()
        {
            return await context.Screens.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }       
    }
}

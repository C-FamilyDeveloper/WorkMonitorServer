using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContextes;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;

namespace WorkMonitorServer.Models.Repositories
{
    public class ClientRepository : IBaseRepository<Client>
    {
        private ApplicationContext context;
        public ClientRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Add(Client entity)
        {
            await context.Clients.AddAsync(entity);
        }
        public void Update(Client entity)
        {
            context.Clients.Update(entity);
        }

        public void Delete(Client entity)
        {
            context.Clients.Remove(entity);
        }


        public async Task<List<Client>> Get()
        {
            return await context.Clients.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}

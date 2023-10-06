using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;

namespace WorkMonitorServer.Models.Services.CRUDServices
{
    public class ClientService
    {
        private readonly ApplicationContext applicationContext;

        public ClientService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public async Task<bool> IsClientExistsAsync(string clientName)
        {
            return await applicationContext.Clients.AsNoTracking().AnyAsync(i => i.Name == clientName);
        }
        public async Task<List<string>?> GetClientsNamesAsync()
        {
            return await applicationContext.Clients.AsNoTracking().Select(i => i.Name).ToListAsync();
        }
    }
}

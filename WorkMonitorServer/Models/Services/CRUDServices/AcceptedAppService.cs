using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Models.Services.CRUDServices
{
    public class AcceptedAppService
    {
        private readonly ApplicationContext applicationContext;

        public AcceptedAppService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public async Task AddAppAsync(AcceptedApp acceptedApp)
        {
            var client = await applicationContext.Clients.Where(i => i.Name == acceptedApp.UserName).FirstOrDefaultAsync() ??
                throw new ClientNotFoundException();
            await applicationContext.AcceptedApps.AddAsync(new DAL.DataEntities.AcceptedApp
            {
                AppName = acceptedApp.AppName,
                Client = client,
            });
            await applicationContext.SaveChangesAsync();
        }
    }
}

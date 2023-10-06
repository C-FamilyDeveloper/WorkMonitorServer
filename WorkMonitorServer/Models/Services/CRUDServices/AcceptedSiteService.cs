using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Models.Services.CRUDServices
{
    public class AcceptedSiteService
    {
        private readonly ApplicationContext applicationContext;

        public AcceptedSiteService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public async Task AddSiteAsync(AcceptedSite acceptedSite)
        {
            var client = await applicationContext.Clients.Where(i => i.Name == acceptedSite.UserName).FirstOrDefaultAsync() ??
                throw new ClientNotFoundException();
            await applicationContext.AcceptedSites.AddAsync(new DAL.DataEntities.AcceptedSite
            {
                URL = acceptedSite.SiteURL,
                Client = client
            });
            await applicationContext.SaveChangesAsync();
        }
    }
}

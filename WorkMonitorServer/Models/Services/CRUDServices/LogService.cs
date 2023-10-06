using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Models.Services.CRUDServices
{
    public class LogService
    {
        private readonly ApplicationContext applicationContext;

        public LogService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public async Task AddLogAsync(Log log)
        {
            var client = await applicationContext.Clients.Where(i => i.Name == log.ClientName).FirstOrDefaultAsync() ??
                throw new ClientNotFoundException();
            await applicationContext.Logs.AddAsync(new DAL.DataEntities.Log
            {
                LogDateTime = log.LogDateTime,
                LogMessage = log.LogMessage,
                Client = client,
            });
            await applicationContext.SaveChangesAsync();
        }
    }
}

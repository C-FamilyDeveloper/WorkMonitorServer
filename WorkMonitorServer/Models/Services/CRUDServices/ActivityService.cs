using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorServer.Models.Extensions;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Models.Services.CRUDServices
{
    public class ActivityService
    {
        private readonly ApplicationContext applicationContext;

        public ActivityService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public async Task AddActivityAsync(WorkerInfo workerInfo)
        {
            var client = await applicationContext.Clients.Where(i => i.Name == workerInfo.Worker).FirstOrDefaultAsync() ??
                throw new ClientNotFoundException();
            await applicationContext.Activities.AddAsync(new DAL.DataEntities.Activity
            {
                ActivityApplication = workerInfo.Application,
                ActivitySite = workerInfo.Site,
                ActivityDateTime = workerInfo.EventDateTime,
                Client = client!,
                IdleTime = workerInfo.IdleTime,
                WorkTime = workerInfo.WorkTime
            });
            await applicationContext.SaveChangesAsync();
        }
        public async Task <List<WorkerInfo>?> GetAllActivitiesAsync()
        {
            return await applicationContext.Activities.AsNoTracking().Select(
                j => new WorkerInfo
                {
                    Site = j.ActivitySite,
                    Application = j.ActivityApplication,
                    EventDateTime = j.ActivityDateTime,
                    IdleTime = j.IdleTime,
                    WorkTime = j.WorkTime,
                    Worker = j.Client.Name
                }).ToListAsync();
        }
        public async Task<List<WorkerInfo>?> GetClientActivitiesByClientNameAsync(string clientName)
        {
            if (await applicationContext.Clients.IsClientExistsAsync(clientName))
            {
                throw new ClientNotFoundException();
            }
            return await applicationContext.Activities.AsNoTracking().Where(i => i.Client.Name == clientName).Select(
                j => new WorkerInfo
                {
                    Site = j.ActivitySite,
                    Application = j.ActivityApplication,
                    EventDateTime = j.ActivityDateTime,
                    IdleTime = j.IdleTime,
                    WorkTime = j.WorkTime,
                    Worker = j.Client.Name
                }).ToListAsync();
        }
    }
}

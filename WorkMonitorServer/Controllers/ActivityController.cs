using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.DAL.DataEntities;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> logger;
        private readonly ApplicationContext applicationContext;

        public ActivityController(ILogger<ActivityController> logger, ApplicationContext applicationContext)
        {
            this.logger = logger;
            this.applicationContext = applicationContext;
        }
        [HttpPost]
        public async Task Post([FromBody] WorkerInfo workerInfo)
        {
            Client? client = await applicationContext.Clients.Where(i => i.Name == workerInfo.Worker).FirstOrDefaultAsync();
            if (client == null)
            {
                BadRequest();
            }
            await applicationContext.AddAsync(new Activity
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

        [HttpGet]
        public async Task<List<WorkerInfo>> Get([FromQuery] string worker)
        {
            return await applicationContext.Activities.AsNoTracking().Where(i => i.Client.Name == worker).Select(
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContexts;
using WorkMonitorServer.Models.DataEntities;
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
            if (client == default)
            {
                BadRequest();
            }
            await applicationContext.AddAsync(new Activity
            {
                ActivityApplication = workerInfo.Application,
                ActivitySite = workerInfo.Site,
                Client = client!,
                IdleTime = workerInfo.IdleTime,
                WorkTime = workerInfo.WorkTime                
            });
            await applicationContext.SaveChangesAsync();
        }
        /*[HttpGet("{worker}")]
        public async Task<List<Activity>> Get([FromQuery(Name ="worker")] string worker)
        {
            return await activityrepository.Get();
        }*/
    }
}

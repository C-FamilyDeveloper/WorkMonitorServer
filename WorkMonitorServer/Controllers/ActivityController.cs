using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ScreenController> logger;
        private readonly IBaseRepository<Activity> activityrepository;
        private readonly IBaseRepository<Client> clientrepository;

        public ActivityController(ILogger<ScreenController> logger, IBaseRepository<Activity> activityrepository,
            IBaseRepository<Client> clientrepository)
        {
            this.logger = logger;
            this.activityrepository = activityrepository;
            this.clientrepository = clientrepository;
        }
        [HttpPost]
        public async Task Post([FromBody] WorkerInfo workerInfo)
        {
            var result = (await clientrepository.Get()).Where(i => i.Name == workerInfo.Worker);
            if (!result.Any())
            {
                await clientrepository.Add(new Client { Name = workerInfo.Worker });
            }
            Client client = (await clientrepository.Get()).Where(i => i.Name == workerInfo.Worker).First();
            await activityrepository.Add(new Activity
            {
                ActivityApplication = workerInfo.Application,
                ActivitySite = workerInfo.Site,
                Client = client,
                IdleTime = workerInfo.IdleTime,
                WorkTime = workerInfo.WorkTime                
            });
            await activityrepository.Save();
        }
        /*[HttpGet("{worker}")]
        public async Task<List<Activity>> Get([FromQuery(Name ="worker")] string worker)
        {
            return await activityrepository.Get();
        }*/
    }
}

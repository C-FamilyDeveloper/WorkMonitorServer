using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.DAL.DataEntities;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/apps")]
    public class AcceptedAppsController : ControllerBase
    {
        private ILogger<AcceptedAppsController> logger;
        private readonly ApplicationContext applicationContext;
        public AcceptedAppsController (ILogger<AcceptedAppsController> logger, ApplicationContext applicationContext)
        {
            this.logger = logger;
            this.applicationContext = applicationContext;
        }
        [HttpPost]
        public async Task Post([FromBody] WorkMonitorTypes.Requests.AcceptedApp app)
        {
            Client? client = await applicationContext.Clients.Where(i => i.Name == app.UserName).FirstOrDefaultAsync();
            if (client == default)
            {
                BadRequest();
            }
            await applicationContext.AddAsync(new AcceptedApp
            {
                AppName = app.AppName,
                Client = client
            });
            await applicationContext.SaveChangesAsync();
        }

    }
}

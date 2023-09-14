using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContexts;
using WorkMonitorServer.Models.DataEntities;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/sites")]
    public class AcceptedSitesController : ControllerBase
    {
        private ILogger<AcceptedSitesController> logger;
        private readonly ApplicationContext applicationContext;

        public AcceptedSitesController(ILogger<AcceptedSitesController> logger, ApplicationContext applicationContext)
        {
            this.logger = logger;
            this.applicationContext = applicationContext;
        }
        [HttpPost]
        public async Task Post([FromBody] WorkMonitorTypes.Requests.AcceptedSite app)
        {
            Client? client = await applicationContext.Clients.Where(i => i.Name == app.UserName).FirstOrDefaultAsync();
            if (client == default)
            {
                BadRequest();
            }
            await applicationContext.AddAsync(new AcceptedSite
            {
                URL = app.SiteURL,
                Client = client!,
            });
            await applicationContext.SaveChangesAsync();
        }
    }
}

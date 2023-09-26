using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.DAL.DataEntities;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsController : Controller
    {
        private ILogger<LogsController> logger;
        private readonly ApplicationContext applicationContext;

        public LogsController(ILogger<LogsController> logger, ApplicationContext applicationContext)
        {
            this.logger = logger;
            this.applicationContext = applicationContext;
        }
        [HttpPost]
        public async Task Post(WorkMonitorTypes.Requests.Log log)
        {
            Client? client = await applicationContext.Clients.Where(i => i.Name == log.ClientName).FirstOrDefaultAsync();
            if (client == default)
            {
                BadRequest();
            }
            await applicationContext.Logs.AddAsync(new Models.DAL.DataEntities.Log 
            { 
                LogDateTime = log.LogDateTime,
                LogMessage = log.LogMessage,
                Client = client!
            });
        }
    }
}

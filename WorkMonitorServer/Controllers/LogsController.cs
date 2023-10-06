using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorServer.Models.Services.CRUDServices;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsController : Controller
    {
        private readonly ILogger<LogsController> logger;
        private readonly LogService logService;

        public LogsController(ILogger<LogsController> logger, LogService logService)
        {
            this.logger = logger;
            this.logService = logService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(WorkMonitorTypes.Requests.Log log)
        {
            try
            {
                await logService.AddLogAsync(log);
            }
            catch (ClientNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}

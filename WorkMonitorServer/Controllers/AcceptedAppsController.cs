using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorServer.Models.Services.CRUDServices;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/apps")]
    public class AcceptedAppsController : ControllerBase
    {
        private readonly ILogger<AcceptedAppsController> logger;
        private readonly AcceptedAppService acceptedAppService;
        public AcceptedAppsController (ILogger<AcceptedAppsController> logger, AcceptedAppService acceptedAppService)
        {
            this.logger = logger;
            this.acceptedAppService = acceptedAppService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(WorkMonitorTypes.Requests.AcceptedApp app)
        {
            try
            {
                await acceptedAppService.AddAppAsync(app);
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

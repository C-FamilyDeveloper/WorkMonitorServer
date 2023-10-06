using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorServer.Models.Services.CRUDServices;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/sites")]
    public class AcceptedSitesController : ControllerBase
    {
        private readonly ILogger<AcceptedSitesController> logger;
        private readonly AcceptedSiteService acceptedSiteService;

        public AcceptedSitesController(ILogger<AcceptedSitesController> logger, AcceptedSiteService acceptedSiteService)
        {
            this.logger = logger;
            this.acceptedSiteService = acceptedSiteService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(WorkMonitorTypes.Requests.AcceptedSite site)
        {
            try
            {
                await acceptedSiteService.AddSiteAsync(site);
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

using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorServer.Models.Services.CRUDServices;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/screenshots")]
    public class ScreenController : ControllerBase
    {
        private readonly ILogger<ScreenController> logger;
        private readonly ScreenshotService screenshotService;

        public ScreenController(ILogger<ScreenController> logger, ScreenshotService screenshotService)
        {
            this.logger = logger;
            this.screenshotService = screenshotService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Screenshot screenshot)
        {
            try
            {
                await screenshotService.AddScreenshotAsync(screenshot);
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
        [HttpGet]
        public async Task<ActionResult<List<Screenshot>?>> Get(string worker)
        {
            try
            {
                return await screenshotService.GetScreenshotsByClientNameAsync(worker);
            }
            catch (ClientNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
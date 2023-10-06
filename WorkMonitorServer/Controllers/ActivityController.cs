using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorServer.Models.Services.CRUDServices;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/activities/[action]")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> logger;
        private readonly ActivityService activityService;

        public ActivityController(ILogger<ActivityController> logger, ActivityService activityService)
        {
            this.logger = logger;
            this.activityService = activityService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(WorkerInfo workerInfo)
        {
            try
            {
                await activityService.AddActivityAsync(workerInfo);
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
        public async Task<ActionResult<List<WorkerInfo>?>> GetByName(string clientName)
        {
            try
            {
                return await activityService.GetClientActivitiesByClientNameAsync(clientName);
            }
            catch (ClientNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<WorkerInfo>?>> GetAll()
        {
            try
            {
                return await activityService.GetAllActivitiesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.DAL.DataEntities;
using WorkMonitorServer.Models.Services;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/screenshots")]
    public class ScreenController : ControllerBase
    {
        private readonly ILogger<ScreenController> logger;
        private readonly ApplicationContext applicationContext;

        public ScreenController(ILogger<ScreenController> logger, ApplicationContext applicationContext)
        {
            this.logger = logger;
            this.applicationContext = applicationContext;
        }
        [HttpPost]
        public async Task Post([FromBody] Screenshot screenshot)
        {
            Client? client = await applicationContext.Clients.Where(i => i.Name == screenshot.ClientName).FirstOrDefaultAsync();
            if (client == default) 
            {
                BadRequest();
            }
            await applicationContext.AddAsync(new Screen { Image = screenshot.Image, ScreenedClient = client!,
                ScreenshotDateTime = screenshot.ScreenshotDateTime });
            await applicationContext.SaveChangesAsync();
        }
        /*[HttpGet]
        public IEnumerable<> Get()
        {

        }*/
    }
}
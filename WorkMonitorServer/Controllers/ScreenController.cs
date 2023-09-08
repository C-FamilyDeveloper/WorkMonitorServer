using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;
using WorkMonitorServer.Models.Services;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/screenshots")]
    public class ScreenController : ControllerBase
    {
        private readonly ILogger<ScreenController> logger;
        private readonly IBaseRepository<Screen> screenrepository;
        private readonly IBaseRepository<Client> clientrepository;

        public ScreenController(ILogger<ScreenController> logger, IBaseRepository<Screen> screenrepository,
            IBaseRepository<Client> clientrepository)
        {
            this.logger = logger;
            this.screenrepository = screenrepository;
            this.clientrepository = clientrepository;
        }
        [HttpPost]
        public async Task Post([FromBody] Screenshot screenshot)
        {
            //ImageSaverService.Save(image);
            var result = (await clientrepository.Get()).Where(i => i.Name == screenshot.ClientName);
            if (!result.Any())
            {
                await clientrepository.Add(new Client { Name = screenshot.ClientName });
                await clientrepository.Save();
            }
            Client client = (await clientrepository.Get()).Where(i => i.Name == screenshot.ClientName).First();
            await screenrepository.Add(new Screen { Image = screenshot.Image, ScreenedClient = client,
                ScreenshotDateTime = screenshot.ScreenshotDateTime });
            await screenrepository.Save();
        }
        /*[HttpGet]
        public IEnumerable<> Get()
        {

        }*/
    }
}
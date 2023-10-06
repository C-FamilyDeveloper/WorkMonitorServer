using Microsoft.AspNetCore.Mvc;
using WorkMonitorServer.Models.Services.CRUDServices;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> logger;
        private readonly ClientService clientService;

        
        public ClientsController (ILogger<ClientsController> logger, ClientService clientService)
        {
            this.logger = logger;
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>?>> Get()
        {
            try
            {
                return Ok(await clientService.GetClientsNamesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }      
        }

    }
}

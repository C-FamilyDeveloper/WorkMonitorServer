﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContexts;
using WorkMonitorServer.Models.DataEntities;

namespace WorkMonitorServer.Controllers
{
    [ApiController]
    [Route("api/apps")]
    public class ClientsController : Controller
    {
        private ILogger<ClientsController> logger;
        private readonly ApplicationContext applicationContext;

        public ClientsController (ILogger<ClientsController> logger, ApplicationContext applicationContext)
        {
            this.logger = logger;
            this.applicationContext = applicationContext;
        }
        [HttpGet]
        public async Task<List<string>> Get()
        {
            return await applicationContext.Clients.Select(i => i.Name).ToListAsync();         
        }

    }
}
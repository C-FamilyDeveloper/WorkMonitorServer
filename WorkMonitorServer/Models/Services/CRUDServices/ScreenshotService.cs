using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.Exceptions;
using WorkMonitorServer.Models.Extensions;
using WorkMonitorTypes.Requests;

namespace WorkMonitorServer.Models.Services.CRUDServices
{
    public class ScreenshotService
    {
        private readonly ApplicationContext applicationContext;

        public ScreenshotService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public async Task AddScreenshotAsync (Screenshot screenshot)
        {
            var client = await applicationContext.Clients.Where(i => i.Name == screenshot.ClientName).FirstOrDefaultAsync() ??
                throw new ClientNotFoundException();
            await applicationContext.Screens.AddAsync(new DAL.DataEntities.Screen
            {
                ScreenedClient = client,
                ScreenshotDateTime = screenshot.ScreenshotDateTime,
                Image = screenshot.Image
            });
            await applicationContext.SaveChangesAsync();
        }
        public async Task<List<Screenshot>?> GetScreenshotsByClientNameAsync(string clientName)
        {
            if (await applicationContext.Clients.IsClientExistsAsync(clientName))
            {
                throw new ClientNotFoundException();
            }
            return await applicationContext.Screens.AsNoTracking().Where(i => i.ScreenedClient.Name == clientName)
               .Select(j =>
                   new Screenshot
                   {
                       Image = j.Image,
                       ClientName = j.ScreenedClient.Name,
                       ScreenshotDateTime = j.ScreenshotDateTime
                   }).ToListAsync();
        }
    }
}

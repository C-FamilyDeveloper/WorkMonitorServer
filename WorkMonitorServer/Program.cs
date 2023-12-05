using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DAL.DataContexts;
using WorkMonitorServer.Models.DAL.DataEntities;
using WorkMonitorServer.Models.Services;
using WorkMonitorServer.Models.Services.CRUDServices;

namespace WorkMonitorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            string connection = builder.Configuration.GetConnectionString("Connection")!;
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection).UseLazyLoadingProxies());
            builder.Services.AddControllers(options =>
                options.InputFormatters.Add(new ByteArrayInputFormatterService()));
            builder.Services.AddScoped<AcceptedAppService>();
            builder.Services.AddScoped<AcceptedSiteService>();
            builder.Services.AddScoped<LogService>();
            builder.Services.AddScoped<ScreenshotService>();
            builder.Services.AddScoped<ActivityService>();
            builder.Services.AddScoped<ClientService>();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
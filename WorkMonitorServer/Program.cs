using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net.Mail;
using WorkMonitorServer.Models.DataContextes;
using WorkMonitorServer.Models.DataEntities;
using WorkMonitorServer.Models.Interfaces;
using WorkMonitorServer.Models.Repositories;
using WorkMonitorServer.Models.Services;

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
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            builder.Services.AddControllers(options =>
                options.InputFormatters.Add(new ByteArrayInputFormatterService()));
            builder.Services.AddScoped<IBaseRepository<Screen>, ScreenRepository>();
            builder.Services.AddScoped<IBaseRepository<Activity>, ActivityRepository>();
            builder.Services.AddScoped<IBaseRepository<Log>, LogRepository>();
            builder.Services.AddScoped<IBaseRepository<AcceptedSite>, AcceptedSiteRepository>();
            builder.Services.AddScoped<IBaseRepository<AcceptedApp>, AcceptedAppRepository>();
            builder.Services.AddScoped<IBaseRepository<Client>, ClientRepository>();
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
using Microsoft.EntityFrameworkCore;
using WorkMonitorServer.Models.DataContexts;
using WorkMonitorServer.Models.DataEntities;
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
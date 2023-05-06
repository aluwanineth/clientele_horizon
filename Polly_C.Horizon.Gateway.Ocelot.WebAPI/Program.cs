
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

namespace Polly_C.Horizon.Gateway.Ocelot.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            builder.Services.AddOcelot(builder.Configuration);

            var logger = new LoggerConfiguration()
                          .ReadFrom.Configuration(builder.Configuration)
                          .Enrich.FromLogContext()
                          .WriteTo.RollingFile("/Logs/log-{Date}.txt")
                          .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseOcelot();
            app.Run();
        }
    }
}
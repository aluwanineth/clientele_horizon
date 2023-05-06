
using Polly_C.Horizon.Models.DTOs.Account;
using Polly_C.Horizon.Utilities.Middlewares;
using Polly_C.Horizon.WebAPI.Authentication.Interfaces;
using Polly_C.Horizon.WebAPI.Authentication.Services;
using Serilog;
using System.Configuration;

namespace Polly_C.Horizon.WebAPI.Authentication
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
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.Configure<Domain>(builder.Configuration.GetSection("Domain"));
            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.IsEssential = true;
            });

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

            app.UseRouting();
            app.UseCors(x => x
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(origin => true) // allow any origin
                            .AllowCredentials()); // allow credentials
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseSession();

            app.MapControllers();

            app.Run();
        }
    }
}
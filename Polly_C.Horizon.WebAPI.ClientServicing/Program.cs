
using Microsoft.EntityFrameworkCore;
using Polly_C.Horizon.Utilities.Middlewares;
using Polly_C.Horizon.Service.ClientServicing.Interfaces;
using Polly_C.Horizon.Service.ClientServicing.Services;
using Serilog;
using Polly_C.Horizon.Models.Repositories.Customer;
using Polly_C.Horizon.Models.Repositories.Customer.MappingProfiles;
using System.Reflection;
using Polly_C.Horizon.WebAPI.ClientServicing.Extensions;
using Polly_C.Horizon.Data.Polly_C.Models;
using Polly_C.Horizon.Data.Customer.Models;

namespace Polly_C.Horizon.WebAPI.ClientServicing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerExtension();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<Polly_CContext>(options =>
                options.UseSqlServer(
                               builder.Configuration.GetConnectionString("Polly_CEntities"),
                               b => b.MigrationsAssembly(typeof(Polly_CContext).Assembly.FullName)));
            builder.Services.AddDbContext<CustomerContext>(options =>
                options.UseSqlServer(
                               builder.Configuration.GetConnectionString("CustomerEntities"),
                               b => b.MigrationsAssembly(typeof(CustomerContext).Assembly.FullName)));
            builder.Services.AddScoped<IClientServicingRepository, ClientServicingRepository>();
            builder.Services.AddAutoMapper(typeof(ClientServicingMappingProfiles).Assembly);
            builder.Services.AddScoped<IClientServicingService, ClientServicingService>();
            builder.Services.AddScoped<IPolly_CContextProcedures, Polly_CContextProcedures>();
            builder.Services.AddApiVersioningExtension();
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
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(origin => true) // allow any origin
                            .AllowCredentials()); // allow credentials

            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();

            app.MapControllers();

            app.Run();
        }
    }
}
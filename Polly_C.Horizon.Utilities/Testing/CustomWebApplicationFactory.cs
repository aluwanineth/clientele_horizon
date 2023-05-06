using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly_C.Horizon.Data.Customer.Models;
using Polly_C.Horizon.Data.Polly_C.Models;
using Polly_C.Horizon.Models.Repositories.Customer.MappingProfiles;
using Polly_C.Horizon.Models.Repositories.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Utilities.Testing
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices((config, services) =>
            {
                services.AddDbContext<CustomerContext>(options =>
                    options.UseSqlServer(
                        config.Configuration.GetConnectionString("CustomerEntities"),
                                b => b.MigrationsAssembly(typeof(CustomerContext).Assembly.FullName)));
                services.AddDbContext<Polly_CContext>(options =>
                    options.UseSqlServer(
                        config.Configuration.GetConnectionString("CustomerEntities"),
                                b => b.MigrationsAssembly(typeof(Polly_CContext).Assembly.FullName)));

                services.AddScoped<IClientServicingRepository, ClientServicingRepository>();
                services.AddScoped<IPolly_CContextProcedures, Polly_CContextProcedures>();
            });
        }
    }
}

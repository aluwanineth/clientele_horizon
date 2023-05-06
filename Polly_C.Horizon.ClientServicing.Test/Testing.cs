using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly_C.Horizon.Models.Repositories.Customer;
using Polly_C.Horizon.Utilities.Testing;
using Polly_C.Horizon.WebAPI.ClientServicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.ClientServicing.Test
{
    [SetUpFixture]
    public partial class Testing
    {
        private static WebApplicationFactory<Program> _factory = null!;
        private static IConfiguration _configuration = null!;
        public static IServiceScopeFactory _scopeFactory = null!;
       
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _factory = new Utilities.Testing.CustomWebApplicationFactory<Program>();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
            _configuration = _factory.Services.GetRequiredService<IConfiguration>();

        }

        public static async Task ResetState()
        {
        }
    }
}

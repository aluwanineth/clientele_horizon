using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.DependencyInjection;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Models.Repositories.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.ClientServicing.Test.IntegrationTests
{
    using static Testing;
    public class PolicyDetailsIntegrationTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldReturnSmokersLookups()
        {
            using var scope = _scopeFactory.CreateScope();

            var clientServicingRepository = scope.ServiceProvider.GetRequiredService<IClientServicingRepository>();

            var request = new SmokerSelectRequest
            {
                Disp_Seq = null,
                Eff_Date = null,
                Exp_Date = null,
                Smoker_CD = null,
                S_Desc = null
            };

            var result = await clientServicingRepository.GetSmokerLookups(request);
            Assert.NotNull(result);
        }

        [Test]
        public async Task ShouldReturnGendersLookups()
        {
            using var scope = _scopeFactory.CreateScope();

            var clientServicingRepository = scope.ServiceProvider.GetRequiredService<IClientServicingRepository>();

            var request = new GenderSelectRequest
            {
                Disp_Seq = null,
                Eff_Date = null,
                Exp_Date = null,
                Gender_CD = null,
                S_Desc = null
            };

            var result = await clientServicingRepository.GetGendersLookups(request);
            Assert.NotNull(result);
        }

       

        [Test]
        public async Task ShouldReturnTitlesLookups()
        {
            using var scope = _scopeFactory.CreateScope();

            var clientServicingRepository = scope.ServiceProvider.GetRequiredService<IClientServicingRepository>();

            var request = new TitleSelectRequest
            {
                Disp_Seq = null,
                Eff_Date = null,
                Exp_Date = null,
                Title_CD = null,
                S_Desc = null
            };

            var result = await clientServicingRepository.GetTittlesLookups(request);
            Assert.NotNull(result);
        }

        [Test]
        public async Task ShouldReturnPolicyMemberDetail()
        {
            using var scope = _scopeFactory.CreateScope();

            var clientServicingRepository = scope.ServiceProvider.GetRequiredService<IClientServicingRepository>();

            var request = new GetPolicyAndMainMemberDetailsRequest
            {
               PolicyNo = 123
            };

            var result = await clientServicingRepository.GetPolicyAndMainMemberDetails(request);
            Assert.NotNull(result);
        }

        [Test]
        public async Task ShouldReturnBanksLookups()
        {
            using var scope = _scopeFactory.CreateScope();

            var clientServicingRepository = scope.ServiceProvider.GetRequiredService<IClientServicingRepository>();

            var request = new BankRequest
            {
                BankID = null,
                BankName = null,
                BankShortName = null,
                DispSeq = null,
                IsActive = null,
                LastChanged = null,
                UserID = null
            };

            var result = await clientServicingRepository.GetBankLookups(request);
            Assert.NotNull(result);
        }

        [Test]
        public async Task ShouldReturnBankAccountTypeLookups()
        {
            using var scope = _scopeFactory.CreateScope();

            var clientServicingRepository = scope.ServiceProvider.GetRequiredService<IClientServicingRepository>();

            var request = new BankAccountTypeRequest
            {
                BankAccTypeCD = null,
                BankAccTypeDesc = null,
                BankAccTypeRegEx = null,
                DispSeq = null,
                IsActive = null,
                LastChanged = null,
                UserID = null
            };

            var result = await clientServicingRepository.GetBankAccountTypeLookups(request);
            Assert.NotNull(result);
        }

        [Test]
        public async Task ShouldReturnPaymentFequentLookups()
        {
            using var scope = _scopeFactory.CreateScope();

            var clientServicingRepository = scope.ServiceProvider.GetRequiredService<IClientServicingRepository>();

            var request = new PaymentFrequentSelectRequest
            {
                Disp_Seq = null,
                Eff_Date = null,
                Exp_Date = null,
                Payment_Freq_CD = null,
                Short_Desc = null
            };

            var result = await clientServicingRepository.GetPaymentFrequentLookups(request);
            Assert.NotNull(result);
        }
    }
}

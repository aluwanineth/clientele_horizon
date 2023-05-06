using Microsoft.Extensions.Logging;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;
using Polly_C.Horizon.Models.Repositories.Customer;
using Polly_C.Horizon.Models.Wrappers;
using Polly_C.Horizon.Service.ClientServicing.Interfaces;
using Polly_C.Horizon.Utilities.Exceptions;

namespace Polly_C.Horizon.Service.ClientServicing.Services
{
    public class ClientServicingService : IClientServicingService
    {
        private readonly IClientServicingRepository _clientServicingRepository;

        public ClientServicingService(IClientServicingRepository clientServicingRepository, ILogger<ClientServicingService> logger)
        {
            _clientServicingRepository = clientServicingRepository;
        }

        public async Task<Response<List<CustomerPolicyInfoResult>>> GetCustomerPolicyInfoByEntityNo(EntityNoRequest EntityNoRequest)
        {
                var result = await _clientServicingRepository.GetCustomerPolicyInfoByEntityNo(EntityNoRequest);
                return new Response<List<CustomerPolicyInfoResult>>(result);
        }

        public async Task<Response<List<PersonSearchResult>>> AdvancedPersonSearch(AdvancedPersonSearchRequest advancedPersonSearchRequest)
        {
                var result = await _clientServicingRepository.AdvancedPersonSearch(advancedPersonSearchRequest);
                return new Response<List<PersonSearchResult>>(result);
        }

        public async Task<Response<List<PersonSearchResult>>> PersonSearch(PersonSearchRequest personSearchRequest)
        {
                var result = await _clientServicingRepository.PersonSearch(personSearchRequest);
                return new Response<List<PersonSearchResult>>(result);
        }

        public async Task<Response<List<BankResult>>> GetBankLookups(BankRequest bankRequest)
        {
                var result = await _clientServicingRepository.GetBankLookups(bankRequest);
                return new Response<List<BankResult>>(result);
        }

        public async Task<Response<List<BankAccountTypeResult>>> GetBankAccountTypeLookups(BankAccountTypeRequest bankAccountTypeSelectRequest)
        {
                var result = await _clientServicingRepository.GetBankAccountTypeLookups(bankAccountTypeSelectRequest);
                return new Response<List<BankAccountTypeResult>>(result);
        }

        public async Task<Response<List<BenefitExtendedMemberResult>>> GetBenefitExtendedMemberDetails(BenefitExtendedMemberRequest request)
        {
            var results = await _clientServicingRepository.GetBenefitExtendedMemberDetails(request);
            return new Response<List<BenefitExtendedMemberResult>>(results);
        }

        public async Task<Response<List<BeneficiaryDetailsResult>>> GetBeneficiaryDetails(BeneficiaryDetailsRequest request)
        {
            var result = await _clientServicingRepository.GetBeneficiaryDetails(request);
            return new Response<List<BeneficiaryDetailsResult>>(result);
        }

        public async Task<Response<List<GetPolicyAndMainMemberDetailsResult>>> GetPolicyAndMainMemberDetails(GetPolicyAndMainMemberDetailsRequest request)
        {
            var result = await _clientServicingRepository.GetPolicyAndMainMemberDetails(request);
            return new Response<List<GetPolicyAndMainMemberDetailsResult>>(result);
        }

        public async Task<Response<List<SmokerSelectResult>>> GetSmokerLookups(SmokerSelectRequest request)
        {
            var result = await _clientServicingRepository.GetSmokerLookups(request);
            return new Response<List<SmokerSelectResult>>(result);
        }

        public async Task<Response<List<PaymentFrequentSelectResult>>> GetPaymentFrequentLookups(PaymentFrequentSelectRequest request)
        {
            var result = await _clientServicingRepository.GetPaymentFrequentLookups(request);
            return new Response<List<PaymentFrequentSelectResult>>(result);
        }

        public async Task<Response<List<TitleSelectResult>>> GetTittlesLookups(TitleSelectRequest request)
        {
            var result = await _clientServicingRepository.GetTittlesLookups(request);
            return new Response<List<TitleSelectResult>>(result);
        }

        public async Task<Response<List<GenderSelectResult>>> GetGendersLookups(GenderSelectRequest request)
        {
            var result = await _clientServicingRepository.GetGendersLookups(request);
            return new Response<List<GenderSelectResult>>(result);
        }
    }
}

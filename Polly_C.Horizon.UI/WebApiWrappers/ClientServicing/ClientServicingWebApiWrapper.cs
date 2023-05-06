using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;
using Polly_C.Horizon.Models.Enums;
using Polly_C.Horizon.Models.Wrappers;
using Polly_C.Horizon.UI.WebApiWrapperInterfaces.ClientServicing;
using Polly_C.Horizon.UI.WebApiWrapperInterfaces.Utilities;

namespace Polly_C.Horizon.UI.Wrappers.ClientServicing
{
    public class ClientServicingWebApiWrapper : IClientServicingWebApiWrapper
    {
        private readonly IHttpClientWrapper _httpClientService;

        public ClientServicingWebApiWrapper(IHttpClientWrapper httpClientService)
        {
            _httpClientService = httpClientService;
        }
        
        public async Task<Response<List<CustomerPolicyInfoResult>>> GetCustomerPolicyInfoByEntityNo(string EntityNo)
        {
            var endpoint = string.Format("GetCustomerPolicyInfoByEntityNo?entityNo={0}", EntityNo);

            return await _httpClientService.getAsync<Response<List<CustomerPolicyInfoResult>>>(Controllers.PolicyDetails, endpoint);
        }

        public async Task<Response<BankAccountTypeResult>> GetBankAccountTypeLookups(BankAccountTypeRequest request)
        {
            return await _httpClientService.postAsync<Response<BankAccountTypeResult>, BankAccountTypeRequest>(Controllers.PolicyDetails, "bankTypeSelect", request);
        }

        public async Task<Response<BankResult>> GetBankLookups(BankRequest request)
        {
            return await _httpClientService.postAsync<Response<BankResult>, BankRequest>(Controllers.PolicyDetails, "bankSelect", request);
        }

        public async Task<Response<List<PersonSearchResult>>> PersonSearch(PersonSearchRequest _personSearch)
        {
            return await _httpClientService.postAsync<Response<List<PersonSearchResult>>, PersonSearchRequest>(Controllers.PolicySearch, "personSearch", _personSearch);
        }

        public async Task<Response<List<PersonSearchResult>>> AdvancedPersonSearch(AdvancedPersonSearchRequest _advancedPersonSearch)
        {
            return await _httpClientService.postAsync<Response<List<PersonSearchResult>>, AdvancedPersonSearchRequest>(Controllers.PolicySearch, "advancedPersonSearch", _advancedPersonSearch);
        }

        public async Task<Response<List<BenefitExtendedMemberResult>>> GetBenefitExtendedMemberDetails(BenefitExtendedMemberRequest request)
        {
            return await _httpClientService.postAsync<Response<List<BenefitExtendedMemberResult>>, BenefitExtendedMemberRequest>(Controllers.BenefitExtendedMember, "policyBenefitExtendedMember", request);
        }
        public async Task<Response<List<BeneficiaryDetailsResult>>> GetBeneficiaryDetails(BeneficiaryDetailsRequest request)
        {
            return await _httpClientService.postAsync<Response<List<BeneficiaryDetailsResult>>, BeneficiaryDetailsRequest>(Controllers.BeneficiaryDetails, "beneficiaryDetails", request);
        }

        public async Task<Response<List<GetPolicyAndMainMemberDetailsResult>>> GetPolicyAndMainMemberDetails(GetPolicyAndMainMemberDetailsRequest request)
        {
            return await _httpClientService.postAsync<Response<List<GetPolicyAndMainMemberDetailsResult>>, GetPolicyAndMainMemberDetailsRequest>(Controllers.PolicyDetails, "getPolicyAndMainMemberDetails", request);
        }

        public async Task<Response<List<SmokerSelectResult>>> GetSmokerLookups(SmokerSelectRequest request)
        {
            return await _httpClientService.postAsync<Response<List<SmokerSelectResult>>, SmokerSelectRequest>(Controllers.PolicyDetails, "getsSmokerLookups", request);
        }

        public async Task<Response<List<PaymentFrequentSelectResult>>> GetPaymentFrequentLookups(PaymentFrequentSelectRequest request)
        {
            return await _httpClientService.postAsync<Response<List<PaymentFrequentSelectResult>>, PaymentFrequentSelectRequest>(Controllers.PolicyDetails, "getPaymentFrequentLookups", request);
        }

        public async Task<Response<List<TitleSelectResult>>> GetTittlesLookups(TitleSelectRequest request)
        {
            return await _httpClientService.postAsync<Response<List<TitleSelectResult>>, TitleSelectRequest>(Controllers.PolicyDetails, "getTittlesLookups", request);
        }

        public async Task<Response<List<GenderSelectResult>>> GetGendersLookups(GenderSelectRequest request)
        {
            return await _httpClientService.postAsync<Response<List<GenderSelectResult>>, GenderSelectRequest>(Controllers.PolicyDetails, "getGendersLookups", request);
        }
    }
}

using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;
using Polly_C.Horizon.Models.Wrappers;

namespace Polly_C.Horizon.UI.WebApiWrapperInterfaces.ClientServicing
{
    public interface IClientServicingWebApiWrapper
    {
        Task<Response<List<CustomerPolicyInfoResult>>> GetCustomerPolicyInfoByEntityNo(string EntityNo);

        Task<Response<BankResult>> GetBankLookups(BankRequest request);

        Task<Response<BankAccountTypeResult>> GetBankAccountTypeLookups(BankAccountTypeRequest request);

        Task<Response<List<PersonSearchResult>>> AdvancedPersonSearch(AdvancedPersonSearchRequest _advancedPersonSearch);

        Task<Response<List<PersonSearchResult>>> PersonSearch(PersonSearchRequest _personSearch);

        Task<Response<List<BenefitExtendedMemberResult>>> GetBenefitExtendedMemberDetails(BenefitExtendedMemberRequest request);

        Task<Response<List<BeneficiaryDetailsResult>>> GetBeneficiaryDetails(BeneficiaryDetailsRequest request);
        Task<Response<List<GetPolicyAndMainMemberDetailsResult>>> GetPolicyAndMainMemberDetails(GetPolicyAndMainMemberDetailsRequest request);
        Task<Response<List<SmokerSelectResult>>> GetSmokerLookups(SmokerSelectRequest request);
        Task<Response<List<PaymentFrequentSelectResult>>> GetPaymentFrequentLookups(PaymentFrequentSelectRequest request);
        Task<Response<List<TitleSelectResult>>> GetTittlesLookups(TitleSelectRequest request);
        Task<Response<List<GenderSelectResult>>> GetGendersLookups(GenderSelectRequest request);
    }
}


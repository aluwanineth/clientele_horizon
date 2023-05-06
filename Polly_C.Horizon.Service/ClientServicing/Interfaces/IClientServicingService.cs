using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;
using Polly_C.Horizon.Models.Wrappers;

namespace Polly_C.Horizon.Service.ClientServicing.Interfaces
{
    public interface IClientServicingService
    {
        Task<Response<List<CustomerPolicyInfoResult>>> GetCustomerPolicyInfoByEntityNo(EntityNoRequest request);

        Task<Response<List<BankResult>>> GetBankLookups(BankRequest bankRequest);

        Task<Response<List<BankAccountTypeResult>>> GetBankAccountTypeLookups(BankAccountTypeRequest bankAccountTypeRequest);

        Task<Response<List<PersonSearchResult>>> AdvancedPersonSearch(AdvancedPersonSearchRequest advancedPersonSearchRequest);

        Task<Response<List<PersonSearchResult>>> PersonSearch(PersonSearchRequest personSearchRequest);

        Task<Response<List<BenefitExtendedMemberResult>>> GetBenefitExtendedMemberDetails(BenefitExtendedMemberRequest request);

        Task<Response<List<BeneficiaryDetailsResult>>> GetBeneficiaryDetails(BeneficiaryDetailsRequest request);
        Task<Response<List<GetPolicyAndMainMemberDetailsResult>>> GetPolicyAndMainMemberDetails(GetPolicyAndMainMemberDetailsRequest request);
        Task<Response<List<SmokerSelectResult>>> GetSmokerLookups(SmokerSelectRequest request);
        Task<Response<List<PaymentFrequentSelectResult>>> GetPaymentFrequentLookups(PaymentFrequentSelectRequest request);
        Task<Response<List<TitleSelectResult>>> GetTittlesLookups(TitleSelectRequest request);
        Task<Response<List<GenderSelectResult>>> GetGendersLookups(GenderSelectRequest request);
    }
}

using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;

namespace Polly_C.Horizon.Models.Repositories.Customer
{
    public interface IClientServicingRepository
    {
        Task<List<CustomerPolicyInfoResult>> GetCustomerPolicyInfoByEntityNo(EntityNoRequest EntityNoRequest);

        Task<List<BankAccountTypeResult>> GetBankAccountTypeLookups(BankAccountTypeRequest bankAccountTypeSelectRequest);

        Task<List<BankResult>> GetBankLookups(BankRequest bankRequest);

        Task<List<PersonSearchResult>> AdvancedPersonSearch(AdvancedPersonSearchRequest advancedPersonSearchRequest);
        Task<List<PersonSearchResult>> PersonSearch(PersonSearchRequest personSearchRequest);

        Task<List<BenefitExtendedMemberResult>> GetBenefitExtendedMemberDetails(BenefitExtendedMemberRequest request);

        Task<List<BeneficiaryDetailsResult>> GetBeneficiaryDetails(BeneficiaryDetailsRequest request);
        Task<List<GetPolicyAndMainMemberDetailsResult>> GetPolicyAndMainMemberDetails(GetPolicyAndMainMemberDetailsRequest request);
        Task<List<SmokerSelectResult>> GetSmokerLookups(SmokerSelectRequest request);
        Task<List<PaymentFrequentSelectResult>> GetPaymentFrequentLookups(PaymentFrequentSelectRequest request);
        Task<List<TitleSelectResult>> GetTittlesLookups(TitleSelectRequest request);
        Task<List<GenderSelectResult>> GetGendersLookups(GenderSelectRequest request);

    }
}

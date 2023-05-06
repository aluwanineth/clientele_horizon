//using AutoMapper;
using AutoMapper;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;
using Polly_C.Horizon.Models.Wrappers;
using Polly_C.Horizon.Data.Polly_C.Models;
using Polly_C.Horizon.Data.Customer.Models;

namespace Polly_C.Horizon.Models.Repositories.Customer.MappingProfiles
{
    public class ClientServicingMappingProfiles : Profile
    {
        public ClientServicingMappingProfiles()
        {
            CreateMap<Response<List<spAdvancedPersonSearchResult>>, Response<List<PersonSearchResult>>>();
            CreateMap<Response<List<spPersonSearchResult>>, Response<List<PersonSearchResult>>>();

            CreateMap<spAdvancedPersonSearchResult, PersonSearchResult>()
                .ForMember(x => x.EntityFullname, opt => opt.MapFrom(src => $"{src.EntityName} {src.EntitySurname}"));

            CreateMap<spPersonSearchResult, PersonSearchResult>()
                .ForMember(x => x.EntityFullname, opt => opt.MapFrom(src => $"{src.EntityName} {src.EntitySurname}"));

            CreateMap<spCustomerPolicyInfoResult, CustomerPolicyInfoResult>();
            CreateMap<spDALBankAccTypeSelectResult, BankAccountTypeResult>();
            CreateMap<spDALBankSelectResult, BankResult>();
            CreateMap<spGetBenefitExtendedMemberDetailsResult, BenefitExtendedMemberResult>();
            CreateMap<spGetBeneficiaryDetailsResult, BeneficiaryDetailsResult>();
            CreateMap<spGetPolicyAndMainMemberDetailsResult, GetPolicyAndMainMemberDetailsResult>();
            CreateMap<spDALC_SmokerSelectResult, SmokerSelectResult>();
            CreateMap<spDALC_Payment_FreqSelectResult, PaymentFrequentSelectResult>();
            CreateMap<spDALGenderSelectResult, GenderSelectResult>();
            CreateMap<spDALTitleSelectResult, TitleSelectResult>();
        }
    }
}

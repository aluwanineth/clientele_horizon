using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using AutoMapper;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;
using Polly_C.Horizon.Data.Polly_C.Models;
using Polly_C.Horizon.Data.Customer.Models;

namespace Polly_C.Horizon.Models.Repositories.Customer
{
    public class ClientServicingRepository : IClientServicingRepository
    {
        private readonly CustomerContext _context;
        private readonly Polly_CContext _pollyCContext;

        private readonly IMapper _mapper;

        public ClientServicingRepository(CustomerContext context, Polly_CContext pollyCContext, IMapper mapper)
        {
            _context = context;
            _pollyCContext = pollyCContext;
            _mapper = mapper;
        }

        public virtual async Task<List<CustomerPolicyInfoResult>> GetCustomerPolicyInfoByEntityNo(EntityNoRequest EntityNoRequest)
        {
                var result = await _context.GetProcedures().spCustomerPolicyInfoAsync(EntityNoRequest.EntityNo);
                return _mapper.Map<List<CustomerPolicyInfoResult>>(result);
        }

        public virtual async Task<List<PersonSearchResult>> AdvancedPersonSearch(AdvancedPersonSearchRequest advancedPersonSearchRequest)
        {
                var result = await _context.GetProcedures().spAdvancedPersonSearchAsync(advancedPersonSearchRequest.EncashmentNo, advancedPersonSearchRequest.BusRegNo, advancedPersonSearchRequest.AppFormNo, advancedPersonSearchRequest.EmailAddress, advancedPersonSearchRequest.BusinessName, advancedPersonSearchRequest.FullName);
                
            return _mapper.Map<List<PersonSearchResult>>(result);
        }

        public virtual async Task<List<PersonSearchResult>> PersonSearch(PersonSearchRequest personSearchRequest)
        {
                var result = await _context.GetProcedures().spPersonSearchAsync(personSearchRequest.PolicyNo, personSearchRequest.LegPolNo, personSearchRequest.IFANo, personSearchRequest.ClientEntityNo, personSearchRequest.LegalRefNo, personSearchRequest.CellNo);
                return _mapper.Map<List<PersonSearchResult>>(result);
        }

        public async Task<List<BankResult>> GetBankLookups(BankRequest dalBankSelectRequest)
        {
            var result = await _context.GetProcedures().spDALBankSelectAsync(dalBankSelectRequest.BankID, dalBankSelectRequest.BankName,
                dalBankSelectRequest.BankShortName, dalBankSelectRequest.DispSeq, dalBankSelectRequest.IsActive,
                dalBankSelectRequest.LastChanged, dalBankSelectRequest.UserID);
            return _mapper.Map<List<BankResult>>(result);
        }

        public async Task<List<BankAccountTypeResult>> GetBankAccountTypeLookups(BankAccountTypeRequest dalBankAccountTypeSelectRequest)
        {
                var result = await _context.GetProcedures().spDALBankAccTypeSelectAsync(dalBankAccountTypeSelectRequest.BankAccTypeCD, dalBankAccountTypeSelectRequest.BankAccTypeDesc, dalBankAccountTypeSelectRequest.BankAccTypeRegEx, dalBankAccountTypeSelectRequest.DispSeq, dalBankAccountTypeSelectRequest.IsActive, dalBankAccountTypeSelectRequest.LastChanged, dalBankAccountTypeSelectRequest.UserID);
                return _mapper.Map<List<BankAccountTypeResult>>(result);
        }

        public async Task<List<BenefitExtendedMemberResult>> GetBenefitExtendedMemberDetails(BenefitExtendedMemberRequest request)
        {
            var result = await _pollyCContext.GetProcedures().spGetBenefitExtendedMemberDetailsAsync(request.PolicyNO, request.EffectiveDate);
            return _mapper.Map<List<BenefitExtendedMemberResult>>(result);
        }
        public async Task<List<BeneficiaryDetailsResult>> GetBeneficiaryDetails(BeneficiaryDetailsRequest request)
        {
            var result = await _pollyCContext.GetProcedures().spGetBeneficiaryDetailsAsync(request.PolicyNo);
            return _mapper.Map<List<BeneficiaryDetailsResult>>(result);
        }

        public async Task<List<GetPolicyAndMainMemberDetailsResult>> GetPolicyAndMainMemberDetails(GetPolicyAndMainMemberDetailsRequest request)
        {
            var result = await _pollyCContext.GetProcedures().spGetPolicyAndMainMemberDetailsAsync(request.PolicyNo);
            return _mapper.Map<List<GetPolicyAndMainMemberDetailsResult>>(result);
        }

        public async Task<List<SmokerSelectResult>> GetSmokerLookups(SmokerSelectRequest request)
        {
            var result = await _pollyCContext.GetProcedures().spDALC_SmokerSelectAsync(request.Smoker_CD, request.S_Desc,
                    request.Disp_Seq, request.Eff_Date, request.Exp_Date);
            return _mapper.Map<List<SmokerSelectResult>>(result);
        }

        public async Task<List<PaymentFrequentSelectResult>> GetPaymentFrequentLookups(PaymentFrequentSelectRequest request)
        {
            var result = await _pollyCContext.GetProcedures().spDALC_Payment_FreqSelectAsync(request.Payment_Freq_CD, request.Short_Desc,
                     request.Disp_Seq, request.Eff_Date, request.Exp_Date);
            return _mapper.Map<List<PaymentFrequentSelectResult>>(result);
        }

        public async Task<List<TitleSelectResult>> GetTittlesLookups(TitleSelectRequest request)
        {
            var result = await _context.GetProcedures().spDALTitleSelectAsync(request.Title_CD,request.S_Desc, request.Disp_Seq,
                  request.Eff_Date, request.Exp_Date);
            return _mapper.Map<List<TitleSelectResult>>(result);
        }

        public async Task<List<GenderSelectResult>> GetGendersLookups(GenderSelectRequest request)
        {
            var result = await _context.GetProcedures().spDALGenderSelectAsync(request.Gender_CD, request.S_Desc,
                    request.Disp_Seq, request.Eff_Date, request.Exp_Date);
            return _mapper.Map<List<GenderSelectResult>>(result);
        }
    }
}

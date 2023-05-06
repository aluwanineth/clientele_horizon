using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly_C.Horizon.Data.Polly_C.Models;
using Polly_C.Horizon.Models.Integration.v1;
using Polly_C.Horizon.Models.v1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.Policy
{
    public class PolicyRepository : IPolicyRepository
    {
        Polly_CContext _context;
        public PolicyRepository(Polly_CContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateNewPolicyV1(MessagePolicyV1 policyToCreate)
        {
            var retMessage = string.Empty;

            if (policyToCreate?.Policy != null && policyToCreate.Policy.Product != null)
            {
                OutputParameter<string> outMessage = new OutputParameter<string>();

                System.Data.DataTable entity = new System.Data.DataTable("Entity");
                System.Data.DataTable benefit = new System.Data.DataTable("Benefit");
                System.Data.DataTable address = new System.Data.DataTable("MemberAddr");
                System.Data.DataTable contact = new System.Data.DataTable("MemberContact");
                CreateDataTableColums(entity, benefit, address, contact);

                var policy = policyToCreate.Policy;
                var product = policy.Product;
                var bankingDetails = policy?.BankingDetails;

                bool hasBankingDetails = bankingDetails != null;

                if (policy?.Entities != null && policy.Entities.Any())
                {
                    for (int entityRefNumber = 0; entityRefNumber < policy.Entities.Count; entityRefNumber++)
                    {
                        v1.EntityV1 policyEntity = policy.Entities[entityRefNumber];
                        PopulatePersonalDetails(entity, entityRefNumber, policyEntity);
                        PopulateBenefits(benefit, entityRefNumber, policyEntity);
                        PopulateAddresses(address, entityRefNumber, policyEntity);
                        PopulateContactDetails(contact, entityRefNumber, policyEntity);
                    }
                }


                var result = await _context.GetProcedures().spNewBusinessProcessAsync(policy.Source,
                    policyToCreate.MessageId,
                    (int)policy.Status,
                    policy.SaleDivision,
                    policy.AgentName,
                    policy.AgentCode,
                    policy.SourcePolicyNumber,
                    policy.CaptureDate,
                    policy.NewInceptionDate,
                    product.MasterContractProductCode,
                    product.ProductCode,
                    product.Premium,
                    product.PartnerCD,
                    product.SchemeCD,
                    hasBankingDetails ? bankingDetails.DebitDay : null,
                    hasBankingDetails ? bankingDetails.BankName : null,
                    hasBankingDetails ? bankingDetails.BranchCodeName : null,
                    hasBankingDetails ? bankingDetails.BranchCode.ToString() : null,
                    hasBankingDetails ? bankingDetails.AccountNumber.ToString() : null,
                    hasBankingDetails ? (int)bankingDetails.PaymentMethod : null,
                    hasBankingDetails ? (int)bankingDetails.BankAccountType : null,
                    hasBankingDetails ? bankingDetails.AccountHolder : null,
                    policy.NewInceptionDate,
                    entity,
                    benefit,
                    address,
                    contact,
                    outMessage);


                retMessage = outMessage?.Value ?? "No return message";
                return retMessage == "Successful";
            }

            retMessage = "Policy is invalid.";
            return false;
        }

        private static void PopulateContactDetails(DataTable contact, int entityRefNumber, EntityV1 policyEntity)
        {
            if (policyEntity?.ContactDetails != null)
            {
                if (!string.IsNullOrEmpty(policyEntity.ContactDetails?.HomeNumber))
                    contact.Rows.Add(entityRefNumber, TelecomTypeV1.HomeNumber, policyEntity.ContactDetails?.HomeNumber);

                if (!string.IsNullOrEmpty(policyEntity.ContactDetails?.WorkNumber))
                    contact.Rows.Add(entityRefNumber, TelecomTypeV1.WorkNumber, policyEntity.ContactDetails?.WorkNumber);

                if (!string.IsNullOrEmpty(policyEntity.ContactDetails?.MobileNumber))
                    contact.Rows.Add(entityRefNumber, TelecomTypeV1.Mobile, policyEntity.ContactDetails?.MobileNumber);

                if (!string.IsNullOrEmpty(policyEntity.ContactDetails?.FaxNumber))
                    contact.Rows.Add(entityRefNumber, TelecomTypeV1.FaxNumber, policyEntity.ContactDetails?.FaxNumber);

                if (!string.IsNullOrEmpty(policyEntity.ContactDetails?.EmailAddress))
                    contact.Rows.Add(entityRefNumber, TelecomTypeV1.Email, policyEntity.ContactDetails?.EmailAddress);
            }
        }

        private static void PopulateAddresses(DataTable address, int entityRefNumber, EntityV1 policyEntity)
        {
            if (policyEntity?.PhysicalAddress != null && !string.IsNullOrEmpty(policyEntity.PhysicalAddress.AddressLine1))
            {
                address.Rows.Add(entityRefNumber, AddressTypeV1.PhysicalAddress,
                    policyEntity.PhysicalAddress.AddressLine1,
                    policyEntity.PhysicalAddress.AddressLine2,
                    policyEntity.PhysicalAddress.Suburb,
                    policyEntity.PhysicalAddress.City,
                    string.IsNullOrWhiteSpace(policyEntity.PhysicalAddress.PostalCode) ? null : policyEntity.PhysicalAddress.PostalCode);
            }

            if (policyEntity?.PostalAddress != null && !string.IsNullOrEmpty(policyEntity.PostalAddress.AddressLine1))
            {
                address.Rows.Add(entityRefNumber, AddressTypeV1.PostalAddress,
                    policyEntity.PostalAddress.AddressLine1,
                    policyEntity.PostalAddress.AddressLine2,
                    policyEntity.PostalAddress.Suburb,
                    policyEntity.PostalAddress.City,
                    string.IsNullOrWhiteSpace(policyEntity.PostalAddress.PostalCode) ? null : policyEntity.PostalAddress.PostalCode);
            }
        }

        private static void PopulateBenefits(DataTable benefit, int entityRefNumber, EntityV1 policyEntity)
        {
            if (policyEntity?.Benefits != null && policyEntity.Benefits.Any())
            {
                foreach (var policyEntityBenefit in policyEntity.Benefits)
                {
                    benefit.Rows.Add(entityRefNumber, policyEntityBenefit.BenefitName,
                        policyEntityBenefit.BenefitCode,
                        policyEntityBenefit.CoverAmount,
                        policyEntityBenefit.Premium,
                        (int)policyEntityBenefit.Status);
                }
            }
        }

        private static void PopulatePersonalDetails(DataTable entity, int entityRefNumber, EntityV1 policyEntity)
        {
            v1.PersonalDetailsV1 personalDetails = policyEntity.PersonalDetails;
            entity.Rows.Add((int)policyEntity.EntityType,
                personalDetails.FirstName,
                personalDetails.LastName,
                personalDetails.FullName,
                personalDetails.LegalReferenceNumber,
                (int)personalDetails.LegalReferenceNumberType,
                 personalDetails.DoB == DateTime.MinValue ? null : personalDetails.DoB,
                (int)personalDetails.Title,
                (int)personalDetails.Gender,
                (int)personalDetails.Smoker,
                (int)personalDetails.PreferredCommType, entityRefNumber);
        }

        private static void CreateDataTableColums(DataTable entity, DataTable benefit, DataTable address, DataTable contact)
        {

            entity.Columns.Add("EntityTypeCD", typeof(int));
            entity.Columns.Add("FirstName", typeof(string));
            entity.Columns.Add("LastName", typeof(string));
            entity.Columns.Add("FullName", typeof(string));
            entity.Columns.Add("LegalRefNo", typeof(string));
            entity.Columns.Add("LegalRefNoType", typeof(int));
            entity.Columns.Add("DOB", typeof(DateTime));
            entity.Columns.Add("TitleCD", typeof(int));
            entity.Columns.Add("GenderCD", typeof(int));
            entity.Columns.Add("SmokerCD", typeof(int));
            entity.Columns.Add("PreferredContact", typeof(int));
            entity.Columns.Add("EntityReference", typeof(int));

            benefit.Columns.Add("EntityReference", typeof(int));
            benefit.Columns.Add("BenefitName", typeof(string));
            benefit.Columns.Add("BenefitCode", typeof(string));
            benefit.Columns.Add("CoverAmount", typeof(decimal));
            benefit.Columns.Add("Premium", typeof(decimal));
            benefit.Columns.Add("StatusCD", typeof(int));

            address.Columns.Add("EntityReference", typeof(int));
            address.Columns.Add("AddrTypeCD", typeof(int));
            address.Columns.Add("AddressLine1", typeof(string));
            address.Columns.Add("AddressLine2", typeof(string));
            address.Columns.Add("Suburb", typeof(string));
            address.Columns.Add("City", typeof(string));
            address.Columns.Add("PostalCode", typeof(int));

            contact.Columns.Add("EntityReference", typeof(int));
            contact.Columns.Add("ContactTypeCD", typeof(int));
            contact.Columns.Add("ContactDetail", typeof(string));
        }
    }
}

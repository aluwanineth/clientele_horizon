﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly_C.Horizon.Data.Customer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Data.Customer.Models
{
    public partial class CustomerContext
    {
        private ICustomerContextProcedures _procedures;

        public virtual ICustomerContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new CustomerContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ICustomerContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<spAdvancedPersonSearchResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spCustomerPolicyInfoResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spDALBankAccTypeSelectResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spDALBankSelectResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spDALGenderSelectResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spDALTitleSelectResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spPersonSearchResult>().HasNoKey().ToView(null);
        }
    }

    public partial class CustomerContextProcedures : ICustomerContextProcedures
    {
        private readonly CustomerContext _context;

        public CustomerContextProcedures(CustomerContext context)
        {
            _context = context;
        }

        public virtual async Task<List<spAdvancedPersonSearchResult>> spAdvancedPersonSearchAsync(string encashmentNo, string busRegNo, string appFormNo, string emailAddress, string businessName, string fullName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "encashmentNo",
                    Size = 50,
                    Value = encashmentNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "busRegNo",
                    Size = 20,
                    Value = busRegNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "appFormNo",
                    Size = 20,
                    Value = appFormNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "emailAddress",
                    Size = 100,
                    Value = emailAddress ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "businessName",
                    Size = 100,
                    Value = businessName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "fullName",
                    Size = 100,
                    Value = fullName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spAdvancedPersonSearchResult>("EXEC @returnValue = [custpr].[spAdvancedPersonSearch] @encashmentNo, @busRegNo, @appFormNo, @emailAddress, @businessName, @fullName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spCustomerPolicyInfoResult>> spCustomerPolicyInfoAsync(string EntityNo, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "EntityNo",
                    Size = 100,
                    Value = EntityNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spCustomerPolicyInfoResult>("EXEC @returnValue = [custpr].[spCustomerPolicyInfo] @EntityNo", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spDALBankAccTypeSelectResult>> spDALBankAccTypeSelectAsync(byte? BankAccTypeCD, string BankAccTypeDesc, string BankAccTypeRegEx, short? DispSeq, bool? IsActive, DateTime? LastChanged, string UserID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "BankAccTypeCD",
                    Value = BankAccTypeCD ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                },
                new SqlParameter
                {
                    ParameterName = "BankAccTypeDesc",
                    Size = 100,
                    Value = BankAccTypeDesc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "BankAccTypeRegEx",
                    Size = 100,
                    Value = BankAccTypeRegEx ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "DispSeq",
                    Value = DispSeq ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallInt,
                },
                new SqlParameter
                {
                    ParameterName = "IsActive",
                    Value = IsActive ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                new SqlParameter
                {
                    ParameterName = "LastChanged",
                    Value = LastChanged ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallDateTime,
                },
                new SqlParameter
                {
                    ParameterName = "UserID",
                    Size = 50,
                    Value = UserID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spDALBankAccTypeSelectResult>("EXEC @returnValue = [configpr].[spDALBankAccTypeSelect] @BankAccTypeCD, @BankAccTypeDesc, @BankAccTypeRegEx, @DispSeq, @IsActive, @LastChanged, @UserID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spDALBankSelectResult>> spDALBankSelectAsync(int? BankID, string BankName, string BankShortName, short? DispSeq, bool? IsActive, DateTime? LastChanged, string UserID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "BankID",
                    Value = BankID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "BankName",
                    Size = 50,
                    Value = BankName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "BankShortName",
                    Size = 20,
                    Value = BankShortName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "DispSeq",
                    Value = DispSeq ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallInt,
                },
                new SqlParameter
                {
                    ParameterName = "IsActive",
                    Value = IsActive ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                new SqlParameter
                {
                    ParameterName = "LastChanged",
                    Value = LastChanged ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallDateTime,
                },
                new SqlParameter
                {
                    ParameterName = "UserID",
                    Size = 50,
                    Value = UserID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spDALBankSelectResult>("EXEC @returnValue = [configpr].[spDALBankSelect] @BankID, @BankName, @BankShortName, @DispSeq, @IsActive, @LastChanged, @UserID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spDALGenderSelectResult>> spDALGenderSelectAsync(byte? Gender_CD, string S_Desc, short? Disp_Seq, DateTime? Eff_Date, DateTime? Exp_Date, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Gender_CD",
                    Value = Gender_CD ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                },
                new SqlParameter
                {
                    ParameterName = "S_Desc",
                    Size = 30,
                    Value = S_Desc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Disp_Seq",
                    Value = Disp_Seq ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallInt,
                },
                new SqlParameter
                {
                    ParameterName = "Eff_Date",
                    Value = Eff_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "Exp_Date",
                    Value = Exp_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spDALGenderSelectResult>("EXEC @returnValue = [configpr].[spDALGenderSelect] @Gender_CD, @S_Desc, @Disp_Seq, @Eff_Date, @Exp_Date", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spDALTelecomTypeSelectAsync(int? TelTypeCD, string CountryCode, string TelTypeCode, string TelTypeDesc, string TelTypeRegEx, short? DispSeq, bool? IsActive, DateTime? LastChanged, string UserID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "TelTypeCD",
                    Value = TelTypeCD ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "CountryCode",
                    Size = 3,
                    Value = CountryCode ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "TelTypeCode",
                    Size = 20,
                    Value = TelTypeCode ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "TelTypeDesc",
                    Size = 100,
                    Value = TelTypeDesc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "TelTypeRegEx",
                    Size = 100,
                    Value = TelTypeRegEx ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "DispSeq",
                    Value = DispSeq ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallInt,
                },
                new SqlParameter
                {
                    ParameterName = "IsActive",
                    Value = IsActive ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                new SqlParameter
                {
                    ParameterName = "LastChanged",
                    Value = LastChanged ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallDateTime,
                },
                new SqlParameter
                {
                    ParameterName = "UserID",
                    Size = 50,
                    Value = UserID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [configpr].[spDALTelecomTypeSelect] @TelTypeCD, @CountryCode, @TelTypeCode, @TelTypeDesc, @TelTypeRegEx, @DispSeq, @IsActive, @LastChanged, @UserID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spDALTitleSelectResult>> spDALTitleSelectAsync(int? Title_CD, string S_Desc, short? Disp_Seq, DateTime? Eff_Date, DateTime? Exp_Date, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Title_CD",
                    Value = Title_CD ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "S_Desc",
                    Size = 30,
                    Value = S_Desc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Disp_Seq",
                    Value = Disp_Seq ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.SmallInt,
                },
                new SqlParameter
                {
                    ParameterName = "Eff_Date",
                    Value = Eff_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "Exp_Date",
                    Value = Exp_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spDALTitleSelectResult>("EXEC @returnValue = [configpr].[spDALTitleSelect] @Title_CD, @S_Desc, @Disp_Seq, @Eff_Date, @Exp_Date", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spPersonSearchResult>> spPersonSearchAsync(string policyNo, string legPolNo, string IFANo, string clientEntityNo, string legalRefNo, string cellNo, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "policyNo",
                    Size = 50,
                    Value = policyNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "legPolNo",
                    Size = 20,
                    Value = legPolNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "IFANo",
                    Size = 20,
                    Value = IFANo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "clientEntityNo",
                    Size = 10,
                    Value = clientEntityNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "legalRefNo",
                    Size = 13,
                    Value = legalRefNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "cellNo",
                    Size = 10,
                    Value = cellNo ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spPersonSearchResult>("EXEC @returnValue = [custpr].[spPersonSearch] @policyNo, @legPolNo, @IFANo, @clientEntityNo, @legalRefNo, @cellNo", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}

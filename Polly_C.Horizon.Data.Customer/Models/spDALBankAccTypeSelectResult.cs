﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polly_C.Horizon.Data.Customer.Models
{
    public partial class spDALBankAccTypeSelectResult
    {
        public byte BankAccTypeCD { get; set; }
        public string BankAccTypeDesc { get; set; }
        public string BankAccTypeRegEx { get; set; }
        public short? DispSeq { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastChanged { get; set; }
        public string UserID { get; set; }
    }
}
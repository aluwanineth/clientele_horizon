﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Polly_C.Horizon.Data.Polly_C.Models;

public partial class Polly_CContext : DbContext
{
    public Polly_CContext(DbContextOptions<Polly_CContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("PartnerImportLogSeq", "utils");
        modelBuilder.HasSequence<int>("PartnerLogicalTableSeq", "utils");
        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
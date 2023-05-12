using DwapiCentral.Contracts.Ct;
using DwapiCentral.Ct.Domain.Models;
using DwapiCentral.Ct.Domain.Models.Extracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence.Context
{
    public class DwapiCentralContext : DbContext
    {
        public DbSet<PatientExtract> PatientExtracts { get; set; }  
        public DbSet<AllergiesChronicIllnessExtract> AllergiesChronicIllnessExtracts { get; set; }
        public DbSet<ContactListingExtract> contactListingExtracts { get; set; }
        public DbSet<CovidExtract> CovidExtracts { get; set; }
        public DbSet<DefaulterTracingExtract> DefaulterTracingExtracts { get; set; }
        public DbSet<DepressionScreeningExtract> DepressionScreeningExtracts { get; set; }
        public DbSet<DrugAlcoholScreeningExtract> DrugAlcoholScreeningExtracts { get; set; } 
        public DbSet<EnhancedAdherenceCounsellingExtract> EnhancedAdherenceCounsellingExtracts { get; set; }
        public DbSet<GbvScreeningExtract> GbvScreeningExtracts { get; set; }
        public DbSet<IptExtract> IptExtracts { get; set; }
        public DbSet<OvcExtract> OvcExtracts { get; set; }
        public DbSet<OtzExtract> OtzExtracts { get; set; }
        public DbSet<PatientAdverseEventExtract> PatientAdverseEventExtracts { get; set; }  
        public DbSet<PatientArtExtract> PatientArtExtracts { get; set; }
        public DbSet<PatientBaselinesExtract> PatientBaselinesExtracts { get; set; }
        public DbSet<PatientLaboratoryExtract> PatientLaboratoryExtracts { get; set; }
        public DbSet<PatientPharmacyExtract> PatientPharmacyExtracts { get; set; }
        public DbSet<PatientStatusExtract> PatientStatusExtracts { get; set; }
        public DbSet<PatientVisitExtract> PatientVisitExtracts { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Manifest> Manifests { get; set; }  
        public DbSet<MasterFacility> MasterFacilities { get; set; }
        public DbSet<Metric> Metrics { get; set; }



        public DwapiCentralContext(DbContextOptions<DwapiCentralContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientExtract>()
            .HasIndex(p => new { p.PatientPID, p.SiteCode, p.FacilityId })
            .IsUnique(true);

            //configuration for setting the relationship
            modelBuilder.Entity<AllergiesChronicIllnessExtract>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.AllergiesChronicIllnessExtracts)
                .HasForeignKey(p =>p.PatientId);

            //Configuration for index
            modelBuilder.Entity<AllergiesChronicIllnessExtract>()
                .HasIndex(p => new { p.PatientId, p.VisitID, p.VisitDate })
                .IsUnique(true);

            modelBuilder.Entity<ContactListingExtract>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.ContactListingExtracts)
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<ContactListingExtract>()
                .HasIndex(p=> new { p.SiteCode,p.PatientId})
                .IsUnique(true);

            modelBuilder.Entity<CovidExtract>()
                .HasOne(p=>p.Patient)
                .WithMany(p => p.CovidExtracts)
                .HasForeignKey(p=>p.PatientId);

            modelBuilder.Entity<CovidExtract>()
                .HasIndex(p => new { p.PatientId,p.SiteCode})
                .IsUnique(true);

            modelBuilder.Entity<DefaulterTracingExtract>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.DefaulterTracingExtracts)
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<DefaulterTracingExtract>()
                .HasIndex(p => new { p.PatientId,p.SiteCode})
                .IsUnique(true);

            modelBuilder.Entity<DepressionScreeningExtract>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.DepressionScreeningExtracts)
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<PatientLaboratoryExtract>()
                .HasIndex(p => new {p.SiteCode,p.PatientId,p.OrderedByDate,p.TestResult,p.TestName })
                .IsUnique(true);



            modelBuilder.Entity<PatientVisitExtract>()
                .HasIndex(p => new { p.VisitId, p.VisitDate, p.PatientId })
                .IsUnique(true);

            modelBuilder.Entity<PatientBaselinesExtract>()
                .HasIndex(p => new { p.PatientId,p.SiteCode })
                .IsUnique(true);

            modelBuilder.Entity<PatientBaselinesExtract>()
              .HasOne(p => p.Patient)
              .WithMany(p => p.PatientBaselinesExtracts)
              .HasForeignKey(p => p.PatientId);






            modelBuilder.Entity<Facility>()
                .HasIndex(f => f.Id)
                .IsUnique(true);

            base.OnModelCreating(modelBuilder);

        }
    }
}

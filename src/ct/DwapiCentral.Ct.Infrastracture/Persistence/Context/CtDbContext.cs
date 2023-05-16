using DwapiCentral.Ct.Application.DTOs;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Shared.Domain.Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence.Context
{
    public class CtDbContext : DbContext
    {
        public DbSet<PatientExtract> Patients { get; set; }
        public DbSet<MasterFacility> FasterFacilities { get; set; }
        public DbSet<Facility> Facility { get; set; }
        public DbSet<Domain.Models.Extracts.Manifest> Manifests { get; set; }
        public string ConnectionString { get; internal set; }

        public CtDbContext(DbContextOptions<CtDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientExtract>()
                .HasIndex(p =>new {p.PatientPID,p.FacilityId})
                .IsUnique(true);


            base.OnModelCreating(modelBuilder);
        }



    }
}

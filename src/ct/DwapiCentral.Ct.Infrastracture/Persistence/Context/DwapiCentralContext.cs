using DwapiCentral.Ct.Application.DTOs;
using DwapiCentral.Ct.Domain.Models.Extracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence.Context
{
    public class DwapiCentralContext : DbContext
    {
        public DbSet<PatientExtract> Patients { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public string ConnectionString { get; internal set; }

        public DwapiCentralContext(DbContextOptions<DwapiCentralContext> options) : base(options)
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

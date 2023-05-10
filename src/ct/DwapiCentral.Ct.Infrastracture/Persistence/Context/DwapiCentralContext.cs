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

        public DwapiCentralContext(DbContextOptions<DwapiCentralContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientExtract>().HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }



    }
}

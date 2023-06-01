﻿using Dapper;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Ct.Domain.Repository;
using DwapiCentral.Ct.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace DwapiCentral.Ct.Infrastructure.Persistence.Repository
{
    public class AllergiesChronicIllnessRepository : IAllergiesChronicIllnessRepository
    {
        private readonly CtDbContext _context;

        public AllergiesChronicIllnessRepository(CtDbContext context)
        {
            _context = context;
        }

        public Task MergeAsync(IEnumerable<AllergiesChronicIllnessExtract> allergiesChronicIllnessExtracts)
        {
            var distinctExtracts = allergiesChronicIllnessExtracts
               .GroupBy(e => new { e.PatientPk, e.SiteCode, e.VisitID, e.VisitDate })
               .Select(g => g.OrderByDescending(e => e.Id).First()).ToList();

          var existingExtracts = _context.AllergiesChronicIllnessExtracts
                 .AsEnumerable()
                 .Where(e => distinctExtracts.Any(d =>
                     d.PatientPk == e.PatientPk &&
                     d.SiteCode == e.SiteCode &&
                     d.VisitID == e.VisitID &&
                     d.VisitDate == e.VisitDate
                    ))
                 .ToList();

            var distinctToInsert = distinctExtracts
                .Where(d => !existingExtracts.Any(e =>
                    d.PatientPk == e.PatientPk &&
                    d.SiteCode == e.SiteCode &&
                    d.VisitID == e.VisitID &&
                    d.VisitDate == e.VisitDate))
                .ToList();

            _context.Database.GetDbConnection().BulkMerge(distinctToInsert);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}

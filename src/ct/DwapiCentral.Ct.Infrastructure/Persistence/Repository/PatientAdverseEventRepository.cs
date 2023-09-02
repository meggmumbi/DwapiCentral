﻿using Dapper;
using DwapiCentral.Ct.Domain.Models;

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
    public class PatientAdverseEventRepository : IPatientAdverseEventRepository
    {
        private readonly CtDbContext _context;

        public PatientAdverseEventRepository(CtDbContext context)
        {
            _context = context;
        }
        public Task MergeAsync(IEnumerable<PatientAdverseEventExtract> patientAdverseEventExtracts)
        {
            var distinctExtracts = patientAdverseEventExtracts
               .GroupBy(e => new { e.PatientPk, e.SiteCode, e.VisitDate })
               .Select(g => g.OrderByDescending(e => e.Id).First()).ToList();

           


            var existingExtracts = _context.PatientAdverseEventExtract
                .AsEnumerable()
                .Where(e => distinctExtracts.Any(d =>
                    d.PatientPk == e.PatientPk &&
                    d.SiteCode == e.SiteCode &&
                    d.VisitDate == e.VisitDate
                   ))
                .ToList();

            var distinctToInsert = distinctExtracts
                .Where(d => !existingExtracts.Any(e =>
                    d.PatientPk == e.PatientPk &&
                    d.SiteCode == e.SiteCode &&
                    d.VisitDate == e.VisitDate))
                .ToList();



            _context.Database.GetDbConnection().BulkMerge(distinctToInsert);


            _context.SaveChangesAsync();

        
            return Task.CompletedTask;
        }

    }
}

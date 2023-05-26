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
    public class DepressionScreeningRepository : IDepressionScreeningRepository
    {
        private readonly CtDbContext _context;

        public DepressionScreeningRepository(CtDbContext context)
        {
            _context = context;
        }
        public Task MergeAsync(IEnumerable<DepressionScreeningExtract> depressionScreeningExtracts)
        {
            var distinctExtracts = depressionScreeningExtracts
               .GroupBy(e => new { e.PatientPk, e.SiteCode, e.VisitID, e.VisitDate })
               .Select(g => g.OrderByDescending(e => e.Id).First());

            _context.Database.GetDbConnection().BulkMerge(distinctExtracts);

            var extractIdsToKeep = distinctExtracts.Select(e => e.Id).ToList();
            var deleteQuery = $@"
                    DELETE FROM DepressionScreeningExtract
                    WHERE Id NOT IN ({string.Join(",", extractIdsToKeep)})
                ";

            _context.Database.GetDbConnection().ExecuteAsync(deleteQuery);



            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}

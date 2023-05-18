using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Ct.Infrastracture.Persistence.Context;
using DwapiCentral.Shared.Application.Interfaces.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly CtDbContext _dbContext;

        public FacilityRepository( CtDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<Facility> AddAsync(Facility facility)
        {
           var fac =  await _dbContext.Set<Facility>().AddAsync(facility);
            await _dbContext.SaveChangesAsync();
            return fac.Entity;
        }

        public Task<Facility> GetByIdAsync(int sitecode)
        {
            throw new NotImplementedException();
        }

        public Task<Facility> GetFacilityByIdAsync(int siteCode)
        {
            throw new NotImplementedException();
        }
    }
}

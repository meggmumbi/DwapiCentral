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
        private readonly DwapiCentralContext _dbContext;

        public FacilityRepository( DwapiCentralContext dbContext )
        {
            _dbContext = dbContext;
        }
        public async Task<Facility> GetFacilityByIdAsync(int siteCode)
        {
            return await _dbContext.Facilities.FindAsync(siteCode);
        }
    }
}

using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Infrastracture.Persistence.Context;
using DwapiCentral.Shared.Domain.Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence.Repository
{
    public class MasterFacilityRepository      
    {
        private readonly CtDbContext _dbContext;

        public MasterFacilityRepository( CtDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<MasterFacility> GetFacilityByIdAsync(int sitecode)
        {
            return await  _dbContext.Set<MasterFacility>().FirstOrDefaultAsync(f=>f.Code == sitecode);
        }
    }
}

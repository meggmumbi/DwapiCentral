using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Ct.Infrastracture.Persistence.Context;
using DwapiCentral.Shared.Application.Interfaces.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence.Repository
{
    public class ManifestRepository : IFacilityManifestRepository
    {
        private readonly CtDbContext _dbContext;

        public ManifestRepository( CtDbContext dbContext ) 
        { 
            _dbContext = dbContext;
        }

        public async Task<FacilityManifest> AddAsync(FacilityManifest manifest)
        {
            var facManifest = await _dbContext.Set<FacilityManifest>().AddAsync( manifest );
            await _dbContext.SaveChangesAsync();
            return facManifest.Entity;


        }
    }
}

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
    public class ManifestRepository : IFacilityManifest
    {
        private readonly DwapiCentralContext _dbContext;

        public ManifestRepository( DwapiCentralContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Manifest manifest)
        {
            await _dbContext.Set<Manifest>().AddAsync( manifest );
            await _dbContext.SaveChangesAsync();
        }
    }
}

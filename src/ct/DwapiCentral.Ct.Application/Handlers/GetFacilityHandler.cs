using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Application.Queries;
using DwapiCentral.Shared.Domain.Model.Common;
using log4net.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Handlers
{
    public class GetFacilityHandler : IRequestHandler<GetFacilityQuery, MasterFacility>
    {
        private IMasterFacilityRepository _masterFacilityRepository;

        private readonly ILogger<GetFacilityHandler> _logger;

        public GetFacilityHandler(IMasterFacilityRepository masterFacilityRepository, ILogger<GetFacilityHandler> logger)
        {
            _masterFacilityRepository = masterFacilityRepository;
            _logger = logger;
        }

        public async Task<MasterFacility> Handle(GetFacilityQuery request, CancellationToken cancellationToken)
        {
            return  await _masterFacilityRepository.GetFacilityByIdAsync(request.Manifest.SiteCode);
            
        }
    }
}

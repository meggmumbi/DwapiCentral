using DwapiCentral.Ct.Application.Command;
using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Application.Services;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Shared.Domain.Model.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Handlers
{
    public class CreateManifestHandler : IRequestHandler<CreateManifest, FacilityManifest>
    {
        private readonly IFacilityManifestRepository _facilityManifestRepository;
        private readonly ILogger<CreateManifestHandler> _logger;

        public CreateManifestHandler(IFacilityManifestRepository facilityManifestRepository, ILogger<CreateManifestHandler> logger)
        {
             _facilityManifestRepository = facilityManifestRepository;
            _logger = logger;
        }

        public Task<FacilityManifest> Handle(CreateManifest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public Task<FacilityManifest> Handle(CreateManifest request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Saving Manifest");

        //        var facManifest = FacilityManifest.Create(request.Manifest);

        //         var result = _facilityManifestRepository.AddAsync(facManifest);

        //        return result;


        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogInformation($"Error saving Manifest {ex}");
        //    }

        //}


    }
}

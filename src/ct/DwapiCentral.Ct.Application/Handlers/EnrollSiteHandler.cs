using DwapiCentral.Ct.Application.Command;
using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Domain.Models.Extracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DwapiCentral.Ct.Application.Handlers
{
    public class EnrollSiteHandler : IRequestHandler<EnrollSiteCommand, Facility>
    {
        private readonly IFacilityRepository _facilityRepository; 
        private readonly ILogger<EnrollSiteHandler> _logger;

        public EnrollSiteHandler(IFacilityRepository facilityRepository, ILogger<EnrollSiteHandler> logger)
        {
            _facilityRepository = facilityRepository;
            _logger = logger;
        }

        public async Task<Facility> Handle(EnrollSiteCommand request, CancellationToken cancellationToken)
        {
            var facility = new Facility(){
                Code= request.Code,
                Name= request.Name,               
                Created = request.Created,
                SnapshotDate = request.SnapshotDate,
                SnapshotSiteCode = request.SnapshotSiteCode,
                SnapshotVersion = request.SnapshotVersion,
                Id = request.Id,
                Emr = request.Emr,
                Project = request.Project,
                Voided = request.Voided,
                Processed = request.Processed
            };

            return await _facilityRepository.AddAsync(facility);
        }
    }
}

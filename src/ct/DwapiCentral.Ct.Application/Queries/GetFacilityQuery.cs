
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Shared.Domain.Model.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manifest = DwapiCentral.Ct.Domain.Models.Extracts.Manifest;

namespace DwapiCentral.Ct.Application.Queries
{
    public class GetFacilityQuery : IRequest<MasterFacility>
    {
        public Manifest Manifest { get; }
        public bool AllowSnapshot { get; }

        public GetFacilityQuery(Manifest manifest)
        {
            Manifest = manifest;

        }
    }
}

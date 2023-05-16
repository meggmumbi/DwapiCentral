using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Shared.Domain.Enums;
using DwapiCentral.Shared.Domain.Model.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manifest = DwapiCentral.Ct.Domain.Models.Extracts.Manifest;

namespace DwapiCentral.Ct.Application.Command
{
    public class CreateManifest : IRequest<FacilityManifest>
    {
        public Manifest Manifest { get; }   
        public MasterFacility MasterFacility { get; }
        public bool AllowSnapShot { get; } 

        public CreateManifest(Manifest manifest, MasterFacility masterFacility, bool allowSnapShot)
        {
            Manifest = manifest;
            MasterFacility = masterFacility;
            AllowSnapShot = allowSnapShot;
        }
    }
}

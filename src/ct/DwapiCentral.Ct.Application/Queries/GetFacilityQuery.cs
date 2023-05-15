using DwapiCentral.Ct.Domain.Models.Extracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Queries
{
    public class GetFacilityQuery : IRequest<Facility>
    {
        public int FacilityId { get; set; } 
    }
}

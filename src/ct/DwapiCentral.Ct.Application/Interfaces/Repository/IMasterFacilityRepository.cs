using DwapiCentral.Shared.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IMasterFacilityRepository
    {
        Task<MasterFacility> GetFacilityByIdAsync(int sitecode);
    }
}

using DwapiCentral.Ct.Domain.Models.Extracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IFacilityRepository
    {
        Task<Facility> GetByIdAsync(int sitecode);
        Task AddAsync(Facility facility);
    }
}

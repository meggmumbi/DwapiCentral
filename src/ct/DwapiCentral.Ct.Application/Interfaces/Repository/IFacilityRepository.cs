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
        public Task<Facility> GetByIdAsync(int sitecode);
        public Task<Facility> AddAsync(Facility facility);
        
        public Task<Facility> GetFacilityByIdAsync(int siteCode);
    }
}

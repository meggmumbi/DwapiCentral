using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface ICovidRepository
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(CovidSourceDto covidSourceDto);
    }
}

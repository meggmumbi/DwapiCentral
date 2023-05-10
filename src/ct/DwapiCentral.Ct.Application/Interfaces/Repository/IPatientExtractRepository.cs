using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DwapiCentral.Ct.Application.DTOs;
using DwapiCentral.Ct.Domain.Models.Extracts;

namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IPatientExtractRepository 
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(PatientExtract patient);

    }
}

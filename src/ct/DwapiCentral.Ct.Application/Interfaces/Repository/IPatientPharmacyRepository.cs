using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;


namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IPatientPharmacyRepository
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(PharmacySourceDto pharmacySourceDto);
    }
}

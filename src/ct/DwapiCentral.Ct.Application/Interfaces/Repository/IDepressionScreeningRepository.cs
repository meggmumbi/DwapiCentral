using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;


namespace DwapiCentral.Ct.Application.Interfaces.Repository
{

    public interface IDepressionScreeningRepository
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(DepressionScreeningSourceDto depressionScreeningSourceDto);

    }
}

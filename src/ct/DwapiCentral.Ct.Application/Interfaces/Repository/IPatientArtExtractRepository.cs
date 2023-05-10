
using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;


namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IPatientArtExtractRepository
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(ArtSourceDto artSourceDto);
    }
}

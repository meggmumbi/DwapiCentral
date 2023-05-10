using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;


namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IPatientVisitRepository
    {

        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(VisitSourceDto visitSourceDto);
    }
}
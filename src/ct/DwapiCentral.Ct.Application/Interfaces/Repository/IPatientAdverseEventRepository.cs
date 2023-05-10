using System;
using System.Collections.Generic;
using DwapiCentral.Ct.Application.DTOs;


namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IPatientAdverseEventRepository
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(AdverseEventSourceDto adverseEventSourceDto);

    }
}
using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;


namespace DwapiCentral.Ct.Application.Interfaces.Repository
{

    public interface IOvcRepository
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(OvcSourceDto ovcSourceDto);
    }
}

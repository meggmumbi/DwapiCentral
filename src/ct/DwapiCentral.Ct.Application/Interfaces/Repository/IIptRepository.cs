using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;


namespace DwapiCentral.Ct.Application.Interfaces.Repository
{

    public interface IIptRepository 
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(IptSourceDto iptSourceDto);
    }
}

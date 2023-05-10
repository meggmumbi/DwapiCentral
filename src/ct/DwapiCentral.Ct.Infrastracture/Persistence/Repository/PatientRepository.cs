using DwapiCentral.Ct.Application.DTOs;
using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Ct.Infrastracture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Infrastracture.Persistence.Repository
{
    public class PatientRepository : IPatientExtractRepository
    {
        private readonly DwapiCentralContext _dbContext;

        public PatientRepository(DwapiCentralContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PatientExtract patient)
        {
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int PatientId)
        {
            return await _dbContext.Patients.AnyAsync(p=>p.PatientPID== PatientId);
        }
    }
}

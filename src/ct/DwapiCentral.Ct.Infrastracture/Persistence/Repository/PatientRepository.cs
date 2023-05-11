using DwapiCentral.Ct.Application.DTOs;
using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Ct.Infrastracture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task AddPatientsAsync(IEnumerable<PatientExtract> patients)
        {
            var patientSet = new HashSet<PatientExtract>(patients);
            var existingPatients = await _dbContext.Patients
                .Where(p=>patientSet.Contains(p))
                .ToListAsync();  

            if(existingPatients.Any())
            {
                throw new ArgumentException($"Duplicate patients found: {string.Join(", ", existingPatients.Select(p => p.Id))}");
            }

            var importer = new SqlBulkImporter<PatientExtract>(_dbContext.ConnectionString);
            await importer.BulkInsertAsync(patientSet, "PatientExtract");

            



            //await _dbContext.Patients.AddRangeAsync(patients);
            //await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int PatientId)
        {
            return await _dbContext.Patients.AnyAsync(p=>p.PatientPID== PatientId);
        }
    }
}

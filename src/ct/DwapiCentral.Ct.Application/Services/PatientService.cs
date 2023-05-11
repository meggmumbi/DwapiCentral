using DwapiCentral.Ct.Application.DTOs;
using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Application.Interfaces.Services;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Shared.Domain.Model.Prep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Services
{
    public class PatientService : IPatientService
    {

        private readonly IPatientExtractRepository _patientRepository;
        
        public PatientService(IPatientExtractRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async void ProcessPatientData(IEnumerable<PatientExtract> patients)
        {
            //var distinctPatients = patients
            //    .GroupBy(p => p.PatientPID)
            //    .Select(g => g.First());

            //foreach (var patientDTO in distinctPatients)
            //{
            //    var exists = await _patientRepository.ExistsAsync(patientDTO.PatientPID);

            //    if (exists)
            //    {
            //        throw new Exception($"");
            //    }

            //    var patient = new PatientExtract
            //    {
            //        PatientPID = patientDTO.PatientPID

            //    };

            //    var uniquePatients = new HashSet<PatientExtract>(new PatientComparer());
            //foreach (var patient in patients)
            //{
            //    uniquePatients.Add(patient);
            //}


           

                await _patientRepository.AddPatientsAsync(patients);
            
        }
    }
}

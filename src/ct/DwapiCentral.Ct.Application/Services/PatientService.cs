﻿using DwapiCentral.Ct.Application.DTOs;
using DwapiCentral.Ct.Application.Interfaces.Repository;
using DwapiCentral.Ct.Application.Interfaces.Services;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Shared.Domain.Model.Prep;
using log4net.Core;
using Microsoft.Extensions.Logging;
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
        private readonly IFacilityRepository    _facilityRepository;        
        private readonly ILogger<PatientService> _logger;
        
        public PatientService(IPatientExtractRepository patientRepository, IFacilityRepository facilityRepository,ILogger<PatientService> logger)
        {
            _patientRepository = patientRepository;
            _facilityRepository = facilityRepository;           
            _logger = logger;
        }

        public async Task AddManifestAsync(Manifest manifest)
        {
            if(manifest.PatientCount <= 0)
            {
                throw new Exception("");
            }

            var facility = await _facilityRepository.GetFacilityByIdAsync(manifest.SiteCode);
            if (facility == null)
            {
                throw new ArgumentException($"Facility with ID {manifest.SiteCode} does not exist.");
            }

           // await _manifestRepository.AddAsync(manifest);

        }

        public async void ProcessPatientData(IEnumerable<PatientExtract> patients)
        {
            try
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

                _logger.LogInformation("Start saving...");

                //_logger.LogInformation($"Patients sent {patients.Count} patients");


                await _patientRepository.AddPatientsAsync(patients);

                _logger.LogInformation("data saved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save data");

                throw;
            }
            
        }
    }
}

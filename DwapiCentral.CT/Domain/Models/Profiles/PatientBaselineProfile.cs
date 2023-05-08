﻿using System;
using System.Collections.Generic;
using System.Linq;
using DwapiCentral.Shared.Application.Interfaces.Ct.Profiles;
using DwapiCentral.Shared.Domain.Model.Ct.DTOs;

namespace DwapiCentral.Shared.Domain.Model.Ct.Profiles
{
    public class PatientBaselineProfile : ExtractProfile<PatientBaselinesExtract>, IPatientBaselineProfile
    {
        public List<PatientBaselinesExtractDTO> BaselinesExtracts { get; set; } = new List<PatientBaselinesExtractDTO>();



        public static PatientBaselineProfile Create(Facility facility, PatientExtract patient)
        {
            var patientProfile = new PatientBaselineProfile
            {
                Facility = new FacilityDTO(facility),
                Demographic = new PatientExtractDTO(patient),
                BaselinesExtracts =
                    new PatientBaselinesExtractDTO().GeneratePatientBaselinesExtractDtOs(
                        patient.PatientBaselinesExtracts).ToList()
            };
            return patientProfile;
        }

        public static List<PatientBaselineProfile> Create(Facility facility, List<PatientExtract> patients)
        {
            var patientProfiles = new List<PatientBaselineProfile>();
            foreach (var patient in patients)
            {
                var patientProfile = Create(facility, patient);
                patientProfiles.Add(patientProfile);
            }

            return patientProfiles;
        }
        public override bool IsValid()
        {
            return base.IsValid() && BaselinesExtracts.Count > 0;
        }

        public override bool HasData()
        {
            return base.HasData() && null != BaselinesExtracts;
        }

        public override void GenerateRecords(Guid patientId)
        {
            base.GenerateRecords(patientId);
            foreach (var e in BaselinesExtracts)
                Extracts.Add(e.GeneratePatientBaselinesExtract(PatientInfo.Id));
        }
    }
}
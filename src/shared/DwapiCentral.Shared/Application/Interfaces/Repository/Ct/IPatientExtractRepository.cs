﻿
using DwapiCentral.Shared.Application.Interfaces.Ct;
using DwapiCentral.Shared.Domain.Model.Common;
using DwapiCentral.Shared.Domain.Model.Ct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manifest = DwapiCentral.Shared.Domain.Model.Ct.Manifest;

namespace DwapiCentral.Shared.Application.Interfaces.Repository.Ct
{
    public interface IPatientExtractRepository : IRepository<PatientExtract>
    {
        PatientExtract Find(Guid facilityId, int patientPID);
        PatientExtract FindBy(Guid id);
        PatientExtract FindBy(Guid facilityId, int patientPID);
        Guid? GetPatientBy(Guid facilityId, string patientNumber);
        Guid? GetPatientBy(Guid facilityId, int patientPID);
        Guid? GetPatientByIds(Guid facilityId, int patientPID);
        Guid? Sync(PatientExtract patient);
        Guid? SyncNew(PatientExtract patient);
        void SaveManifest(FacilityManifest facilityManifest);
        Task ClearManifest(Manifest manifest);
        Task RemoveDuplicates(int siteCode);
        Task InitializeManifest(Manifest manifest);
        Task<MasterFacility> VerifyFacility(int siteCode);
    }
}

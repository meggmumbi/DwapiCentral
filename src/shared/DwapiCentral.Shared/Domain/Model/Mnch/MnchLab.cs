﻿using DwapiCentral.Contracts.Mnch;
using DwapiCentral.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Shared.Domain.Model.Mnch
{
    public class MnchLab   : Entity<Guid>
    {
        public int PatientPk { get; set; }
        public int SiteCode { get; set; }
        public string Emr { get; set; }
        public string Project { get; set; }
        public bool? Processed { get; set; }
        public string QueueId { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? DateExtracted { get; set; }
        public Guid FacilityId { get; set; }
        public string PatientMNCH_ID { get; set; }
        public string FacilityName { get; set; }
        public string SatelliteName { get; set; }
        public int? VisitID { get; set; }
        public DateTime? OrderedbyDate { get; set; }
        public DateTime? ReportedbyDate { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; }
        public string LabReason { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }

        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}

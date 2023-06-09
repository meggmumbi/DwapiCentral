﻿using DwapiCentral.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Shared.Domain.Model.Hts
{
    public class HtsClientTests : Entity<Guid>
    {
        public virtual string FacilityName { get; set; }
        public int SiteCode { get; set; }
        public int PatientPk { get; set; }
        public string HtsNumber { get; set; }
        public string Emr { get; set; }
        public string Project { get; set; }
        public bool? Processed { get; set; }
        public string QueueId { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? DateExtracted { get; set; }
        public int? EncounterId { get; set; }
        public DateTime? TestDate { get; set; }
        public string EverTestedForHiv { get; set; }
        public int? MonthsSinceLastTest { get; set; }
        public string ClientTestedAs { get; set; }
        public string EntryPoint { get; set; }
        public string TestStrategy { get; set; }
        public string TestResult1 { get; set; }
        public string TestResult2 { get; set; }
        public string FinalTestResult { get; set; }
        public string PatientGivenResult { get; set; }
        public string TbScreening { get; set; }
        public string ClientSelfTested { get; set; }
        public string CoupleDiscordant { get; set; }
        public string TestType { get; set; }
        public string Consent { get; set; }
        public Guid FacilityId { get; set; }

        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}

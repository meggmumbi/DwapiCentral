﻿using DwapiCentral.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Shared.Domain.Model.Hts
{
    public class HtsClientTracing  : Entity<Guid>
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
        public String TracingType { get; set; }
        public DateTime? TracingDate { get; set; }
        public string TracingOutcome { get; set; }
        public Guid FacilityId { get; set; }

        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}

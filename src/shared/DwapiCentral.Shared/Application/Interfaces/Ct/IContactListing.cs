﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Shared.Application.Interfaces.Ct
{
    public interface IContactListing
    {
        string FacilityName { get; set; }
        int? PartnerPersonID { get; set; }
        string ContactAge { get; set; }
        string ContactSex { get; set; }
        string ContactMaritalStatus { get; set; }
        string RelationshipWithPatient { get; set; }
        string ScreenedForIpv { get; set; }
        string IpvScreening { get; set; }
        string IPVScreeningOutcome { get; set; }
        string CurrentlyLivingWithIndexClient { get; set; }
        string KnowledgeOfHivStatus { get; set; }
        string PnsApproach { get; set; }
        int? ContactPatientPK { get; set; }
        DateTime? Date_Created { get; set; }
        DateTime? Date_Last_Modified { get; set; }
    }
}

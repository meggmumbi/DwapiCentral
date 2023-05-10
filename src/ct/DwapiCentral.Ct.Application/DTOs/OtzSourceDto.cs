using DwapiCentral.Contracts.Ct;
using System;


namespace DwapiCentral.Ct.Application.DTOs
{
    public class OtzSourceDto : SourceDto, IOtz
    {
        public string FacilityName { get; set; }
        public int? VisitID { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime? OTZEnrollmentDate { get; set; }
        public string TransferInStatus { get; set; }
        public string ModulesPreviouslyCovered { get; set; }
        public string ModulesCompletedToday { get; set; }
        public string SupportGroupInvolvement { get; set; }
        public string Remarks { get; set; }
        public string TransitionAttritionReason { get; set; }
        public DateTime? OutcomeDate { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
        public int PatientPk { get; set; }
        public bool Voided { get; set; }
        public DateTime? Extracted { get; set; }
        Guid IOtz.PatientId { get; set; }
    }
}
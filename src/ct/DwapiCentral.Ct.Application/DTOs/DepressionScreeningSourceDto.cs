using DwapiCentral.Contracts.Ct;
using System;


namespace DwapiCentral.Ct.Application.DTOs
{
    public class DepressionScreeningSourceDto : IDepressionScreening
    {
        public Guid Id { get; set; }
        public int VisitID { get; set; }
        public DateTime VisitDate { get; set; }
        public string? FacilityName { get; set; }
        public string? PHQ9_1 { get; set; }
        public string? PHQ9_2 { get; set; }
        public string? PHQ9_3 { get; set; }
        public string? PHQ9_4 { get; set; }
        public string? PHQ9_5 { get; set; }
        public string? PHQ9_6 { get; set; }
        public string? PHQ9_7 { get; set; }
        public string? PHQ9_8 { get; set; }
        public string? PHQ9_9 { get; set; }
        public string? PHQ_9_rating { get; set; }
        public int? DepressionAssesmentScore { get; set; }
        public int PatientPk { get; set; }
        public int SiteCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public DateTime? DateExtracted { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Voided { get; set; }
        public virtual bool IsValid()
        {
            return SiteCode > 0 &&
                   PatientPk > 0;
        }
    }
}
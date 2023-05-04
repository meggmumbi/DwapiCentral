using System;
using DwapiCentral.Shared.Application.Interfaces.Ct;
using PalladiumDwh.Shared.Interfaces;

namespace DwapiCentral.Shared.Application.DTOs
{
    public class DepressionScreeningSourceDto : SourceDto, IDepressionScreening
    {
        public string FacilityName { get; set; }
        public int? VisitID { get; set; }
        public DateTime? VisitDate { get; set; }
        public string PHQ9_1 { get; set; }
        public string PHQ9_2 { get; set; }
        public string PHQ9_3 { get; set; }
        public string PHQ9_4 { get; set; }
        public string PHQ9_5 { get; set; }
        public string PHQ9_6 { get; set; }
        public string PHQ9_7 { get; set; }
        public string PHQ9_8 { get; set; }
        public string PHQ9_9 { get; set; }
        public string PHQ_9_rating { get; set; }
        public int? DepressionAssesmentScore { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
    }
}
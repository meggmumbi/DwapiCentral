using DwapiCentral.Contracts.Common;
using System;

namespace DwapiCentral.Contracts.Mnch
{
   public  interface ICwcEnrolment : IEntity
    {
          
          bool? Processed { get; set; }
          string QueueId { get; set; }
          string Status { get; set; }
          DateTime? StatusDate { get; set; }
          DateTime? DateExtracted { get; set; }
          Guid FacilityId { get; set; }
          string Pkv { get; set; }
          string PatientIDCWC { get; set; }
          string HEIID { get; set; }
          string MothersPkv { get; set; }
          DateTime? RegistrationAtCWC { get; set; }
          DateTime? RegistrationAtHEI { get; set; }
          int? VisitID { get; set; }
          DateTime? Gestation { get; set; }
          string BirthWeight { get; set; }
          decimal? BirthLength { get; set; }
          int? BirthOrder { get; set; }
          string BirthType { get; set; }
          string PlaceOfDelivery { get; set; }
          string ModeOfDelivery { get; set; }
          string SpecialNeeds { get; set; }
          string SpecialCare { get; set; }
          string HEI { get; set; }
          string MotherAlive { get; set; }
          string MothersCCCNo { get; set; }
          string TransferIn { get; set; }
          string TransferInDate { get; set; }
          string TransferredFrom { get; set; }
          string HEIDate { get; set; }
          string NVP { get; set; }
          string BreastFeeding { get; set; }
          string ReferredFrom { get; set; }
          string ARTMother { get; set; }
          string ARTRegimenMother { get; set; }
          DateTime? ARTStartDateMother { get; set; }
         

    }
}

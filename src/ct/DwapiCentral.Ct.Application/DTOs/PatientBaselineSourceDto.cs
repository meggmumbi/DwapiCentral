﻿using DwapiCentral.Contracts.Ct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.DTOs
{
    public class PatientBaselineSourceDto : IPatientBaselines
    {
        public Guid Id { get ; set ; }
        public int? bCD4 { get ; set ; }
        public DateTime? bCD4Date { get ; set ; }
        public int? bWAB { get ; set ; }
        public DateTime? bWABDate { get ; set ; }
        public int? bWHO { get ; set ; }
        public DateTime? bWHODate { get ; set ; }
        public int? eWAB { get ; set ; }
        public DateTime? eWABDate { get ; set ; }
        public int? eCD4 { get ; set ; }
        public DateTime? eCD4Date { get ; set ; }
        public int? eWHO { get ; set ; }
        public DateTime? eWHODate { get ; set ; }
        public int? lastWHO { get ; set ; }
        public DateTime? lastWHODate { get ; set ; }
        public int? lastCD4 { get ; set ; }
        public DateTime? lastCD4Date { get ; set ; }
        public int? lastWAB { get ; set ; }
        public DateTime? lastWABDate { get ; set ; }
        public int? m12CD4 { get ; set ; }
        public DateTime? m12CD4Date { get ; set ; }
        public int? m6CD4 { get ; set ; }
        public DateTime? m6CD4Date { get ; set ; }
        public int PatientPk { get ; set ; }
        public int SiteCode { get ; set ; }
        public DateTime? DateCreated { get ; set ; }
        public DateTime? DateLastModified { get ; set ; }
        public DateTime? DateExtracted { get ; set ; }
        public DateTime? Created { get ; set ; }
        public DateTime? Updated { get ; set ; }
        public bool? Voided { get ; set ; }
     
        public virtual  bool IsValid()
        {
            return SiteCode > 0 && 
                PatientPk > 0;
        }
    }
}

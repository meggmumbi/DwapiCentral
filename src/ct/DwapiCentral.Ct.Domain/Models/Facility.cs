using DwapiCentral.Contracts.Manifest;
using DwapiCentral.Shared.Domain.Entities;
using DwapiCentral.Shared.Domain.Entities.Ct;
using DwapiCentral.Shared.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Domain.Models.Extracts
{
    public class Facility : Entity, IFacility
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }

        public DateTime? SnapshotDate { get; set; }
        public int? SnapshotSiteCode { get; set; }
        public int? SnapshotVersion { get; set; }

        public virtual ICollection<PatientExtract> PatientExtracts { get; set; } = new List<PatientExtract>();

        public Facility()
        {
            Created = DateTime.Now;
        }

        public Facility(int code, string name, string emr, string project)
            : this()
        {
            Code = code;
            Name = name;
            Emr = emr;
            Project = project;
        }

        public void UpdateProfile(string emr, string project)
        {
            Emr = emr;
            Project = project;
        }

    }
}

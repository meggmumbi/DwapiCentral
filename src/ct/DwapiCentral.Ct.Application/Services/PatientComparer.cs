using DwapiCentral.Ct.Domain.Models.Extracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Services
{
    public class PatientComparer : IEqualityComparer<PatientExtract>
    {
        public bool Equals(PatientExtract? x, PatientExtract? y)
        {
            return x.PatientPID.Equals(y.PatientPID) && x.FacilityId.Equals(y.FacilityId);
        }

        public int GetHashCode([DisallowNull] PatientExtract obj)
        {
            return obj.PatientPID.GetHashCode() ^ obj.FacilityId.GetHashCode();
        }
    }
}

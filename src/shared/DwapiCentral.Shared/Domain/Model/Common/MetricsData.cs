using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Shared.Domain.Model.Common
{
    public class MetricsData
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public DateTime LogDate { get; set; }
        public string LogValue { get; set; }
        public int Status { get; set;}
        public string Display { get; set; }
        public string Action { get; set; }
        public int Rank { get; set; }
        public Guid Id { get; set; }

    }
}

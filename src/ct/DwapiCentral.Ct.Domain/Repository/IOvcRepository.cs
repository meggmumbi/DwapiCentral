﻿using DwapiCentral.Ct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Domain.Repository
{
    public interface IOvcRepository 
    {
        Task MergeAsync(IEnumerable<OvcExtract> ovcExtracts);
    }
}

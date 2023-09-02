﻿using DwapiCentral.Ct.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Domain.Repository
{
    public interface IContactListingRepository
    {
        Task MergeAsync(IEnumerable<ContactListingExtract> contactListingExtracts);
    }
}

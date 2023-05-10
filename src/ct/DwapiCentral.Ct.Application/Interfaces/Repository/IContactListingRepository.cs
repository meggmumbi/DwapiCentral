﻿using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Interfaces.Repository
{
    public interface IContactListingRepository
    {
        Task<bool> ExistsAsync(int PatientId);
        Task AddAsync(ContactListingSourceDto contactListing);
    }
}

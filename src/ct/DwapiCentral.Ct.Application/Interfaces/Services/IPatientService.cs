﻿using DwapiCentral.Ct.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Interfaces.Services
{
    public interface IPatientService
    {
        void ProcessPatientData(IEnumerable<PatientSourceDto> patients);
    }
}

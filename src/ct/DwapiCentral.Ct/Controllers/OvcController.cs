﻿using AutoMapper;
using CSharpFunctionalExtensions;
using DwapiCentral.Ct.Application.Commands;
using DwapiCentral.Ct.Application.DTOs.Source;
using Hangfire;
using Infrastracture.Custom;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.ComponentModel;

namespace DwapiCentral.Ct.Controllers
{
    public class OvcController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OvcController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/v3/Ovc")]
        public async Task<IActionResult> PostBatch([FromBody] OvcSourceBag sourceBag)
        {

            if (null != sourceBag && sourceBag.Extracts.Any())
            {
                if (sourceBag.Extracts.Any(x => !x.IsValid()))
                {
                    return BadRequest("Invalid data, please ensure it has Patient, Facility, and at least one (1) Extract");

                }

                try
                {
                    string jobId;
                    if (sourceBag.HasJobId)
                    {

                        jobId = BatchJob.ContinueBatchWith(sourceBag.JobId,
                          x => { x.Enqueue(() => Send($"{sourceBag}", new MergeOvcCommand(sourceBag))); }, $"{sourceBag}");
                    }
                    else
                    {
                        jobId = BatchJob.StartNew(x =>
                        {
                            x.Enqueue(() => Send($"{sourceBag}", new MergeOvcCommand(sourceBag)));
                        }, $"{sourceBag}");
                    }
                    var successMessage = new
                    {
                        JobId = jobId,
                        BatchKey = new List<Guid>() { LiveGuid.NewGuid() }
                    };
                    return Ok(successMessage);

                }
                catch (Exception ex)
                {
                    Log.Error(new string('*', 30));
                    Log.Error(nameof(OvcSourceBag), ex);
                    Log.Error(new string('*', 30));
                    return BadRequest(ex);
                }
            }

            return BadRequest($"The expected '{new OvcSourceBag().GetType().Name}' is null");
        }

        [Queue("ovc")]        
        [AutomaticRetry(Attempts = 3)]
        [DisplayName("{0}")]
        public async Task Send(string jobName, IRequest<Result> command)
        {
            await _mediator.Send(command);
        }

    }
}
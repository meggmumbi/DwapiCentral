using System.Data;
using System.Reflection;
using AutoMapper;
using Dapper;
using DwapiCentral.Ct.Domain.Events;
using DwapiCentral.Ct.Domain.Models.Extracts;
using DwapiCentral.Ct.Domain.Models.Stage;
using DwapiCentral.Ct.Domain.Repository.Stage;
using DwapiCentral.Ct.Infrastructure.Persistence.Context;
using DwapiCentral.Shared.Domain.Enums;
using log4net;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Z.Dapper.Plus;

namespace DwapiCentral.Ct.Infrastructure.Persistence.Repository.Stage
{
    public class StageCovidExtractRepository :IStageCovidExtractRepository
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CtDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly string _stageName;

        public StageCovidExtractRepository(CtDbContext context, IMapper mapper, IMediator mediator, string stageName = $"{nameof(StageCovidExtract)}s")
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _stageName = stageName;
        }

        public async Task SyncStage(List<StageCovidExtract> extracts, Guid manifestId)
        {
            try
            {
                // stage > Rest
                _context.Database.GetDbConnection().BulkInsert(extracts);

                var notification = new ExtractsReceivedEvent { TotalExtractsStaged = extracts.Count, ManifestId = manifestId, SiteCode = extracts.First().SiteCode, ExtractName = "CovidExtract" };
                await _mediator.Publish(notification);


                // assign > Assigned
                await AssignAll(manifestId, extracts.Select(x => x.Id).ToList());

                // Merge
                await MergeExtracts(manifestId, extracts);


            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }

        private async Task MergeExtracts(Guid manifestId, List<StageCovidExtract> stageCovid)
        {
            var cons = _context.Database.GetConnectionString();
            try
            {
                using var connection = new SqlConnection(cons);
                List<StageCovidExtract> uniqueStageExtracts;
                await connection.OpenAsync();

                var queryParameters = new
                {
                    stagePatientPKs = stageCovid.Select(x => x.PatientPk),
                    stageSiteCodes = stageCovid.Select(x => x.SiteCode),
                    stageVisitIDs = stageCovid.Select(x=> x.VisitID),
                    stageCovid19AssessmentDates = stageCovid.Select(x => x.Covid19AssessmentDate),



                };

                var query = @"
                            SELECT p.*
                            FROM CovidExtracts p
                            WHERE EXISTS (
                                SELECT 1
                                FROM StageCovidExtracts s
                                WHERE p.PatientPk = s.PatientPK
                                AND p.SiteCode = s.SiteCode 
                                AND P.VisitID = s.VisitID
                                AND P.Covid19AssessmentDate = s.Covid19AssessmentDate                               
                                
                            )
                        ";

                var existingRecords = await connection.QueryAsync<CovidExtract>(query, queryParameters);
                // Convert existing records to HashSet for duplicate checking
                var existingRecordsSet = new HashSet<(int PatientPK, int SiteCode, int VisitID, DateTime Covid19AssessmentDate)>(existingRecords.Select(x => (x.PatientPk, x.SiteCode,x.VisitID,x.Covid19AssessmentDate)));

                if (existingRecordsSet.Any())
                {

                    // Filter out duplicates from stageExtracts               
                    uniqueStageExtracts = stageCovid
                        .Where(x => !existingRecordsSet.Contains((x.PatientPk, x.SiteCode, x.VisitID, x.Covid19AssessmentDate)) && x.LiveSession == manifestId)
                        .ToList();

                    //Update existing data                    
                    var stageDictionary = stageCovid.ToDictionary(
                        x => new { x.PatientPk, x.SiteCode,x.VisitID,x.Covid19AssessmentDate },
                        x => x);

                    foreach (var existingExtract in existingRecords)
                    {
                        if (stageDictionary.TryGetValue(
                            new { existingExtract.PatientPk, existingExtract.SiteCode,existingExtract.VisitID,existingExtract.Covid19AssessmentDate },
                            out var stageExtract)
                        )
                        {
                            _mapper.Map(stageExtract, existingExtract);
                        }
                    }

                    _context.Database.GetDbConnection().BulkUpdate(existingRecords);

                }
                else
                {
                    uniqueStageExtracts = stageCovid;
                }

                var covidExtracts = _mapper.Map<List<CovidExtract>>(uniqueStageExtracts);
                _context.Database.GetDbConnection().BulkInsert(covidExtracts);


            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }

        }

        private async Task AssignAll(Guid manifestId, List<Guid> ids)
        {
            var cons = _context.Database.GetConnectionString();

            var sql = $@"
                    UPDATE 
                            {_stageName}
                    SET 
                            LiveStage = @nextlivestage 
                    WHERE 
                            LiveSession = @manifestId AND 
                            LiveStage = @livestage AND 
                            Id IN @ids";
            try
            {
                using var connection = new SqlConnection(cons);
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                await connection.ExecuteAsync($"{sql}",
                    new
                    {
                        manifestId,
                        livestage = LiveStage.Rest,
                        nextlivestage = LiveStage.Assigned,
                        ids
                    }, null, 0);
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }
    }
}

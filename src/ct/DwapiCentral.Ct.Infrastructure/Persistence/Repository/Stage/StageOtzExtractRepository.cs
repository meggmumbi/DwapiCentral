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
    public class StageOtzExtractRepository :IStageOtzExtractRepository
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CtDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly string _stageName;

        public StageOtzExtractRepository(CtDbContext context, IMapper mapper, IMediator mediator, string stageName = $"{nameof(StageOtzExtract)}s")
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _stageName = stageName;
        }

        public async Task SyncStage(List<StageOtzExtract> extracts, Guid manifestId)
        {
            try
            {
                // stage > Rest
                _context.Database.GetDbConnection().BulkInsert(extracts);

                var notification = new ExtractsReceivedEvent { TotalExtractsStaged = extracts.Count, ManifestId = manifestId, SiteCode = extracts.First().SiteCode, ExtractName = "OtzExtract" };
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

        private async Task MergeExtracts(Guid manifestId, List<StageOtzExtract> stageOtz)
        {
            var cons = _context.Database.GetConnectionString();
            try
            {
                using var connection = new SqlConnection(cons);
                List<StageOtzExtract> uniqueStageExtracts;
                await connection.OpenAsync();

                var queryParameters = new
                {
                    PatientPKs = stageOtz.Select(x => x.PatientPk),
                    SiteCodes = stageOtz.Select(x => x.SiteCode),
                    VisitIds = stageOtz.Select(x => x.VisitID),
                    VisitDates = stageOtz.Select(x => x.VisitDate)
                };

                var query = @"
                            SELECT p.*
                            FROM OtzExtracts p
                            WHERE EXISTS (
                                SELECT 1
                                FROM StageOtzExtracts s
                                WHERE p.PatientPk = s.PatientPK
                                AND p.SiteCode = s.SiteCode 
                                AND P.VisitID = s.VisitID
                                AND P.VisitDate = s.VisitDate                               
                                
                            )
                        ";

                var existingRecords = await connection.QueryAsync<OtzExtract>(query, queryParameters);

                // Convert existing records to HashSet for duplicate checking
                var existingRecordsSet = new HashSet<(int PatientPK, int SiteCode, int VisitID, DateTime VisitDate)>(existingRecords.Select(x => (x.PatientPk, x.SiteCode, x.VisitID, x.VisitDate)));

                if (existingRecordsSet.Any())
                {

                    // Filter out duplicates from stageExtracts               
                    uniqueStageExtracts = stageOtz
                        .Where(x => !existingRecordsSet.Contains((x.PatientPk, x.SiteCode, x.VisitID, x.VisitDate)) && x.LiveSession == manifestId)
                        .ToList();

                    //Update existing data                    
                    var stageDictionary = stageOtz.ToDictionary(
                        x => new { x.PatientPk, x.SiteCode, x.VisitID, x.VisitDate },
                        x => x);

                    foreach (var existingExtract in existingRecords)
                    {
                        if (stageDictionary.TryGetValue(
                            new { existingExtract.PatientPk, existingExtract.SiteCode, existingExtract.VisitID, existingExtract.VisitDate },
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
                    uniqueStageExtracts = stageOtz;
                }

                var extracts = _mapper.Map<List<OtzExtract>>(uniqueStageExtracts);
                _context.Database.GetDbConnection().BulkInsert(extracts);


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

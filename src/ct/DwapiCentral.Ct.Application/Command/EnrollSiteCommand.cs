using DwapiCentral.Ct.Domain.Models.Extracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Command
{
    public class EnrollSiteCommand : IRequest<Facility>
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public int? SnapshotSiteCode { get; set; }
        public int? SnapshotVersion { get; set; }
        public Guid Id { get; set; }        
        public string Emr { get; set; }
        public string Project { get; set; }
        public bool Voided { get; set; }
        public bool Processed { get; set; }

        public EnrollSiteCommand(int code,string name,DateTime created,DateTime snapshotDate,int snapshotsitecode,int snapshotversion,Guid id,string emr,string project,bool voided,bool processed) 
        {
            Code= code;
            Name= name;
            Created= created;
            SnapshotDate= snapshotDate;
            SnapshotSiteCode= snapshotsitecode;
            SnapshotVersion= snapshotversion;
            Id= id;
            Emr= emr;
            Project= project;
            Voided= voided;
            Processed= processed;

        
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwapiCentral.Ct.Application.Command
{
    public class ProcessManifestFileCommand : IRequest
    {
        public string FileName { get; set; }
        public string Content { get; set; }
    }
}

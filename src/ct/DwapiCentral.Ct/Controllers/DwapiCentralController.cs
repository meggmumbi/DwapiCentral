using DwapiCentral.Ct.Application.Services;
using DwapiCentral.Ct.Domain.Models.Extracts;
using Microsoft.AspNetCore.Mvc;

namespace DwapiCentral.Ct.Controllers
{
    public class DwapiCentralController : Controller
    {
        private readonly PatientService _patientService;

        public DwapiCentralController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        [Route("api/v3/Spot")]
        public async Task<IActionResult> PostManifest([FromBody] Manifest manifest)
        {
            await _patientService.AddManifestAsync(manifest);
            return Ok("Manifest Saved uccessfully");

        }
    }
}

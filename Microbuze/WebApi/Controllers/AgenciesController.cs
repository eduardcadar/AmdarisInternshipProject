using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/agencies")]
    [ApiController]
    public class AgenciesController : ControllerBase
    {
        private readonly IAgenciesService _agenciesService;

        public AgenciesController(IAgenciesService agenciesService)
        {
            _agenciesService = agenciesService;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<AgencyDTO>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var agencyDto = await _agenciesService.FindAgencyById(id, cancellationToken);
            return Ok(agencyDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgency(AgencyDTO agencyDTO, CancellationToken cancellationToken = default)
        {
            var createdAgency = await _agenciesService.CreateAgency(agencyDTO.AgencyName, agencyDTO.PhoneNumber, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = createdAgency.Id}, createdAgency);
        }
    }
}

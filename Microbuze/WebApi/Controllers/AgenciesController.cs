using Api.DTO;
using Application.DTOs;
using Application.Services.Interfaces;
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
            try
            {
                var agencyDto = await _agenciesService.FindAgencyById(id, cancellationToken);
                if (agencyDto == null)
                    return NotFound();
                return Ok(agencyDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgency([FromBody] AgencyCreateDTO agency, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdAgency = await _agenciesService.CreateAgency(agency.AgencyName, agency.PhoneNumber, cancellationToken);
                return CreatedAtAction(nameof(GetById), new { id = createdAgency.Id }, createdAgency);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCare.PatientProfileManagement.Api.Dtos;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Application.Handlers.Queries;
using SmartCare.PatientProfileManagement.Application.Queries;

namespace SmartCare.PatientProfileManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PatientController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("GetPatient/{id}")]
        public async Task<ActionResult<PatientProfileDto>> GetPatientById(Guid id)
        {
            var query = _mapper.Map<GetPatientProfileByIdQuery>(id);
            var result = await _mediator.Send(query);

            if (result.Succeeded)
            {
                return Ok(_mapper.Map<PatientProfileDto>(result.Data));
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<List<PatientProfileDto>>> GetPatients()
        {
            var query = new GetPatientsProfilesQuery();

            var result = await _mediator.Send(query);

            if (result.Succeeded)
            {
                return Ok(_mapper.Map<List<PatientProfileDto>>(result.Data));
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientProfileDto patientDto)
        {
            var command = _mapper.Map<CreatePatientProfileCommand>(patientDto);

            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientProfileDto patientDto)
        {

            var command = _mapper.Map<UpdatePatientProfileCommand>(patientDto);
            command.Id = id;

            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var command = _mapper.Map<DeletePatientProfileCommand>(id);

            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
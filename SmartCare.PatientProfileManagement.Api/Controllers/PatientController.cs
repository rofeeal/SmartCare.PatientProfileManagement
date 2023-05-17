using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCare.PatientProfileManagement.Api.Dtos;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Application.Handlers.Queries;
using SmartCare.PatientProfileManagement.Application.Queries;
using SmartCare.PatientProfileManagement.Domain.Entites;

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
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var query = _mapper.Map<GetPatientProfileByIdQuery>(id);
            var result = await _mediator.Send(query);

            if (result.Succeeded)
            {
                return Ok(_mapper.Map<PatientProfileQueryDto>(result.Data));
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetPatients()
        {
            var query = new GetPatientsProfilesQuery();

            var result = await _mediator.Send(query);

            if (result.Succeeded)
            {
                var patientProfiles = result.Data;
                return Ok(_mapper.Map<List<PatientProfileQueryDto>>(patientProfiles));
                //return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientProfileCommandDto patientDto)
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
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientProfileCommandDto patientDto)
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
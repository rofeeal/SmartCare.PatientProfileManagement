using AutoMapper;
using MediatR;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Domain.Events;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Handlers.Commands
{
    public class CreatePatientProfileCommandHandler : IRequestHandler<CreatePatientProfileCommand, ResultWithData<Guid>>
    {
        private readonly IPatientProfileCommandRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreatePatientProfileCommandHandler(IPatientProfileCommandRepository patientRepository, IMapper mapper, IMediator mediator)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        async Task<ResultWithData<Guid>> IRequestHandler<CreatePatientProfileCommand, ResultWithData<Guid>>.Handle(CreatePatientProfileCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<PatientProfile>(request);

            var patientCreatedEvent = new PatientProfileCreatedEvent(patient);

            await _mediator.Publish(patientCreatedEvent);

            var result = await _patientRepository.AddAsync(patient);

            return result;

        }
    }
}

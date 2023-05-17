using MediatR;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Domain.Events;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Handlers.Commands
{
    public class DeletePatientProfileCommandHandler : IRequestHandler<DeletePatientProfileCommand, Result>
    {
        private readonly IPatientProfileCommandRepository _patientRepository;
        private readonly IMediator _mediator;

        public DeletePatientProfileCommandHandler(IPatientProfileCommandRepository patientRepository, IMediator mediator)
        {
            _patientRepository = patientRepository;
            _mediator = mediator;
        }

        async Task<Result> IRequestHandler<DeletePatientProfileCommand, Result>.Handle(DeletePatientProfileCommand request, CancellationToken cancellationToken)
        {
            var patientDeletedEvent = new PatientProfileDeletedEvent(request.Id);

            await _mediator.Publish(patientDeletedEvent, cancellationToken);

            var result = await _patientRepository.DeleteAsync(request.Id);

            return result;
        }
    }    
}
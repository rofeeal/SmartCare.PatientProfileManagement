using MediatR;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Handlers.Commands
{
    public class DeletePatientProfileCommandHandler : IRequestHandler<DeletePatientProfileCommand, Result>
    {
        private readonly IPatientProfileCommandRepository _patientRepository;

        public DeletePatientProfileCommandHandler(IPatientProfileCommandRepository patientRepository, IMediator mediator)
        {
            _patientRepository = patientRepository;
        }

        async Task<Result> IRequestHandler<DeletePatientProfileCommand, Result>.Handle(DeletePatientProfileCommand request, CancellationToken cancellationToken)
        {

            return await _patientRepository.DeleteAsync(request.Id);
        }
    }    
}
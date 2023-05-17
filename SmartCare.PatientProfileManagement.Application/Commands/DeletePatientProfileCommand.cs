using MediatR;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Commands
{
    public class DeletePatientProfileCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}

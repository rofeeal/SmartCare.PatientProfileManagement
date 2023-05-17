using MediatR;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Queries
{
    public class GetPatientProfileByIdQuery : IRequest<ResultWithData<PatientProfile>>
    {
        public Guid PatientId { get; set; }
    }
}

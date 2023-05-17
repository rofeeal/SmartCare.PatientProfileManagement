using MediatR;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Queries
{
    public class GetPatientsProfilesQuery : IRequest<ResultWithData<List<PatientProfile>>>
    {
    }
}

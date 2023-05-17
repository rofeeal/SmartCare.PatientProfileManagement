using MediatR;
using SmartCare.PatientProfileManagement.Application.Queries;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Handlers.Queries
{
    public class GetPatientsProfilesQueryHandler : IRequestHandler<GetPatientsProfilesQuery, ResultWithData<List<PatientProfile>>>
    {
        private readonly IPatientProfileQueryRepository _queryRepository;

        public GetPatientsProfilesQueryHandler(IPatientProfileQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<ResultWithData<List<PatientProfile>>> Handle(GetPatientsProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetAllPatientsProfilesAsync();
        }
    }
}

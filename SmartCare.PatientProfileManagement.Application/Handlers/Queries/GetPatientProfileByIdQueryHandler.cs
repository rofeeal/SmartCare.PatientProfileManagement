using MediatR;
using SmartCare.PatientProfileManagement.Application.Queries;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Handlers.Queries
{
    public class GetPatientProfileByIdQueryHandler : IRequestHandler<GetPatientProfileByIdQuery, ResultWithData<PatientProfile>>
    {
        private readonly IPatientProfileQueryRepository _repository;

        public GetPatientProfileByIdQueryHandler(IPatientProfileQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultWithData<PatientProfile>> Handle(GetPatientProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPatientProfileAsync(request.PatientId);
        }
    }
}

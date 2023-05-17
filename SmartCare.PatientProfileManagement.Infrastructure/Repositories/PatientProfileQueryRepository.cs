using Microsoft.EntityFrameworkCore;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Infrastructure.Context;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Infrastructure.Repositories
{
    public class PatientProfileQueryRepository : IPatientProfileQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientProfileQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultWithData<List<PatientProfile>>> GetAllPatientsProfilesAsync()
        {
            try
            {
                var patientProfiles = await _context.PatientProfiles.ToListAsync();

                return ResultWithData<List<PatientProfile>>.Success(patientProfiles);
            }
            catch (Exception ex)
            {
                return ResultWithData<List<PatientProfile>>.Error(ex.Message);
            }
        }

        public async Task<ResultWithData<PatientProfile>> GetPatientProfileAsync(Guid patientId)
        {
            var patientProfile = await _context.PatientProfiles.FindAsync(patientId);

            if (patientProfile != null)
            {
                return ResultWithData<PatientProfile>.Success(patientProfile);
            }
            else
            {
                return ResultWithData<PatientProfile>.Error("Patient profile not found.");
            }
        }
    }
}

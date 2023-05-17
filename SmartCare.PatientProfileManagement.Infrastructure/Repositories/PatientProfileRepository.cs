using MediatR;
using Microsoft.Extensions.Logging;
using SmartCare.PatientProfileManagement.Domain.Events;
using SmartCare.PatientProfileManagement.Infrastructure.Context;

namespace SmartCare.PatientProfileManagement.Infrastructure.Repositories
{
    public class PatientProfileRepository : INotificationHandler<PatientProfileCreatedEvent>,
        INotificationHandler<PatientProfileUpdatedEvent>,
        INotificationHandler<PatientProfileDeletedEvent>
    {
        private readonly ApplicationDbContext _context;
        private readonly PatientProfileQueryRepository _patientQueryRepository;
        private readonly ILogger<PatientProfileRepository> _logger;

        public PatientProfileRepository(ApplicationDbContext context, PatientProfileQueryRepository patientQueryRepository, ILogger<PatientProfileRepository> logger)
        {
            _context = context;
            _patientQueryRepository = patientQueryRepository;
            _logger = logger;
        }

        public async Task Handle(PatientProfileCreatedEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                await _context.PatientProfiles.AddAsync(notification.PatientProfile);
                await _context.SaveChangesAsync();

                // Log the successful creation of the patient profile
                _logger.LogInformation("Patient profile created successfully. PatientId: {PatientId}", notification.PatientProfile.Id);
            }
            catch (Exception ex)
            {
                // Log the exception and handle the error
                _logger.LogError(ex, "Failed to create patient profile.");

                // Rethrow the exception or perform any necessary error handling
                throw;
            }
        }

        public async Task Handle(PatientProfileUpdatedEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                _context.PatientProfiles.Update(notification.PatientProfile);
                await _context.SaveChangesAsync();

                // Log the successful update of the patient profile
                _logger.LogInformation("Patient profile updated successfully. PatientId: {PatientId}", notification.PatientProfile.Id);
            }
            catch (Exception ex)
            {
                // Log the exception and handle the error
                _logger.LogError(ex, "Failed to update patient profile.");

                // Rethrow the exception or perform any necessary error handling
                throw;
            }
        }

        public async Task Handle(PatientProfileDeletedEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var patientResult = await _patientQueryRepository.GetPatientProfileAsync(notification.PatientId);

                if (patientResult.Succeeded)
                {
                    _context.PatientProfiles.Remove(patientResult.Data);
                    await _context.SaveChangesAsync();

                    // Log the successful deletion of the patient profile
                    _logger.LogInformation("Patient profile deleted successfully. PatientId: {PatientId}", notification.PatientId);
                }
                else
                {
                    // Log the patient profile not found
                    _logger.LogInformation("Patient profile not found for deletion. PatientId: {PatientId}", notification.PatientId);
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle the error
                _logger.LogError(ex, "Failed to delete patient profile.");

                // Rethrow the exception or perform any necessary error handling
                throw;
            }
        }
    }
}
